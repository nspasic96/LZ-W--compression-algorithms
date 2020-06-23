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
        private string[] encodedSteps;
        private char[] alphabet;
        public LZW_Decode(StringBuilder encodedMessage, char[] alphabet)
        {
            InitializeComponent();
            decodedSoFar = new StringBuilder();
            decodeSteps = new List<LZWDecodeEntry>();
            currStep = 0;
            EncodedMessageTextBox.Text = encodedMessage.ToString();
            string[] spearator = { " " };
            encodedSteps = encodedMessage.ToString().Split(spearator,
                StringSplitOptions.RemoveEmptyEntries);
            this.alphabet = alphabet;
            resetDictionary();
        }

        private void resetDictionary()
        {
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
            l3.Text = "Whole word";

            tableLayoutPanel1.Controls.Add(l1, 0, 0);
            tableLayoutPanel1.Controls.Add(l2, 1, 0);
            tableLayoutPanel1.Controls.Add(l3, 2, 0);
            tableLayoutPanel1.Controls.Add(l4, 3, 0);

            for (int k = 1; k <= currStep + alphabet.Length; k++)
            {

                LZWDecodeEntry entry = decodeSteps[k - 1];

                Label l11 = new Label();
                l11.Text = entry.DictIdx.ToString();
                Label l12 = new Label();
                l12.Text = entry.Start;
                Label l13 = new Label();
                l13.Text = entry.Next;
                Label l14 = new Label();
                l14.Text = entry.Whole;

                tableLayoutPanel1.Controls.Add(l11, 0, k);
                tableLayoutPanel1.Controls.Add(l12, 1, k);
                tableLayoutPanel1.Controls.Add(l13, 2, k);
                tableLayoutPanel1.Controls.Add(l14, 3, k);
            }
        }
        private void drawTable()
        {
            int m = 4;
            Utils.splitTlp(tableLayoutPanel1, currStep + alphabet.Length + 2, m, true);
            populateTableLayoutPanel();

        }
        private void paint()
        {
            if(encodedSteps[currStep] == "|")//this the case where onFullDict = reset
            {

            }
            else
            {
                int refIdx;
                Int32.TryParse(encodedSteps[currStep], out refIdx);

                if(currStep > 0)
                {
                    LZWDecodeEntry previousStep = decodeSteps[alphabet.Length + currStep - 1];
                    previousStep.Next = decodeSteps[refIdx].Whole[0].ToString();
                    previousStep.Whole = string.Concat(previousStep.Start, previousStep.Next);
                    decodeSteps[alphabet.Length + currStep - 1] = previousStep;
                }

                LZWDecodeEntry newStep = new LZWDecodeEntry(currStep + alphabet.Length, decodeSteps[refIdx].Whole, "", decodeSteps[refIdx].Whole);
                decodeSteps.Add(newStep);

            }
        }
        private void update()
        {
            decodedSoFar.Append(decodeSteps[currStep + alphabet.Length].Whole);
            DecodedSoFarTextBox.Text = decodedSoFar.ToString();
            currStep++;
            if(currStep == encodedSteps.Length)
            {
                NextButton.Text = "Close form";
            }

        }
        private void NextButton_Click(object sender, EventArgs e)
        {
            if(currStep < encodedSteps.Length)
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
