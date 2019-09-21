using System;
using System.Collections.Generic;
using System.Text;
using static LZ_W__algortihms.Utils;

namespace LZ_W__algortihms
{
    class LZ78 : CompressionAlgorithm
    {

        private List<LZ78Entry> entries;
        public LZ78()
        {
            var p = new List<AlgorithmParameter>();

            this.parameters = p;
        }
        protected override void prepare()
        {
            totalBitsSent = 0;
            entries = new List<LZ78Entry>();
        }

        protected override List<StepInfo> nextStep()
        {
            List<StepInfo> stepInfos = new List<StepInfo>();

            //iterating in reverse order because that is the most efficient way
            entries.Reverse();

            //auxiliary variables
            string newWord;
            int step;
            int pos;
            string o = "";
            string stepMessage = "";
            int longPreIdx = -1;
            int matchLen = 1;
            bool doAdd = true;
            LZ78Entry newEntry = new LZ78Entry();
            bool entryAdded = false;

            foreach(var entry in entries)
            {
                //index of first occurance of entry.Word in rawInput after currPosition
                int match = rawInput.IndexOf(entry.Word, currPosition);

                //match will be equal to currPosition if and only if rest of the input starts with entry.Word 
                if (match == currPosition)
                {

                    step = entries.Count + 1;
                    pos = currPosition;

                    //because of the way that we add new words, if match was detected this is longest match
                    longPreIdx = entry.Step;

                    //if we reached the end of the string, no entry should be added to dictionary
                    if (currPosition + entry.Word.Length == totalLen)
                    {
                        newWord = rawInput.Substring(currPosition, entry.Word.Length);
                        o = "(" + entry.Step + "," + "-) ";
                        matchLen = entry.Word.Length;
                        stepMessage = "Prefix found (entry at position {0}) and no entry will be added because whole string is processed.";
                        stepMessage = string.Format(stepMessage, entry.Step);
                        doAdd = false;
                    } else
                    {
                        //this bit is last bit in o (the character we add in output that indicates next character after matched word)
                        totalBitsSent += 1;

                        newWord = rawInput.Substring(currPosition, entry.Word.Length + 1);
                        o = "(" + entry.Step + "," + rawInput.Substring(currPosition + entry.Word.Length, 1) + ") ";
                        matchLen = entry.Word.Length + 1;
                        stepMessage = "Prefix found (entry at position {0}) and new entry will be added (matched entry({1}) + last character after match({2}))";
                        stepMessage = string.Format(stepMessage, entry.Step, rawInput.Substring(currPosition, entry.Word.Length), rawInput.Substring(currPosition + entry.Word.Length, 1 ));
                    }

                    output.Append(o);
                    newEntry = new LZ78Entry(newWord, o, step, pos);

                    entryAdded = true;

                    //number of bits needed to represent index of matched word in binary
                    totalBitsSent += Math.Ceiling(Math.Log(entry.Step, 2));
                    break;
                } else
                {
                    stepMessage = "No match detected";
                    StepInfo si1 = new StepInfo(entry.Step, 0, currPosition, stepMessage, o, false);
                    stepInfos.Add(si1);
                }
            }

            //reverse list back to the original before adding new entry
            entries.Reverse();

            //if no match was found, add entry that matches just the current character
            if (!entryAdded)
            {
                newWord = rawInput.Substring(currPosition, 1);
                step = entries.Count + 1;
                pos = currPosition;
                o = "(0," + rawInput.Substring(currPosition, 1) + ") ";

                output.Append(o);

                //sending just 2 bits (0 and current character)
                totalBitsSent += 2;

                newEntry = new LZ78Entry(newWord, o, step, pos);

                stepMessage = "Prefix not found, adding word of length 1 to the dictionary";
            }
            
            StepInfo si = new StepInfo(longPreIdx, matchLen , currPosition, stepMessage, o, doAdd);
            stepInfos.Add(si);

            entries.Add(newEntry);
            currPosition += newEntry.Word.Length;

            return stepInfos;
        }

        protected override void visualization(List<StepInfo> stepInfos, int stepNum)
        {
            LZ78VisForm f3 = new LZ78VisForm(rawInput, entries.GetRange(0, entries.Count -1), entries[entries.Count - 1], stepInfos);
            f3.ShowDialog();
        }
    }
}