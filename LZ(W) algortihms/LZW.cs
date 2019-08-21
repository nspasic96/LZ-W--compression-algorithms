using System.Collections.Generic;
using static LZ_W__algortihms.Utils;

namespace LZ_W__algortihms
{
    internal class LZW : CompressionAlgorithm
    {

        public LZW()
        {
            var p = new List<AlgorithmParameter>();

            List<string> onDictFullValues = new List<string>();
            onDictFullValues.Add("Stop adding");
            onDictFullValues.Add("Reset");

            AlgorithmParameter onDictFull = new AlgorithmParameter("On full dictionary", onDictFullValues[0], ParameterType.List, onDictFullValues);
            p.Add(onDictFull);

            AlgorithmParameter redundantBits = new AlgorithmParameter("Number of redundant bits", "3");
            p.Add(redundantBits);
            this.parameters = p;

            this.statistics.Add(new AlgorithmStatistic("LZW statistics param", "value of param"));
        }
        
        protected override bool hasNextStep()
        {
            return false;
        }

        protected override List<StepInfo> nextStep()
        {
            throw new System.NotImplementedException();
        }

        protected override void resetAndPrepare()
        {
            throw new System.NotImplementedException();
        }

        protected override void visualization(string input, List<StepInfo> stepInfos)
        {
            throw new System.NotImplementedException();
        }
    }
}