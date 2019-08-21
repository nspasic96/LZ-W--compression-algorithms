using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LZ_W__algortihms
{
    public class Utils
    {
        public static readonly int rowsInTLP = 5;
        public static readonly int columnsInTLP = 2;

        public enum AlgorithmName { LZ77, LZ78, LZW }
        public enum ParameterType { Text, List}
        public struct AlgorithmParameter
        {
            string paramName;
            string currValue;
            ParameterType pt;
            List<string> values;


            public AlgorithmParameter(string name, string defaultVal, ParameterType pt = ParameterType.Text, List<string> values = null)
            {
                paramName = name;
                currValue = defaultVal;
                this.pt = pt;
                this.values = values;
            }

            public string ParamName { get => paramName; set => paramName = value; }
            public string CurrValue { get => currValue; set => currValue = value; }
            public ParameterType PT { get => pt; set => pt = value; }
            public List<string> Values { get => values; set => values = value; }
        }

        public struct AlgorithmStatistic
        {
            string statisticName;
            string statisticValue;

            public AlgorithmStatistic(string name, string value)
            {
                statisticName = name;
                statisticValue = value;
            }

            public string StatisticName { get => statisticName; set => statisticName = value; }
            public string StatisticValue { get => statisticValue; set => statisticValue = value; }
        }

        public struct StepInfo
        {
            int posBack;
            int matchLen;
            int startPos;
            bool newBest;
            string output;

            public StepInfo(int posBack, int matchLen, int startPos, bool newBest = false, string output = null)
            {
                this.posBack = posBack;
                this.matchLen = matchLen;
                this.startPos = startPos;
                this.newBest = newBest;
                this.output = output;
            }

            public int PosBack { get => posBack; set => posBack = value; }
            public int MatchLen { get => matchLen; set => matchLen = value; }
            public bool NewBest { get => newBest; set => newBest = value; }
            public string Output { get => output; set => output = value; }
            public int StartPos { get => startPos; set => startPos = value; }
        }

    }
}
