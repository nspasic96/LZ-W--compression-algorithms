using System;
using System.Collections.Generic;
using System.Text;
using static LZ_W__algortihms.Utils;

namespace LZ_W__algortihms
{
    class LZ78 : CompressionAlgorithm
    {

        private List<LZ78Entry> entries;
        private List<LZ78Entry> prevEntries;
        public LZ78()
        {
            var p = new List<AlgorithmParameter>();

            this.parameters = p;

            this.statistics.Add(new AlgorithmStatistic("LZ78 statistics param", "value of param"));
        }
        protected override void prepare()
        {
            entries = new List<LZ78Entry>();
        }

        protected override List<StepInfo> nextStep()
        {
            prevEntries = entries.ConvertAll(e => new LZ78Entry(e.Word, e.Output, e.Step, e.Pos));

            List<StepInfo> stepInfos = new List<StepInfo>();
            entries.Reverse();

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
                int match = rawInput.IndexOf(entry.Word, currPossition, Math.Min(entry.Word.Length, totalLen-currPossition));
                if(match != -1)
                {
                    step = entries.Count + 1;
                    pos = currPossition;
                    longPreIdx = entry.Step;
                    if(currPossition + entry.Word.Length == totalLen)
                    {
                        newWord = rawInput.Substring(currPossition, entry.Word.Length);
                        o = "(" + entry.Step + "," + "-) ";
                        matchLen = entry.Word.Length;
                        stepMessage = "Prefix found (entry at position {0}) and no entry will be added because whole string is processed.";
                        stepMessage = string.Format(stepMessage, entry.Step);
                        doAdd = false;
                    } else
                    {
                        newWord = rawInput.Substring(currPossition, entry.Word.Length + 1);
                        o = "(" + entry.Step + "," + rawInput.Substring(currPossition + entry.Word.Length, 1) + ") ";
                        matchLen = entry.Word.Length + 1;
                        stepMessage = "Prefix found (entry at position {0}) and new entry will be added (matched entry({1}) + last character after match({2}))";
                        stepMessage = string.Format(stepMessage, entry.Step, rawInput.Substring(currPossition, entry.Word.Length), rawInput.Substring(currPossition + entry.Word.Length, 1 ));
                    }

                    output.Append(o);
                    newEntry = new LZ78Entry(newWord, o, step, pos);

                    entryAdded = true;
                    break;
                } else
                {
                    stepMessage = "No match detected";
                    StepInfo si1 = new StepInfo(entry.Step, 0, currPossition, stepMessage, o, false);
                    stepInfos.Add(si1);
                }
            }
            entries.Reverse();

            if (!entryAdded)
            {
                newWord = rawInput.Substring(currPossition, 1);
                step = entries.Count + 1;
                pos = currPossition;
                o = "(0," + rawInput.Substring(currPossition, 1) + ") ";

                output.Append(o);

                newEntry = new LZ78Entry(newWord, o, step, pos);
            }

            if(longPreIdx == -1)
            {
                stepMessage = "Prefix not found, adding word of length 1 to the dictionary";
            } 

            StepInfo si = new StepInfo(longPreIdx, matchLen , currPossition, stepMessage, o, doAdd);
            stepInfos.Add(si);

            entries.Add(newEntry);
            currPossition += newEntry.Word.Length;

            return stepInfos;
        }

        protected override void visualization(List<StepInfo> stepInfos)
        {
            Form3 f3 = new Form3(rawInput, prevEntries, entries[entries.Count - 1], stepInfos);
            f3.ShowDialog();
        }
    }
}