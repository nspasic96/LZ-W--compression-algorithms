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
    public partial class LZ78_Decode : Form
    {
        private List<LZ78Entry> steps;
        private int currentEntry;
        private int currentEncodedPos;
        private StringBuilder decodedSoFar;
        
        public LZ78_Decode(List<LZ78Entry> steps)
        {
            InitializeComponent();

            this.steps = steps;
            StringBuilder sb = new StringBuilder();

            foreach(var step in steps)
            {
                sb.Append(step.Output);
            }
            this.EncodedMessageTextBox.Text = sb.ToString();
            this.currentEntry = 0;
            this.currentEncodedPos = 0;
            decodedSoFar = new StringBuilder();
        }
        private void populateTableLayoutPanel()
        {
            Label l1 = new Label();
            l1.Text = "Step";
            Label l2 = new Label();
            l2.Text = "Output";
            Label l3 = new Label();
            l3.Text = "Word";

            tableLayoutPanel1.Controls.Add(l1, 0, 0);
            tableLayoutPanel1.Controls.Add(l2, 1, 0);
            tableLayoutPanel1.Controls.Add(l3, 2, 0);
            
            for (int k=1; k<=this.currentEntry+1; k++)
            {
                
                LZ78Entry entry = steps[k - 1]; 
                if(entry.Output[entry.Output.Length-2] != '-')//do add last entry in table if it is not in dictionary
                {

                    Label l11 = new Label();
                    l11.Text = entry.Step.ToString();
                    l11.Font = new Font("Microsoft Sans Serif", 10);
                    Label l12 = new Label();
                    l12.Text = entry.Output;
                    l12.Font = new Font("Microsoft Sans Serif", 10);
                    Label l13 = new Label();
                    l13.Text = entry.Word;
                    l13.Font = new Font("Microsoft Sans Serif", 10);

                    tableLayoutPanel1.Controls.Add(l11, 0, k);
                    tableLayoutPanel1.Controls.Add(l12, 1, k);
                    tableLayoutPanel1.Controls.Add(l13, 2, k);
                }

            }
        }

        private void drawTable()
        {
            int m = 3;
            Utils.splitTlp(tableLayoutPanel1, this.currentEntry+2, m, true);
            populateTableLayoutPanel();
        }

        private void unsetPreviousStep()
        {
            DecodedSoFarTextBox.SelectionStart = 0;
            DecodedSoFarTextBox.SelectionLength = decodedSoFar.Length;
            DecodedSoFarTextBox.SelectionColor = Color.Black;
            EncodedMessageTextBox.SelectionStart = 0;
            EncodedMessageTextBox.SelectionLength = EncodedMessageTextBox.Text.Length-1;
            EncodedMessageTextBox.SelectionColor = Color.Black;

        }
        private void paint()
        {
            string[] spearator = { "(", ")", "," };
            string[] strlist = this.steps[currentEntry].Output.Split(spearator,
                StringSplitOptions.RemoveEmptyEntries);

            int matchIdx; 
            char toAddChar;
            Int32.TryParse(strlist[0], out matchIdx);
            Char.TryParse(strlist[1], out toAddChar);
            if (toAddChar == '-')//the end of the message
            {

                EncodedMessageTextBox.SelectionStart = currentEncodedPos + 1;
                EncodedMessageTextBox.SelectionLength = 1;
                EncodedMessageTextBox.SelectionColor = Utils.c3;

                decodedSoFar.Append(steps[matchIdx - 1].Word);
                DecodedSoFarTextBox.Text = decodedSoFar.ToString();
                tableLayoutPanel1.GetControlFromPosition(2, matchIdx).BackColor = Utils.c2;
                tableLayoutPanel1.GetControlFromPosition(0, matchIdx).BackColor = Utils.c3;
                DecodedSoFarTextBox.SelectionStart = decodedSoFar.Length - steps[matchIdx-1].Word.Length;
                DecodedSoFarTextBox.SelectionLength = steps[matchIdx - 1].Word.Length;
                DecodedSoFarTextBox.SelectionColor = Utils.c2;
            }
            else
            {

                EncodedMessageTextBox.SelectionStart = currentEncodedPos + steps[currentEntry].Output.Length - 3;
                EncodedMessageTextBox.SelectionLength = 1;
                EncodedMessageTextBox.SelectionColor = Utils.c2;

                tableLayoutPanel1.GetControlFromPosition(2, currentEntry+1).BackColor = Utils.c2;
                if(matchIdx != 0)//there is actually a match
                {
                    EncodedMessageTextBox.SelectionStart = currentEncodedPos + 1;
                    EncodedMessageTextBox.SelectionLength = steps[currentEntry].Output.Length - 4;
                    EncodedMessageTextBox.SelectionColor = Utils.c3;
                    tableLayoutPanel1.GetControlFromPosition(2, matchIdx).BackColor = Utils.c1;
                    tableLayoutPanel1.GetControlFromPosition(0, matchIdx).BackColor = Utils.c3;
                    decodedSoFar.Append(steps[matchIdx - 1].Word);
                }

                decodedSoFar.Append(toAddChar);
                DecodedSoFarTextBox.Text = decodedSoFar.ToString();
                DecodedSoFarTextBox.SelectionStart = decodedSoFar.Length - steps[currentEntry].Word.Length;
                DecodedSoFarTextBox.SelectionLength = steps[currentEntry].Word.Length - 1;
                DecodedSoFarTextBox.SelectionColor = Utils.c1;
                DecodedSoFarTextBox.SelectionStart = decodedSoFar.Length - 1;
                DecodedSoFarTextBox.SelectionLength = 1;
                DecodedSoFarTextBox.SelectionColor = Utils.c2;
            }
        }

        private void update()
        {
            currentEncodedPos += steps[currentEntry].Output.Length;
            currentEntry++;
            if (currentEntry == steps.Count)
            {
                NextButton.Text = "Close form";
            }
        }

        private void NextButton_Click(object sender, EventArgs e)
        {
            if(this.currentEntry < steps.Count)
            {
                unsetPreviousStep();
                drawTable();
                paint();
                update();
                Refresh();
                
            }
            else
            {
                this.Close();
            }
        }

    }
}
