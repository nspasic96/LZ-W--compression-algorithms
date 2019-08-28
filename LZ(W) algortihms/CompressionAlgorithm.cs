using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static LZ_W__algortihms.Utils;
using System.Windows.Forms;
using System.Threading;
using System.Diagnostics;

namespace LZ_W__algortihms
{
    abstract class CompressionAlgorithm
    {
        protected List<AlgorithmStatistic> statistics;
        protected List<AlgorithmParameter> parameters;
        protected bool[] input;
        protected string rawInput;
        protected StringBuilder output;
        protected int currPossition;
        protected int totalLen;
        protected double totalBitsSent;

        public List<AlgorithmStatistic> Statistics { get => statistics; }
        public List<AlgorithmParameter> Parameters { get => parameters; }

        protected abstract List<StepInfo> nextStep();
        protected abstract void prepare();
        
        protected abstract void visualization(List<StepInfo> stepInfos);
        protected bool hasNextStep() {
            return currPossition < totalLen;
        }
        protected CompressionAlgorithm()
        {
        }

        public void convert(string input, TextBox result, bool visualize)
        {

            this.rawInput = input;
            bool[] inp = convertToBits(input);
            this.input = inp;
            currPossition = 0;
            totalLen = input.Length;
            output = new StringBuilder();
            statistics = new List<AlgorithmStatistic>();
            prepare();
            double totalTime = 0;
            Stopwatch sw = new Stopwatch();
            while (hasNextStep())
            {
                sw.Start();
                List<StepInfo> stepResults = nextStep();
                sw.Stop();
                totalTime += sw.Elapsed.TotalSeconds;
                sw.Reset();
                if (visualize)
                {
                    visualization(stepResults);

                    result.Text = this.output.ToString();
                    result.Refresh();
                }
            }

            statistics.Add(new AlgorithmStatistic("Time elapsed(s)", (totalTime).ToString()));
            statistics.Add(new AlgorithmStatistic("Compression ratio", (totalBitsSent / totalLen).ToString()));
            result.Text = this.output.ToString();
            result.Refresh();
        }

        public void updateParameter(int i, string text)
        {
            if(parameters[i].PT == ParameterType.Text)
            {
                var old = parameters[i];
                old.CurrValue = text;
                parameters[i] = old;
            } else if(parameters[i].PT == ParameterType.List)
            {
                var old = parameters[i];
                if (old.Values.Contains(text))
                {
                    old.CurrValue = text;
                    parameters[i] = old;
                }
            }
        }

        private bool[] convertToBits(string input)
        {
            bool[] res = new bool[input.Length];

            char[] chars = input.ToCharArray();
            int i = 0;
            foreach(var c in chars)
            {
                if(c == '1')
                {
                    res[i] = true;
                } else if (c == '0')
                {
                    res[i] = false;
                } else
                {
                    throw new NotSupportedException("Input must consist of zeros and ones");
                }
                i++;
            }
            return res;
        }
    }
}
