using System.Collections.Generic;
using static LZ_W__algortihms.Utils;

namespace LZ_W__algortihms
{
    internal class LZ78 : CompressionAlgorithm
    {
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