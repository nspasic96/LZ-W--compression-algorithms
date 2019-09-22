using System;
using System.Collections.Generic;
using System.Text;
using static LZ_W__algortihms.Utils;

namespace LZ_W__algortihms
{
    internal class LZW : CompressionAlgorithm
    {
        private List<LZWEntry> entries;
         
        private bool onFullDictReset;
        private int maxValue;
        private int totalBits;
        private int totalCh;
        private bool newOneAdded;

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
            totalCh = 0;

        }

        protected override List<StepInfo> nextStep()
        {
            //counter of the total number of characters in the output (with extended length)
            totalCh++;
            
            List<StepInfo> stepInfos = new List<StepInfo>();

            //iterating in reverse order because that is the most efficient way
            entries.Reverse();

            //auxiliary variables
            string current = "";
            string next = "";
            string o = "";
            string stepMessage = "";
            int move = 0;
            bool doAdd = false;
            newOneAdded = false;

            foreach (var entry in entries)
            {
                //index of first occurance of entry.AddToDict in rawInput after currPosition
                int match = rawInput.IndexOf(entry.AddToDict, currPosition);

                //match will be equal to currPosition if and only if rest of the input starts with entry.AddToDict 
                if (match == currPosition)
                {
                    current = entry.AddToDict;
                    o = toBinaryString(entry.DictIdx);

                    //after this step currPosition will be incremented by move value
                    move = entry.AddToDict.Length;

                    //if after match there are more characters, we handle new entry
                    if (currPosition + entry.AddToDict.Length < totalLen)
                    {
                        next = rawInput.Substring(currPosition + entry.AddToDict.Length, 1);

                        //reverse back so that added entry is at the correct posistion 
                        entries.Reverse();


                        stepMessage = "Match found at index " + entry.DictIdx;

                        //if dictionary was full (and onFullDictReset is true) it will be restarted 'after' this step and '|' is added to output to denote it
                        if (handleNewEntry(current, next, o, current + next, out newOneAdded))
                        {
                            stepMessage = "Match found at index " + entry.DictIdx + ". Dictionary is full so it will be restarted after this step.";
                            output.Append(o + " | ");
                        } else
                        {
                            //if dictionary is full but onFullDictReset is false
                            if (maxValue == entries.Count)
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
                        entries.Reverse();
                        stepMessage = "Match found at index " + entry.DictIdx + ". Whole string is now matched.";
                        output.Append(o);
                    }
                    StepInfo si = new StepInfo(entry.DictIdx, entry.AddToDict.Length, currPosition, stepMessage, doAdd);
                    stepInfos.Add(si);

                    break;
                } else
                {
                    stepMessage = "No match found";
                    StepInfo si1 = new StepInfo(entry.DictIdx, 0, currPosition, stepMessage, entries.Count < maxValue);
                    stepInfos.Add(si1);
                }
            }

            totalBitsSent = totalCh * totalBits;
            currPosition += move;

            return stepInfos;
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
                    bool succ = Int32.TryParse(p.CurrValue, out totalBits);
                    if(!succ || totalBits < 0)
                    {
                        throw new FormatException("Number of redundant bits must be non negative integer.");
                    }
                    totalBits++;
                    maxValue = 1 << totalBits; // 2 ^ (totalLen)
                }
            }
            totalCh = 0;
        }

        protected override void visualization(List<StepInfo> stepInfos, int stepNum)
        {
            if (visForm == null)
            {
                visForm = new LZWVisForm(rawInput);
            }
            if(newOneAdded)
                (visForm as LZWVisForm).addStep(entries.GetRange(0, entries.Count - 1), entries[entries.Count - 1], stepInfos);
            else
                (visForm as LZWVisForm).addStep(entries, entries[entries.Count - 1], stepInfos);

        }

        //returns true when dictionary was restarted
        private bool handleNewEntry(string current, string next, string output, string addToDict, out bool newOneAdded)
        {
            //if there is free space in dictionary, just add new etnry
            if (maxValue > entries.Count)
            {
                LZWEntry newOne = new LZWEntry(entries.Count, current, next, output, addToDict);
                entries.Add(newOne);
                newOneAdded = true;
                return false;
            }
            else
            {
                newOneAdded = false;
                //reset dictionary if onFullDictReset is set to true and add default entries
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
    }
}