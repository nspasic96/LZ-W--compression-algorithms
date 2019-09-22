using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static LZ_W__algortihms.Utils;

namespace LZ_W__algortihms
{
    public partial class LZ77VisForm : Form
    {
        private List<List<StepInfo>> stepInfosStack;
        private List<int> positionsStack;
        private int currStep;
        private bool currStepCompleted;
        private string buttonText;
        public LZ77VisForm(string input, int windowSize)
        {
            InitializeComponent();
            this.input = input;
            this.windowSize = windowSize;

            RestTextBox.Text = input;
            WindowTextBox.Text = input;

            currStep = 0;
            currStepCompleted = true;

            stepInfosStack = new List<List<StepInfo>>();
            positionsStack = new List<int>();

        }

        private void NextButton_Click(object sender, EventArgs e)
        {
            if (currStepCompleted)
            {
                this.currIdx = -1;
                currStep++;
                if(currStep <= stepInfosStack.Count)
                {
                    this.StepNumberTextBox.Text = this.currStep.ToString();
                    this.StepNumberTextBox.Refresh();

                    currStepCompleted = false;
                    infos = stepInfosStack[currStep-1];
                    position = positionsStack[currStep-1];

                    unsetPrevStep();

                    RestTextBox.SelectionStart = position;
                    RestTextBox.SelectionLength = 1000;
                    RestTextBox.SelectionColor = Utils.c1;

                    int start = Math.Max(position - windowSize, 0);
                    WindowTextBox.SelectionStart = start;
                    WindowTextBox.SelectionLength = start >= windowSize ? windowSize : position;
                    WindowTextBox.SelectionColor = Utils.c1;

                   update();
                }
                else
                {
                    this.Close();
                }
            }
            else
            {
                update();                
            }
        }

        public void update()
        {
            currIdx++;
            buttonText = "Next";
            if (currIdx == infos.Count-1)
            {
                currStepCompleted = true;
                buttonText = "Next step";
                if(currStep == stepInfosStack.Count)
                {
                    buttonText = "Close form";
                }
            }
            this.NextButton.Text = buttonText;
            this.NextButton.Refresh();

            StepInfo info = infos[currIdx];

            CurrentMatchFirstTextBox.Text = input;
            CurrentMatchFirstTextBox.SelectionStart = info.StartPos - info.PosBack;
            CurrentMatchFirstTextBox.SelectionLength = info.MatchLen;
            CurrentMatchFirstTextBox.SelectionColor = Utils.c1;

            if (info.MatchLen == 0 && currIdx > 0)
            {
                CurrentMatchFirstTextBox.SelectionStart = info.StartPos - info.PosBack;
                CurrentMatchFirstTextBox.SelectionLength = 1;
                CurrentMatchFirstTextBox.SelectionColor = Utils.c3;
            }

            CurrentMatchSecondTextBox.Text = input;
            CurrentMatchSecondTextBox.SelectionStart = info.StartPos;
            CurrentMatchSecondTextBox.SelectionLength = info.MatchLen;
            CurrentMatchSecondTextBox.SelectionColor = Utils.c1;

            MessageTextBox.Text = info.StepMessage;

            if (info.MatchLen == 0 && currIdx > 0)
            {
                CurrentMatchSecondTextBox.SelectionStart = info.StartPos;
                CurrentMatchSecondTextBox.SelectionLength = 1;
                CurrentMatchSecondTextBox.SelectionColor = Utils.c3;
            }

            if (info.NewBest)
            {
                CurrentOutputTextBox.Text = info.Output;
                LongestMatchTextBox.Text = info.MatchLen.ToString();
            }
        }

        private void unsetPrevStep()
        {

            WindowTextBox.SelectionColor = Color.Black;
            RestTextBox.SelectionColor = Color.Black;

            CurrentMatchFirstTextBox.SelectionColor = Color.Black;
            CurrentMatchSecondTextBox.SelectionColor = Color.Black;
            CurrentOutputTextBox.Text = "";
            LongestMatchTextBox.Text = "";
        }

        public void addStep(int position, List<StepInfo> stepInfos)
        {
            stepInfosStack.Add(stepInfos);
            positionsStack.Add(position);
        }
    }
}
