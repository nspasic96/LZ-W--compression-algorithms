using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static LZ_W__algortihms.Utils;
using System.Windows.Forms;
using System.Threading;

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

        public List<AlgorithmStatistic> Statistics { get => statistics; }
        public List<AlgorithmParameter> Parameters { get => parameters; }

        protected abstract List<StepInfo> nextStep();
        protected abstract void prepare();

        protected abstract void visualization(List<StepInfo> stepInfos);
        protected virtual void processStepResults(List<StepInfo> stepInfos, bool[] input) {}
        protected bool hasNextStep() {
            return currPossition < totalLen;
        }
        protected CompressionAlgorithm()
        {
            statistics = new List<AlgorithmStatistic>();
            statistics.Add(new AlgorithmStatistic("Time elapsed", "300s"));
        }

        public void convert(string input, TextBox result, bool visualize)
        {
            this.rawInput = input;
            bool[] inp = convertToBits(input);
            this.input = inp;
            currPossition = 0;
            totalLen = input.Length;
            output = new StringBuilder();
            prepare();
            while (hasNextStep())
            {
                List<StepInfo> stepResults = nextStep();//ovde meriti vreme za svaki korak

                if (visualize)
                {
                    visualization(stepResults);

                    result.Text = this.output.ToString();
                    result.Refresh();
                }

                processStepResults(stepResults, this.input);
            }

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
