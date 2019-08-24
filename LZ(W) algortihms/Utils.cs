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
        public static readonly int rowsUpAndDownInLZ78Table = 5;

        public enum AlgorithmName { LZ77, LZ78, LZW }
        public enum ParameterType { Text, List }
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

        public struct LZ78Entry
        {
            private string word; //word that is added to dictionary
            private string output; //output of the step
            private int step; //step number
            private int pos; //start position of the substring matched

            public LZ78Entry(string word, string output, int step, int pos)
            {
                this.word = word;
                this.output = output;
                this.step = step;
                this.pos = pos;
            }

            public string Word { get => word; set => word = value; }
            public string Output { get => output; set => output = value; }
            public int Step { get => step; set => step = value; }
            public int Pos { get => pos; set => pos = value; }
        }

        public struct StepInfo
        {
            //common
            private string stepMessage; //description of the step
            private string output; //if it is new best, the match encoding in output
            private int startPos; //start position of match in rest
            private int matchLen; //length of the match

            //for LZ77
            private int posBack; //number of positions to move left with respect to start posisition to reach match start in window
            private bool newBest; //is it new best result

            //for LZ78
            private int prefixIdx;
            private bool doAdd;

            public StepInfo(int posBack, int matchLen, int startPos, string stepMessage, bool newBest, string output)
            {
                this.prefixIdx = -1;
                this.doAdd = false;

                this.posBack = posBack;
                this.matchLen = matchLen;
                this.startPos = startPos;
                this.newBest = newBest;
                this.output = output;
                this.stepMessage = stepMessage;
            }
            public StepInfo(int prefixIdx, int matchLen, int startPos, string stepMessage, string output, bool doAdd)
            {
                this.posBack = -1;
                this.newBest = false;

                this.matchLen = matchLen;
                this.doAdd = doAdd;
                this.startPos = startPos;
                this.output = output;
                this.stepMessage = stepMessage;
                this.prefixIdx = prefixIdx;
            }

            public int PosBack { get => posBack; }
            public int MatchLen { get => matchLen; }
            public bool NewBest { get => newBest; }
            public string Output { get => output;}
            public int StartPos { get => startPos; }
            public string StepMessage { get => stepMessage; }
            public int PrefixIdx { get => prefixIdx; }
            public bool DoAdd { get => doAdd; }
        }

    }
}
