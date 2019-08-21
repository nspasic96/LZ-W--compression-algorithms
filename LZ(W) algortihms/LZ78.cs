using System.Collections.Generic;

namespace LZ_W__algortihms
{
    internal class LZ78 : CompressionAlgorithm
    {
        protected override bool hasNextStep()
        {
            return false;
        }

        protected override Dictionary<string, string> nextStep()
        {
            throw new System.NotImplementedException();
        }

        protected override void resetAndPrepare()
        {
            throw new System.NotImplementedException();
        }
    }
}