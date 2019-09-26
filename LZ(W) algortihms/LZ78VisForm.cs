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
    public partial class LZ78VisForm : Form
    {
        private List<List<LZ78Entry>> entriesStack;
        private List<LZ78Entry> newOneStack;
        private List<List<StepInfo>> stepInfosStack;
        private int currStep;
        private bool currStepCompleted;
        private int lastColored;

        public LZ78VisForm(string input)
        {
            InitializeComponent();

            entriesStack = new List<List<LZ78Entry>>();
            newOneStack = new List<LZ78Entry>();
            stepInfosStack = new List<List<StepInfo>>();
            currStep = 0;
            InputTextBox.Text = input;
            currStepCompleted = true;
        }

        private void populateTableLayoutPanel()
        {
            Label l1 = new Label();
            l1.Text = "Step";
            Label l2 = new Label();
            l2.Text = "Output";
            Label l3 = new Label();
            l3.Text = "Position";
            Label l4 = new Label();
            l4.Text = "Word";

            tableLayoutPanel1.Controls.Add(l1, 0, 0);
            tableLayoutPanel1.Controls.Add(l2, 1, 0);
            tableLayoutPanel1.Controls.Add(l3, 2, 0);
            tableLayoutPanel1.Controls.Add(l4, 3, 0);

            int k = 1;
            foreach (var entry in entriesStack[currStep - 1])
            {
                Label l11 = new Label();
                l11.Text = entry.Step.ToString();
                Label l12 = new Label();
                l12.Text = entry.Output;
                Label l13 = new Label();
                l13.Text = entry.Pos.ToString();
                Label l14 = new Label();
                l14.Text = entry.Word;

                tableLayoutPanel1.Controls.Add(l11, 0, k);
                tableLayoutPanel1.Controls.Add(l12, 1, k);
                tableLayoutPanel1.Controls.Add(l13, 2, k);
                tableLayoutPanel1.Controls.Add(l14, 3, k);

                k++;
            }
        }

        private void makeLayout(int n)
        {
            int m = 4;
            Utils.splitTlp(tableLayoutPanel1, n, m);
            populateTableLayoutPanel();

            InputTextBox.SelectionStart = stepInfosStack[currStep - 1][0].StartPos;
            InputTextBox.SelectionLength = 100;
            InputTextBox.SelectionColor = Utils.c1;
        }

        private void Next_Click(object sender, EventArgs e)
        {
            if (currStepCompleted)
            {
                this.currIdx = -1;
                currStep++;
                if (currStep <= stepInfosStack.Count)
                {
                    currStepCompleted = false;
                    infos = stepInfosStack[currStep - 1];
                    newOne = newOneStack[currStep - 1];
                    cnt = entriesStack[currStep - 1].Count;

                    unsetPrevStep();
                    this.StepNumberTextBox.Text = this.currStep.ToString();
                    this.StepNumberTextBox.Refresh();

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
            ++this.currIdx;
            this.populateWithCurrentStepInfo();
            this.updateButtons();
        }
        public void addStep(List<LZ78Entry> entries, LZ78Entry newOne, List<StepInfo> stepInfos)
        {
            entriesStack.Add(entries);
            newOneStack.Add(newOne);
            stepInfosStack.Add(stepInfos);
        }
        private void populateWithCurrentStepInfo()
        {
            if (lastColored != -1)
            {
                var a = tableLayoutPanel1.GetControlFromPosition(3, lastColored);
                var b = tableLayoutPanel1.GetControlFromPosition(0, lastColored);

                a.BackColor = this.BackColor;
                b.BackColor = this.BackColor;
            }

            if (infos.Count == currIdx)
            {
                if (infos[infos.Count - 1].DoAdd)
                {
                    Label l11 = new Label();
                    l11.Text = newOne.Step.ToString();
                    Label l12 = new Label();
                    l12.Text = newOne.Output;
                    l12.BackColor = Utils.c2;
                    Label l13 = new Label();
                    l13.Text = newOne.Pos.ToString();
                    Label l14 = new Label();
                    l14.Text = newOne.Word;
                    l14.BackColor = Utils.c1;

                    tableLayoutPanel1.Controls.Add(l11, 0, cnt + 1);
                    tableLayoutPanel1.Controls.Add(l12, 1, cnt + 1);
                    tableLayoutPanel1.Controls.Add(l13, 2, cnt + 1);
                    tableLayoutPanel1.Controls.Add(l14, 3, cnt + 1);
                }
            }
            else if (currIdx < infos.Count)
            {
                StepInfo si = infos[currIdx];
                if (currIdx < infos.Count - 1)
                {
                    Label l = tableLayoutPanel1.GetControlFromPosition(3, si.PrefixIdx) as Label;
                    l.BackColor = Utils.c3;
                    lastColored = si.PrefixIdx;
                }
                else
                {
                    if (si.PrefixIdx != -1)
                    {
                        tableLayoutPanel1.GetControlFromPosition(3, si.PrefixIdx).BackColor = Utils.c2;
                        tableLayoutPanel1.GetControlFromPosition(0, si.PrefixIdx).BackColor = Utils.c2;
                        lastColored = si.PrefixIdx;
                    }
                    InputTextBox.Text = InputTextBox.Text;
                    InputTextBox.SelectionStart = infos[infos.Count - 1].StartPos;
                    InputTextBox.SelectionLength = infos[infos.Count - 1].MatchLen;
                    InputTextBox.SelectionColor = Utils.c1;
                }
                MessageTextBox.Text = si.StepMessage;
            }
        }

        private void unsetPrevStep()
        {
            lastColored = -1;
            InputTextBox.SelectionColor = Color.Gray;
            MessageTextBox.Text = "";
            makeLayout(Math.Max(entriesStack[currStep - 1].Count + 3, 20));
        }
        private void prepareForCurrentStep()
        {
            InputTextBox.SelectionStart = stepInfosStack[currStep - 1][0].StartPos;
            InputTextBox.SelectionLength = 100;
            InputTextBox.SelectionColor = Utils.c1;

            for (int i = 0; i < tableLayoutPanel1.Controls.Count / 4; i++)
            {
                var a = tableLayoutPanel1.GetControlFromPosition(3, i);
                var b = tableLayoutPanel1.GetControlFromPosition(0, i);
                if (a != null)
                {
                    a.BackColor = this.BackColor;
                    b.BackColor = this.BackColor;
                }
            }
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
           if (this.currIdx == 0)
           {
               --this.currStep;
               this.StepNumberTextBox.Text = this.currStep.ToString();
               this.infos = this.stepInfosStack[this.currStep - 1];
               this.newOne = newOneStack[this.currStep - 1];
               this.cnt = this.entriesStack[currStep - 1].Count;
               this.currIdx = this.infos.Count;
           }

           this.unsetPrevStep();
           --this.currIdx;

           this.prepareForCurrentStep();
           this.populateWithCurrentStepInfo();
           this.updateButtons();
        }
    }
}
