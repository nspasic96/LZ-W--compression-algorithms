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
    public partial class LZW_Decode : Form
    {
        private StringBuilder decodedSoFar;
        List<LZWDecodeEntry> decodeSteps;
        private int currStep;
        private int lastReset;
        private string[] encodedSteps;
        private char[] alphabet;
        private bool isReset;
        private int numberOfResets;
        private int offset;

        public LZW_Decode(StringBuilder encodedMessage, char[] alphabet)
        {
            InitializeComponent();
            decodedSoFar = new StringBuilder();
            EncodedMessageTextBox.Text = encodedMessage.ToString();
            string[] spearator = { " " };
            encodedSteps = encodedMessage.ToString().Split(spearator,
                StringSplitOptions.RemoveEmptyEntries);
            this.alphabet = alphabet;
            isReset = false;
            resetDictionary();
            currStep = -1;
            lastReset = 0;
            offset = 0;
            numberOfResets = 0;
            drawTable();
        }

        private void resetDictionary()
        {
            decodeSteps = new List<LZWDecodeEntry>();
            int i = 0;
            foreach (var c in alphabet)
            {
                decodeSteps.Add(new LZWDecodeEntry(i, c.ToString(), "", c.ToString()));
                i++;
            }
        }

        private void unsetPreviousStep()
        {
            DecodedSoFarTextBox.SelectionStart = 0;
            DecodedSoFarTextBox.SelectionLength = decodedSoFar.Length;
            DecodedSoFarTextBox.SelectionColor = Color.Black;
            EncodedMessageTextBox.SelectionStart = 0;
            EncodedMessageTextBox.SelectionLength = EncodedMessageTextBox.Text.Length - 1;
            EncodedMessageTextBox.SelectionColor = Color.Black;
        }
        private void populateTableLayoutPanel()
        {
            Label l1 = new Label();
            l1.Text = "Index";
            Label l2 = new Label();
            l2.Text = "Start word";
            Label l3 = new Label();
            l3.Text = "Last char";
            Label l4 = new Label();
            l4.Text = "Whole word";

            tableLayoutPanel1.Controls.Add(l1, 0, 0);
            tableLayoutPanel1.Controls.Add(l2, 1, 0);
            tableLayoutPanel1.Controls.Add(l3, 2, 0);
            tableLayoutPanel1.Controls.Add(l4, 3, 0);

            //int limit = Math.Min(currStep + alphabet.Length + 1, encodedSteps.Length + alphabet.Length - 1);//do not show last entry as it is never actually in the dictionary

            for (int k = lastReset + 1; k <= currStep + alphabet.Length + 1 - offset; k++)
            {

                LZWDecodeEntry entry = decodeSteps[k - lastReset - 1];

                Label l11 = new Label();
                l11.Text = entry.DictIdx.ToString();
                Label l12 = new Label();
                l12.Text = entry.Start;
                Label l13 = new Label();
                l13.Text = entry.Next;
                Label l14 = new Label();
                l14.Text = entry.Whole;

                tableLayoutPanel1.Controls.Add(l11, 0, k - lastReset);
                tableLayoutPanel1.Controls.Add(l12, 1, k - lastReset);
                tableLayoutPanel1.Controls.Add(l13, 2, k - lastReset);
                tableLayoutPanel1.Controls.Add(l14, 3, k - lastReset);
            }
        }
        private void drawTable()
        {
            int m = 4;
            Utils.splitTlp(tableLayoutPanel1, currStep - lastReset - offset + alphabet.Length + 2, m, true);
            populateTableLayoutPanel();

        }
        private void processCurrInput()
        {
            if(encodedSteps[currStep] == "|")//this the case where onFullDict = reset
            {
                isReset = true;
                offset = 1;
                lastReset = currStep;
                numberOfResets++;
                resetDictionary();
                drawTable();
            }
            else
            {
                int refIdx;
                Int32.TryParse(encodedSteps[currStep], out refIdx);

                if(currStep > 0 && !isReset)
                {
                    LZWDecodeEntry previousStep = decodeSteps[alphabet.Length + currStep - lastReset - 1 - offset];  
                    previousStep.Next = decodeSteps[refIdx].Whole[0].ToString();
                    previousStep.Whole = string.Concat(previousStep.Start, previousStep.Next);
                    decodeSteps[alphabet.Length + currStep - lastReset - 1 - offset] = previousStep;
                }

                LZWDecodeEntry newStep = new LZWDecodeEntry(currStep - lastReset - offset + alphabet.Length, decodeSteps[refIdx].Whole, "", decodeSteps[refIdx].Whole);
                decodeSteps.Add(newStep);

                isReset = false;
            }
        }
        private void updateFormElems()
        {
            decodedSoFar.Append(decodeSteps[currStep - lastReset + alphabet.Length - offset].Whole);
            DecodedSoFarTextBox.Text = decodedSoFar.ToString();
            if (currStep == encodedSteps.Length - 1)
            {
                NextButton.Text = "Close form";
            }
        }
        private void paint()
        {
            DecodedSoFarTextBox.SelectionStart = DecodedSoFarTextBox.Text.Length - decodeSteps[currStep - lastReset - offset + alphabet.Length].Whole.Length;
            DecodedSoFarTextBox.SelectionLength = decodeSteps[currStep - lastReset - offset + alphabet.Length].Whole.Length;
            DecodedSoFarTextBox.SelectionColor = Utils.c1;

            EncodedMessageTextBox.SelectionStart = 2*currStep;
            EncodedMessageTextBox.SelectionLength = 1;
            EncodedMessageTextBox.SelectionColor = Utils.c3;

            Label lWhole = tableLayoutPanel1.GetControlFromPosition(3, currStep - lastReset + alphabet.Length + (1 - offset)) as Label;
            lWhole.BackColor = Utils.c1;
            if(currStep > 0)
            {
                Label lStart = tableLayoutPanel1.GetControlFromPosition(1, currStep - lastReset + alphabet.Length + (1 - offset)) as Label;
                lStart.BackColor = Utils.c2;
            }

            int refIdx;
            Int32.TryParse(encodedSteps[currStep], out refIdx);
            Label lIdx = tableLayoutPanel1.GetControlFromPosition(0, refIdx+1) as Label;
            lIdx.BackColor = Utils.c3;

            if (currStep > 0)
            {
                Label lNextPrev = tableLayoutPanel1.GetControlFromPosition(2, currStep - lastReset + alphabet.Length - offset) as Label;
                Label lWholePrev = tableLayoutPanel1.GetControlFromPosition(3, currStep - lastReset + alphabet.Length - offset) as Label;
                lNextPrev.BackColor = Utils.c2;
                lWholePrev.BackColor = Utils.c2;
            }
        }
        private void NextButton_Click(object sender, EventArgs e)
        {
            currStep++;
            if(currStep < encodedSteps.Length)
            {
                unsetPreviousStep();
                processCurrInput();
                drawTable();
                if (!isReset)
                {
                    updateFormElems();
                    paint();
                } else
                {
                    EncodedMessageTextBox.SelectionStart = 2 * currStep;
                    EncodedMessageTextBox.SelectionLength = 1;
                    EncodedMessageTextBox.SelectionColor = Utils.c3;
                }
                Refresh();
            }
            else
            {
                this.Close();
            }
        }

    }
}
