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
            if (this.currStepCompleted)
            {
                this.currIdx = -1;
                ++this.currStep;
                if (this.currStep <= this.stepInfosStack.Count)
                {
                    this.StepNumberTextBox.Text = this.currStep.ToString();
                    this.StepNumberTextBox.Refresh();
                    this.currStepCompleted = false;
                    this.infos = this.stepInfosStack[this.currStep - 1];
                    this.position = this.positionsStack[this.currStep - 1];
                    this.unsetPrevStep();
                    this.prepareForCurrentStep();
                    this.update();
                }
                else
                    this.Close();
            }
            else
                this.update();
        }

        public void update()
        {
            ++this.currIdx;
            this.populateWithCurrentStepInfo();
            this.updateButtons();
        }

        private void populateWithCurrentStepInfo()
        {
            Utils.StepInfo info = this.infos[this.currIdx];

            this.CurrentMatchFirstTextBox.Text = this.input;
            this.CurrentMatchSecondTextBox.Text = this.input;

            this.CurrentMatchFirstTextBox.SelectionStart = 0;
            this.CurrentMatchFirstTextBox.SelectionLength = input.Length;
            this.CurrentMatchFirstTextBox.SelectionColor = Color.Black;

            this.CurrentMatchSecondTextBox.SelectionStart = 0;
            this.CurrentMatchSecondTextBox.SelectionLength = input.Length;
            this.CurrentMatchSecondTextBox.SelectionColor = Color.Black;

            if (info.MatchLen == 0 && this.currIdx > 0)
            {
                this.CurrentMatchFirstTextBox.SelectionStart = info.StartPos - info.PosBack;
                this.CurrentMatchFirstTextBox.SelectionLength = 1;
                this.CurrentMatchFirstTextBox.SelectionColor = Utils.c3;

                this.CurrentMatchSecondTextBox.SelectionStart = info.StartPos;
                this.CurrentMatchSecondTextBox.SelectionLength = 1;
                this.CurrentMatchSecondTextBox.SelectionColor = Utils.c3;
            }
            else
            {
                this.CurrentMatchFirstTextBox.SelectionStart = info.StartPos - info.PosBack;
                this.CurrentMatchFirstTextBox.SelectionLength = info.MatchLen;
                this.CurrentMatchFirstTextBox.SelectionColor = Utils.c1;

                this.CurrentMatchSecondTextBox.SelectionStart = info.StartPos;
                this.CurrentMatchSecondTextBox.SelectionLength = info.MatchLen;
                this.CurrentMatchSecondTextBox.SelectionColor = Utils.c1;

            }
            this.MessageTextBox.Text = info.StepMessage;

            if (info.NewBest)
            {
                this.CurrentOutputTextBox.Text = info.Output;
                this.LongestMatchTextBox.Text = info.MatchLen.ToString();
            }
            else
            {
                int curr = this.currIdx-1;
                while (!infos[curr].NewBest)
                {
                    curr--;
                }
                this.CurrentOutputTextBox.Text = infos[curr].Output;
                this.LongestMatchTextBox.Text = infos[curr].MatchLen.ToString();
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

        
        private void prepareForCurrentStep()
        {
            this.RestTextBox.SelectionStart = this.position;
            this.RestTextBox.SelectionLength = input.Length;
            this.RestTextBox.SelectionColor = Utils.c1;
            int num = Math.Max(this.position - this.windowSize, 0);
            this.WindowTextBox.SelectionStart = num;
            this.WindowTextBox.SelectionLength = num >= this.windowSize ? this.windowSize : this.position - num;
            this.WindowTextBox.SelectionColor = Utils.c1;
        }


        private void updateButtons()
        {
            string str1 = "Next";
            if (this.currIdx == this.infos.Count - 1)
            {
                this.currStepCompleted = true;
                str1 = "Next step";
                if (this.currStep == this.stepInfosStack.Count)
                    str1 = "Close form";
            }
            else
                this.currStepCompleted = false;
            string str2 = "Back";
            if (this.currIdx == 0)
                str2 = "Previous step";
            if (this.currStep == 1 && this.currIdx == 0)
            {
                str2 = "Back";
                this.BackButton.Enabled = false;
            }
            else
                this.BackButton.Enabled = true;
            this.BackButton.Text = str2;
            this.NextButton.Text = str1;
            this.Refresh();
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            this.unsetPrevStep();
            if (this.currIdx == 0)
            {
                --this.currStep;
                this.StepNumberTextBox.Text = this.currStep.ToString();
                this.infos = this.stepInfosStack[this.currStep - 1];
                this.position = this.positionsStack[this.currStep - 1];
                this.currIdx = this.infos.Count;
            }
            --this.currIdx;
            this.prepareForCurrentStep();
            this.populateWithCurrentStepInfo();
            this.updateButtons();
        }
    }
}
