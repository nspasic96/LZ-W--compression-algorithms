using System;
using System.Collections.Generic;
using System.Text;
using static LZ_W__algortihms.Utils;

namespace LZ_W__algortihms
{
    internal class LZW : CompressionAlgorithm
    {
        private bool onFullDictReset;
        private int maxValue;
        private int totalBits;
        private List<LZWEntry> entries;
        private List<LZWEntry> prevEntries;

        private LZWEntry zeroEntry;
        private LZWEntry oneEntry;
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

            zeroEntry = new LZWEntry(0, "", "", "", "0");
            oneEntry = new LZWEntry(1, "", "", "", "1");

            this.statistics.Add(new AlgorithmStatistic("LZW statistics param", "value of param"));
        }

        //returns true when dictionary was restarted
        private bool handleNewEntry(string current, string next, string output, string addToDict)
        {
            if(maxValue > entries.Count)
            {
                LZWEntry newOne = new LZWEntry(entries.Count, current, next, output, addToDict);
                entries.Add(newOne);
                return false;
            } else
            {
                if (onFullDictReset)
                {
                    entries = new List<LZWEntry>();
                    entries.Add(zeroEntry);
                    entries.Add(oneEntry);
                    return true;
                }
                return false;
            }
        }

        protected override List<StepInfo> nextStep()
        {
            prevEntries = entries.ConvertAll(e => new LZWEntry(e.DictIdx,e.Current,e.Next,e.Output,e.AddToDict));

            List<StepInfo> stepInfos = new List<StepInfo>();
            entries.Reverse();

            string current = "";
            string next = "";
            string o = "";
            string stepMessage = "";
            int move = 0;
            bool doAdd = false;

            foreach (var entry in entries)
            {
                int match = rawInput.IndexOf(entry.AddToDict, currPossition);
                if (match == currPossition)
                {
                    current = entry.AddToDict;
                    o = toBinaryString(entry.DictIdx);
                    move = entry.AddToDict.Length;
                    if (currPossition + entry.AddToDict.Length < totalLen)
                    {
                        next = rawInput.Substring(currPossition + entry.AddToDict.Length, 1);
                        entries.Reverse();
                        stepMessage = "Match found at index " + entry.DictIdx;
                        if (handleNewEntry(current, next, o, current + next))
                        {
                            stepMessage = "Match found at index " + entry.DictIdx + ". Dictionary is full so it will be restarted after this step.";
                            output.Append(o + " | ");
                        } else
                        {
                            if(maxValue == entries.Count)
                            {
                                stepMessage = "Match found at index " + entry.DictIdx + ". Dictionary is full so no further words will be added.";
                            }
                            else
                            {
                                stepMessage = "Match found at index " + entry.DictIdx + ". Adding matched word (" + entry.AddToDict + ") extended with next charachter (" + next + ")";
                                doAdd = true;
                            }
                            output.Append(o + " ");
                        }
                    } else
                    {
                        stepMessage = "Match found at index " + entry.DictIdx + ". Whole string is now matched.";
                        output.Append(o);
                    }
                    StepInfo si = new StepInfo(entry.DictIdx, entry.AddToDict.Length, currPossition, stepMessage, doAdd);
                    stepInfos.Add(si);

                    break;
                } else
                {
                    stepMessage = "No match found";
                    StepInfo si1 = new StepInfo(entry.DictIdx, 0, currPossition, stepMessage, entries.Count < maxValue);
                    stepInfos.Add(si1);
                }
            }

            currPossition += move;

            return stepInfos;
        }

        private string toBinaryString(int dictIdx)
        {
            List<string> binary = new List<string>();
            int orig = dictIdx;
            if(dictIdx == 0)
            {
                StringBuilder sb = new StringBuilder();
                for(int i=0; i< totalBits; i++)
                {
                    sb.Append("0");
                }
                return sb.ToString();
            }
            while (dictIdx > 0) 
            {
                string dig = (dictIdx % 2).ToString();
                binary.Add(dig);
                dictIdx = dictIdx / 2;
            }
            int c = binary.Count;
            for(int i=0; i< totalBits - c; i++)
            {
                binary.Add("0");
            }
            binary.Reverse();
            
            return string.Join("", binary.ToArray());
        }

        protected override void prepare()
        {
            entries = new List<LZWEntry>();
            entries.Add(zeroEntry);
            entries.Add(oneEntry);
            foreach (var p in parameters)
            {
                if (p.ParamName == "On full dictionary")
                {
                    onFullDictReset = (p.CurrValue == "Reset");
                }
                if (p.ParamName == "Number of redundant bits")
                {
                    totalBits = Int32.Parse(p.CurrValue) + 1 ;
                    maxValue = 1 << totalBits; // 2 ^ (totalLen)
                }
            }
        }

        protected override void visualization(List<StepInfo> stepInfos)
        {
            Form4 f4 = new Form4(rawInput, prevEntries, entries[entries.Count - 1], stepInfos);
            f4.ShowDialog();
        }
    }
}