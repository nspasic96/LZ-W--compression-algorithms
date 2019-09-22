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
    public partial class LZWVisForm : Form
    {

        private List<List<LZWEntry>> entriesStack;
        private List<LZWEntry> newOneStack;
        private List<List<StepInfo>> stepInfosStack;
        private int currStep;
        private bool currStepCompleted;
        private string buttonText;

        public LZWVisForm(string input)
        {
            InitializeComponent();

            entriesStack = new List<List<LZWEntry>>();
            newOneStack = new List<LZWEntry>();
            stepInfosStack = new List<List<StepInfo>>();
            currStep = 0;
            InputTextBox.Text = input;
            currStepCompleted = true;
        }

        private void populateTableLayoutPanel(int n)
        {
            tableLayoutPanel1.Controls.Clear();

            int m = 5;

            Utils.splitTlp(this.tableLayoutPanel1, n, m);
            
            Label l1 = new Label();
            l1.Text = "Index";
            Label l2 = new Label();
            l2.Text = "Current";
            Label l3 = new Label();
            l3.Text = "Next";
            Label l4 = new Label();
            l4.Text = "Output";
            Label l5 = new Label();
            l5.Text = "Word";

            tableLayoutPanel1.Controls.Add(l1, 0, 0);
            tableLayoutPanel1.Controls.Add(l2, 1, 0);
            tableLayoutPanel1.Controls.Add(l3, 2, 0);
            tableLayoutPanel1.Controls.Add(l4, 3, 0);
            tableLayoutPanel1.Controls.Add(l5, 4, 0);

            int k = 1;
            foreach (var entry in entriesStack[currStep - 1])
            {
                Label l11 = new Label();
                l11.Text = entry.DictIdx.ToString();
                Label l12 = new Label();
                l12.Text = entry.Current;
                Label l13 = new Label();
                l13.Text = entry.Next;
                Label l14 = new Label();
                l14.Text = entry.Output;
                Label l15 = new Label();
                l15.Text = entry.AddToDict;

                tableLayoutPanel1.Controls.Add(l11, 0, k);
                tableLayoutPanel1.Controls.Add(l12, 1, k);
                tableLayoutPanel1.Controls.Add(l13, 2, k);
                tableLayoutPanel1.Controls.Add(l14, 3, k);
                tableLayoutPanel1.Controls.Add(l15, 4, k);

                k++;
            }
        }

        private void makeLayout(int n)
        {
            populateTableLayoutPanel(n);
            InputTextBox.SelectionStart = stepInfosStack[currStep-1][0].StartPos;
            InputTextBox.SelectionLength = 100;
            InputTextBox.SelectionColor = Utils.c1;
        }

        private void NextButton_Click(object sender, EventArgs e)
        {
            if (currStepCompleted)
            {
                this.currIdx = -1;
                currStep++;
                if (currStep <= stepInfosStack.Count)
                {
                    unsetPrevStep();
                    makeLayout(Math.Max(entriesStack[currStep-1].Count+3, 20));
                    this.StepNumberTextBox.Text = this.currStep.ToString();
                    this.StepNumberTextBox.Refresh();

                    currStepCompleted = false;
                    infos = stepInfosStack[currStep - 1];
                    newOne = newOneStack[currStep - 1];
                    cnt = entriesStack[currStep - 1].Count;

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

        private void unsetPrevStep()
        {
            InputTextBox.SelectionColor = Color.Gray;
            MessageTextBox.Text = "";
        }

        private void update()
        {
            currIdx++;
            buttonText = "Next";
            if (infos.Count == currIdx)
            {
                currStepCompleted = true;
                buttonText = "Next step";
                if (currStep == stepInfosStack.Count)
                {
                    buttonText = "Close form";
                }

                if (infos[infos.Count - 1].DoAdd)
                {
                    Label l11 = new Label();
                    l11.Text = newOne.DictIdx.ToString();
                    Label l12 = new Label();
                    l12.Text = newOne.Current;
                    Label l13 = new Label();
                    l13.Text = newOne.Next;
                    Label l14 = new Label();
                    l14.Text = newOne.Output;
                    l12.BackColor = Utils.c2;
                    Label l15 = new Label();
                    l15.Text = newOne.AddToDict;
                    l14.BackColor = Utils.c1;

                    tableLayoutPanel1.Controls.Add(l11, 0, cnt + 1);
                    tableLayoutPanel1.Controls.Add(l12, 1, cnt + 1);
                    tableLayoutPanel1.Controls.Add(l13, 2, cnt + 1);
                    tableLayoutPanel1.Controls.Add(l14, 3, cnt + 1);
                    tableLayoutPanel1.Controls.Add(l15, 4, cnt + 1);
                }
            }
            else if (currIdx<infos.Count)
            {
                if(infos.Count == currIdx + 1 && !infos[infos.Count - 1].DoAdd)
                {
                    currStepCompleted = true;
                    buttonText = "Next step";
                    if (currStep == stepInfosStack.Count)
                    {
                        buttonText = "Close form";
                    }
                }

                StepInfo si = infos[currIdx];
                if (currIdx < infos.Count - 1)
                {
                    var x = tableLayoutPanel1.GetControlFromPosition(4, si.PrefixIdx + 1);
                    x.BackColor = Utils.c3;
                }
                else
                {
                    if (si.PrefixIdx != -1)
                    {
                        tableLayoutPanel1.GetControlFromPosition(4, si.PrefixIdx+1).BackColor = Utils.c2;
                        tableLayoutPanel1.GetControlFromPosition(0, si.PrefixIdx+1).BackColor = Utils.c1;
                    }
                    InputTextBox.Text = InputTextBox.Text;
                    InputTextBox.SelectionStart = infos[infos.Count - 1].StartPos;
                    InputTextBox.SelectionLength = infos[infos.Count - 1].MatchLen;
                    InputTextBox.SelectionColor = Color.Red;
                }
                MessageTextBox.Text = si.StepMessage;

            }

            this.NextButton.Text = buttonText;
            this.Refresh();

        }

        public void addStep(List<LZWEntry> entries, LZWEntry newOne, List<StepInfo> stepInfos)
        {
            entriesStack.Add(entries);
            newOneStack.Add(newOne);
            stepInfosStack.Add(stepInfos);
        }
    }
}
