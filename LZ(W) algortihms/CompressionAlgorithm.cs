﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static LZ_W__algortihms.Utils;
using System.Windows.Forms;
using System.Threading;
using System.Diagnostics;

namespace LZ_W__algortihms
{
    abstract class CompressionAlgorithm
    {
        protected List<AlgorithmStatistic> statistics;
        protected List<AlgorithmParameter> parameters;
        protected string rawInput;
        protected StringBuilder output;
        protected int currPosition;
        protected int totalLen;
        protected double totalBitsSent;
        protected Form visForm;

        public List<AlgorithmStatistic> Statistics { get => statistics; }
        public List<AlgorithmParameter> Parameters { get => parameters; }

        protected abstract List<StepInfo> nextStep();
        protected abstract void prepare();        
        protected abstract void visualization(List<StepInfo> stepInfos);
        protected virtual void checkInput() {}
                
        public void convert(string input, Label result, bool visualize)
        {
            //initialize buffers and auxilary variables
            try
            {
                if(input.Length == 0)
                {
                    throw new FormatException("Input string must not be empty.");
                }

                cleanAndPrepare(input);
                checkInput();
            } catch(FormatException fe)
            {
                MessageBox.Show(fe.Message);
                return;

            } catch(NotSupportedException nse)
            {
                MessageBox.Show(nse.Message);
                return;
            }

            double totalTime = 0;
            Stopwatch sw = new Stopwatch();

            int stepNum = 0;
            //main part of the conversion
            while (hasNextStep())
            {
                stepNum++;
                //the step
                sw.Start();
                List<StepInfo> stepResults = nextStep();
                sw.Stop();

                //take stopwatch measurements and reset it
                totalTime += sw.Elapsed.TotalMilliseconds;
                sw.Reset();

                if (visualize)
                {
                    visualization(stepResults);

                    //update output text box after every step
                    result.Text = this.output.ToString();
                    result.Refresh();
                }
            }
            if(visualize)
                visForm.Show();
            visForm = null;

            //add statistics and print final output
            statistics.Add(new AlgorithmStatistic("Time elapsed(ms)", (totalTime).ToString()));
            statistics.Add(new AlgorithmStatistic("Compression ratio", (totalBitsSent / totalLen).ToString()));
            result.Text = this.output.ToString();
            result.Refresh();
        }

        public void updateParameter(int i, string text)
        {
            if(parameters[i].PT == ParameterType.Text)
            {
                var old = parameters[i];
                old.CurrValue = text;
                parameters[i] = old;
            } else if(parameters[i].PT == ParameterType.List)
            {
                var old = parameters[i];
                if (old.Values.Contains(text))
                {
                    old.CurrValue = text;
                    parameters[i] = old;
                }
            }
        }
        protected CompressionAlgorithm() { }
        protected bool hasNextStep()
        {
            return currPosition < totalLen;
        }

        private void cleanAndPrepare(string input)
        {
            this.rawInput = input;
            totalLen = input.Length;
            
            //position of the first character of the substring that hasn't been matched yet
            currPosition = 0;

            output = new StringBuilder();
            statistics = new List<AlgorithmStatistic>();

            //abstract function, every algorithm needs to set its own variables in this function
            prepare();
        }

    }
}
