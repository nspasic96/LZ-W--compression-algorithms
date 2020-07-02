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
        private List<LZ78Entry> encodeSteps;
        List<LZ78DecodeStepInfo> decodeSteps;
        LZ78DecodeStepInfo currDecodeEntry;
        private int currStep;
        private int currentEncodedPos;
        private StringBuilder decodedSoFar;
        
        public LZ78_Decode(List<LZ78Entry> steps)
        {
            InitializeComponent();

            this.encodeSteps = steps;
            this.decodeSteps = new List<LZ78DecodeStepInfo>();

            StringBuilder sb = new StringBuilder();

            foreach(var step in steps)
            {
                sb.Append(step.Output);
            }
            this.EncodedMessageTextBox.Text = sb.ToString();
            this.currStep = -1;
            this.currentEncodedPos = 0;
            decodedSoFar = new StringBuilder();
        }
        private void populateTableLayoutPanel()
        {
            Label l1 = new Label();
            l1.Text = "Index";
            Label l2 = new Label();
            l2.Text = "Output";
            Label l3 = new Label();
            l3.Text = "Word";

            tableLayoutPanel1.Controls.Add(l1, 0, 0);
            tableLayoutPanel1.Controls.Add(l2, 1, 0);
            tableLayoutPanel1.Controls.Add(l3, 2, 0);
            
            for (int k=1; k<=this.currStep+1; k++)
            {
                
                LZ78Entry entry = encodeSteps[k - 1]; 
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
            Utils.splitTlp(tableLayoutPanel1, this.currStep+2, m, true);
            populateTableLayoutPanel();
        }

        private void unsetPreviousStep()
        {
            EncodedMessageTextBox.SelectionStart = 0;
            EncodedMessageTextBox.SelectionLength = EncodedMessageTextBox.Text.Length;
            EncodedMessageTextBox.SelectionColor = Color.Black;

            DecodedSoFarTextBox.Text = "";
            MessageLabel.Text = "";
        }

        private void paint()
        {
            if (currDecodeEntry.EndOfMessage)
            {
                EncodedMessageTextBox.SelectionStart = currDecodeEntry.CurrentEncodedPos + 1;
                EncodedMessageTextBox.SelectionLength = 1;
                EncodedMessageTextBox.SelectionColor = Utils.c3;

                DecodedSoFarTextBox.Text = currDecodeEntry.DecodedSoFar;
                tableLayoutPanel1.GetControlFromPosition(2, currDecodeEntry.MatchIdx).BackColor = Utils.c2;
                tableLayoutPanel1.GetControlFromPosition(0, currDecodeEntry.MatchIdx).BackColor = Utils.c3;
                DecodedSoFarTextBox.SelectionStart = currDecodeEntry.DecodedSoFar.Length - encodeSteps[currDecodeEntry.MatchIdx - 1].Word.Length;
                DecodedSoFarTextBox.SelectionLength = encodeSteps[currDecodeEntry.MatchIdx - 1].Word.Length;
                DecodedSoFarTextBox.SelectionColor = Utils.c2;
            }
            else
            {
                EncodedMessageTextBox.SelectionStart = currDecodeEntry.CurrentEncodedPos + encodeSteps[currStep].Output.Length - 3;
                EncodedMessageTextBox.SelectionLength = 1;
                EncodedMessageTextBox.SelectionColor = Utils.c2;

                tableLayoutPanel1.GetControlFromPosition(2, currStep + 1).BackColor = Utils.c2;
                if (currDecodeEntry.MatchIdx != 0)//there is actually a match
                {
                    EncodedMessageTextBox.SelectionStart = currDecodeEntry.CurrentEncodedPos + 1;
                    EncodedMessageTextBox.SelectionLength = encodeSteps[currStep].Output.Length - 4;
                    EncodedMessageTextBox.SelectionColor = Utils.c3;
                    tableLayoutPanel1.GetControlFromPosition(2, currDecodeEntry.MatchIdx).BackColor = Utils.c1;
                    tableLayoutPanel1.GetControlFromPosition(0, currDecodeEntry.MatchIdx).BackColor = Utils.c3;
                }

                DecodedSoFarTextBox.Text = currDecodeEntry.DecodedSoFar;
                DecodedSoFarTextBox.SelectionStart = currDecodeEntry.DecodedSoFar.Length - encodeSteps[currStep].Word.Length;
                DecodedSoFarTextBox.SelectionLength = encodeSteps[currStep].Word.Length - 1;
                DecodedSoFarTextBox.SelectionColor = Utils.c1;
                DecodedSoFarTextBox.SelectionStart = currDecodeEntry.DecodedSoFar.Length - 1;
                DecodedSoFarTextBox.SelectionLength = 1;
                DecodedSoFarTextBox.SelectionColor = Utils.c2;

                MessageLabel.Text = currDecodeEntry.Message;


            }

        }
        private void processCurrentStep()
        {
            string[] spearator = { "(", ")", "," };
            string[] strlist = this.encodeSteps[currStep].Output.Split(spearator,
                StringSplitOptions.RemoveEmptyEntries);
            
            int matchIdx; 
            char toAddChar;
            Int32.TryParse(strlist[0], out matchIdx);
            Char.TryParse(strlist[1], out toAddChar);

            string message;

            if (toAddChar == '-')//the end of the message
            {
                message = "Entry with index {0}(marked blue) has been matched.";
                message = string.Format(message, matchIdx);
                decodeSteps.Add(new LZ78DecodeStepInfo(true, matchIdx, decodedSoFar.Append(encodeSteps[matchIdx - 1].Word).ToString(), currentEncodedPos, message)); 
            }
            else
            {
                if(matchIdx != 0)
                {
                    message = "Entry with index {0}(marked blue) has been matched. In this step new entry is added(marked yellow) contating word from entry matched(marked red) augmented with character {1}.";
                    message = string.Format(message, matchIdx, toAddChar);
                    decodedSoFar.Append(encodeSteps[matchIdx - 1].Word);
                }
                else
                {
                    message = "No entry has been matched. Adding entry contating only {0}(marked yellow)";
                    message = string.Format(message, toAddChar);
                }
                decodedSoFar.Append(toAddChar);
                decodeSteps.Add(new LZ78DecodeStepInfo(false, matchIdx, decodedSoFar.ToString(), currentEncodedPos, message));//TODO:add appropriate decode step info
            }
            currentEncodedPos += encodeSteps[currStep].Output.Length;
        }

        private void updateButtons()
        {
            if(currStep == -1)
            {
                BackButton.Enabled = false;
            }
            else
            {
                BackButton.Enabled = true;
            }
            if (currStep == encodeSteps.Count - 1)
            {
                NextButton.Text = "Close form";
            }
            else
            {
                NextButton.Text = "Next";
            }
        }

        private void NextButton_Click(object sender, EventArgs e)
        {
            currStep++;
            if (currStep < encodeSteps.Count)
            {
                unsetPreviousStep();
                if (decodeSteps.Count == currStep)
                {
                    processCurrentStep();
                }
                currDecodeEntry = decodeSteps[currStep];
                drawTable();
                updateButtons();
                paint();
                Refresh();
            }
            else
            {
                this.Close();
            }

        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            currStep--;
            unsetPreviousStep();
            if(currStep > -1)
            {
                currDecodeEntry = decodeSteps[currStep];
                drawTable();
                paint();
            }
            else
            {
                drawTable();
            }
            updateButtons();
            Refresh();

        }
    }
}
