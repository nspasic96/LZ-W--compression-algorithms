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

            this.statistics.Add(new AlgorithmStatistic("LZ78 statistics param", "value of param"));
        }
        protected override void prepare()
        {
            entries = new List<LZ78Entry>();
        }

        protected override List<StepInfo> nextStep()
        {
            entries.Reverse();

            string newWord;
            int step;
            int pos;
            string o;
            LZ78Entry newEntry = new LZ78Entry();
            bool entryAdded = false;
            foreach(var entry in entries)
            {
                int match = rawInput.IndexOf(entry.Word, currPossition, entry.Word.Length);
                if(match != -1)
                {
                    newWord = rawInput.Substring(currPossition, entry.Word.Length + 1);
                    step = entries.Count + 1;
                    pos = currPossition;
                    o = "(" + entry.Pos + "," + rawInput.Substring(match + entry.Word.Length) + ") ";

                    output.Append(o);
                    newEntry = new LZ78Entry(newWord, o, step, pos);

                    entryAdded = true;
                    break;
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

            entries.Add(newEntry);

            return null;
        }

        protected override void visualization(List<StepInfo> stepInfos)
        {
            throw new System.NotImplementedException();
        }
    }
}