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
            RestTextBox.SelectionColor = Utils.c1;

            WindowTextBox.Text = input;
            int start = Math.Max(position - windowSize, 0);
            WindowTextBox.SelectionStart = start;
            WindowTextBox.SelectionLength = start >= windowSize ? windowSize : position; 
            WindowTextBox.SelectionColor = Utils.c1;

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
                CurrentMatchFirstTextBox.SelectionColor = Utils.c1;

                if(info.MatchLen == 0 && currIdx > 0)
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



        }
    }
}
