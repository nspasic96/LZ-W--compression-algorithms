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
    public partial class Form4 : Form
    {
        public Form4(string input, List<LZWEntry> entries, LZWEntry newOne, List<StepInfo> stepInfos)
        {
            InitializeComponent(); int m = 5;
            int n = Math.Max(entries.Count + 2, 20);

            tableLayoutPanel1.Controls.Clear();

            tableLayoutPanel1.ColumnCount = m;
            tableLayoutPanel1.RowCount = n;

            tableLayoutPanel1.ColumnStyles.Clear();
            tableLayoutPanel1.RowStyles.Clear();

            for (int i = 0; i < m; i++)
            {
                tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100 / m));
            }

            for (int j = 0; j < n; j++)
            {
                tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100 / n));
            }

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
            foreach (var entry in entries)
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
            MessageTextBox.Text = "Dictionary before this step";
            InputTextBox.Text = input;
            InputTextBox.SelectionStart = stepInfos[0].StartPos;
            InputTextBox.SelectionLength = input.Length;
            InputTextBox.SelectionColor = Color.Red;

            this.infos = stepInfos;
            this.newOne = newOne;
            this.cnt = entries.Count;
            currIdx = -1;
        }

        private void NextButton_Click(object sender, EventArgs e)
        {
            currIdx++;
            if (infos.Count == currIdx)
            {
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
                    l12.BackColor = Color.Yellow;
                    Label l15 = new Label();
                    l15.Text = newOne.AddToDict;
                    l14.BackColor = Color.Red;
                    
                    tableLayoutPanel1.Controls.Add(l11, 0, cnt + 1);
                    tableLayoutPanel1.Controls.Add(l12, 1, cnt + 1);
                    tableLayoutPanel1.Controls.Add(l13, 2, cnt + 1);
                    tableLayoutPanel1.Controls.Add(l14, 3, cnt + 1);
                    tableLayoutPanel1.Controls.Add(l15, 4, cnt + 1);
                }
            }
            else if (infos.Count == currIdx - 1)
            {
                this.Close();
                return;
            }
            else
            {

                StepInfo si = infos[currIdx];
                if (currIdx < infos.Count - 1)
                {
                    Label l = tableLayoutPanel1.GetControlFromPosition(4, si.PrefixIdx+1) as Label;
                    l.BackColor = Color.Blue;
                }
                else
                {
                    if (si.PrefixIdx != -1)
                    {
                        tableLayoutPanel1.GetControlFromPosition(4, si.PrefixIdx+1).BackColor = Color.Yellow;
                    }
                    InputTextBox.Text = InputTextBox.Text;
                    InputTextBox.SelectionStart = infos[infos.Count - 1].StartPos;
                    InputTextBox.SelectionLength = infos[infos.Count - 1].MatchLen;
                    InputTextBox.SelectionColor = Color.Red;
                    this.Refresh();
                }
                MessageTextBox.Text = si.StepMessage;

                this.Refresh();
            }

        }
    }
}
