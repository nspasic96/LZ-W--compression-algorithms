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
    public partial class Form2 : Form
    {
        public Form2(string input, int position, int windowSize, List<StepInfo> infos)
        {
            InitializeComponent();
            this.position = position;
            this.input = input;
            this.windowSize = windowSize;
            this.infos = infos;
            this.currIdx = -1;

            RestTextBox.Text = input;
            RestTextBox.SelectionStart = position;
            RestTextBox.SelectionLength = 1000;
            RestTextBox.SelectionColor = Color.Red;

            WindowTextBox.Text = input;
            int start = Math.Max(position - windowSize - 1, 0);
            WindowTextBox.SelectionStart = start;
            WindowTextBox.SelectionLength = start >= windowSize ? windowSize : position; 
            WindowTextBox.SelectionColor = Color.Red;

        }

        private void NextButton_Click(object sender, EventArgs e)
        {
            currIdx++;
            if(currIdx == infos.Count)
            {
                this.Close();
            } else
            {
                StepInfo info = infos[currIdx];
                CurrentMatchFirstTextBox.Text = input;
                CurrentMatchFirstTextBox.SelectionStart = info.StartPos - info.PosBack;
                CurrentMatchFirstTextBox.SelectionLength = info.MatchLen;
                CurrentMatchFirstTextBox.SelectionColor = Color.Red;

                CurrentMatchSecondTextBox.Text = input;
                CurrentMatchSecondTextBox.SelectionStart = info.StartPos;
                CurrentMatchSecondTextBox.SelectionLength = info.MatchLen;
                CurrentMatchSecondTextBox.SelectionColor = Color.Red;

                if (info.NewBest)
                {
                    CurrentOutputTextBox.Text = info.Output;
                    LongestMatchTextBox.Text = info.MatchLen.ToString();
                }
            }


        }
    }
}
