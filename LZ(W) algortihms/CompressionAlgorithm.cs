using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static LZ_W__algortihms.Utils;

namespace LZ_W__algortihms
{
    abstract class CompressionAlgorithm
    {
        protected List<AlgorithmStatistic> statistics;
        protected List<AlgorithmParameter> parameters;
        protected bool[] input;
        protected StringBuilder output;

        public List<AlgorithmStatistic> Statistics { get => statistics; }
        public List<AlgorithmParameter> Parameters { get => parameters; }

        protected abstract List<StepInfo> nextStep();
        protected abstract bool hasNextStep();
        protected abstract void resetAndPrepare();
        protected virtual void processStepResults(List<StepInfo> stepInfos, bool[] input) {}
        protected CompressionAlgorithm()
        {
            statistics = new List<AlgorithmStatistic>();
            statistics.Add(new AlgorithmStatistic("Time elapsed", "300s"));
        }

        public string convert(string input)
        {
            bool[] inp = convertToBits(input);
            this.input = inp;
            resetAndPrepare();
            while (hasNextStep())
            {
                var stepResults = nextStep();//ovde meriti vreme za svaki korak
                processStepResults(stepResults, this.input);
            }

            /*
            StringBuilder output = new StringBuilder();
            
            foreach(var a in parameters)
            {
                output.Append(a.ParamName + " => " + a.CurrValue + ";  ");
            }
            */
            return this.output.ToString();
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
