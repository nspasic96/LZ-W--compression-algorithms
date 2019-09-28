using System.Collections.Generic;
using static LZ_W__algortihms.Utils;
using System.Text;
using System;

namespace LZ_W__algortihms
{
    class LZ77 : CompressionAlgorithm
    {
        private int windowSize;
        private int prevPosition;
    
        public LZ77()
        {
            var p = new List<AlgorithmParameter>();
            
            AlgorithmParameter windowSize = new AlgorithmParameter("Window size", "3");
            p.Add(windowSize);

            AlgorithmParameter numChars = new AlgorithmParameter("Number of different characters", "2");
            p.Add(numChars);


            this.parameters = p;
        }

        protected override List<StepInfo> nextStep()
        {
            List<StepInfo> infos = new List<StepInfo>();

            //store position before step to show it in visualization
            prevPosition = currPosition;            

            //default match - only one character
            string defaultStepMessage = currPosition == 0 ? "First character never matches because window does not exist." : "Default 'match' is of length 0 meaning that new character is encountered"; 
            StepInfo s = new StepInfo(Math.Min(currPosition, windowSize), 0, currPosition, defaultStepMessage, true, "<0," + rawInput[currPosition] + ">");
            infos.Add(s);
            
            int longest = 0;
            int backLongest = -1;

            //try every index in window as start index for longest matching
            for (int start=Math.Max(0,currPosition-windowSize); start<currPosition ; start++)
            {
                int len = 0;
                while(currPosition + len < totalLen && rawInput[start+len] == rawInput[currPosition + len])
                {
                    len++;
                }

                bool newLongest = false;

                int back = currPosition - start;

                //longer match detected
                if (len > longest)
                {
                    longest = len;
                    newLongest = true;
                    backLongest = back;
                }

                string stepMessage;

                //match detected
                if(len > 0)
                {
                    if (newLongest)
                    {
                        stepMessage = "New longest match found starting {0} positions back from current poisition ({1})";
                        stepMessage = string.Format(stepMessage, back, currPosition);
                    } else
                    {
                        stepMessage = "New match found starting {0} positions back from current poisition ({1}) but the longer(or same length) match already exists";
                        stepMessage = string.Format(stepMessage, back, currPosition);
                    }
                }
                else
                {
                    stepMessage = "No match found";
                }
                StepInfo s1 = new StepInfo(back, len, currPosition, stepMessage, newLongest, "<1," + back + "," + len + ">");
                infos.Add(s1);
            }

            //set output depending on whether any match was detected
            if(longest > 0)
            {
                output.Append("<1," + backLongest + "," + longest + ">");

                totalBitsSent += Math.Ceiling(Math.Log(backLongest, 2));
                totalBitsSent += Math.Ceiling(Math.Log(longest, 2));
                currPosition += longest;

            } else
            {
                output.Append("<0," + rawInput[currPosition++].ToString() + ">");

                totalBitsSent += logNumChars;
            }

            //this one is for first bit that tells us whether any match was found
            totalBitsSent += 1;
             
            return infos;
        }

        protected override void prepare()
        {
            foreach (var p in parameters)
            {
                if (p.ParamName == "Window size")
                {
                    bool succ = Int32.TryParse(p.CurrValue, out windowSize);
                    if (!succ || windowSize <= 0)
                    {
                        throw new FormatException("Window size must be positive intger.");
                    }
                }
                if (p.ParamName == "Number of different characters")
                {
                    bool succ = Int32.TryParse(p.CurrValue, out logNumChars);
                    if (!succ || logNumChars <= 0)
                    {
                        throw new FormatException("Number of different characters must be positive intger.");
                    }
                    logNumChars = Convert.ToInt32(Math.Ceiling(Math.Log(logNumChars, 2)));
                }
            }
            totalBitsSent = 0;
        }

        protected override void visualization(List<StepInfo> stepInfos)
        {
            if(visForm == null)
            {
                visForm = new LZ77VisForm(rawInput, windowSize);
            }

            (visForm as LZ77VisForm).addStep(prevPosition, stepInfos);
        }
    }
}
