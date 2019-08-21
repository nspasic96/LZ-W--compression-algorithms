using System.Collections.Generic;
using static LZ_W__algortihms.Utils;
using System.Text;
using System;

namespace LZ_W__algortihms
{
    class LZ77 : CompressionAlgorithm
    {
        private int currPossition;
        private int totalLen;
        private int windowSize;
        private int prevPosition;
    
        public LZ77()
        {
            var p = new List<AlgorithmParameter>();
            AlgorithmParameter windowSize = new AlgorithmParameter("Window size", "3");
            p.Add(windowSize);
            this.parameters = p;

            this.statistics.Add(new AlgorithmStatistic("LZ77 statistics param", "value of param"));
        }

        protected override bool hasNextStep()
        {
            return currPossition < totalLen;
        }

        protected override void processStepResults(List<StepInfo> stepInfos, bool[] input)
        {

        }
        protected override List<StepInfo> nextStep()
        {
            List<StepInfo> infos = new List<StepInfo>();
            prevPosition = currPossition;
            
            StepInfo s = new StepInfo(0, 0, prevPosition, true, "<0," + (input[currPossition] ? 1 : 0).ToString() + ">");
            infos.Add(s);
            if(currPossition == 0)
            {
                output.Append("<0," + (input[0] ? 1 : 0).ToString() + ">");
                currPossition++;
            } else
            {

                int longest = 0;
                int back = -1;

                for (int start=Math.Max(0,currPossition-windowSize); start<currPossition ; start++)
                {
                    int len = 0;
                    while(currPossition + len < totalLen && input[start+len] == input[currPossition + len])
                    {
                        len++;
                    }

                    bool newLongest = false;

                    if (len > longest)
                    {
                        longest = len;
                        back = currPossition - start;
                        newLongest = true;
                    }

                    StepInfo s1 = new StepInfo(back, len, prevPosition, newLongest, "<1," + back + "," + len + ">");
                    infos.Add(s1);
                }
                if(back != -1)
                {
                    output.Append("<1," + back + "," + longest + ">");
                    currPossition += longest;

                } else
                {
                    output.Append("<0," + (input[currPossition++] ? 1 : 0).ToString() + ">");
                }

            }
            return infos;
        }

        protected override void resetAndPrepare()
        {
            currPossition = 0;
            totalLen = input.Length;
            foreach(var p in parameters)
            {
                if(p.ParamName == "Window size")
                {
                    windowSize = Int32.Parse(p.CurrValue);
                }
            }
            output = new StringBuilder();
        }

        protected override void visualization(string input, List<StepInfo> stepInfos)
        {
            Form2 f2 = new Form2(input, prevPosition, windowSize, stepInfos);
            f2.ShowDialog();
        }
    }
}
