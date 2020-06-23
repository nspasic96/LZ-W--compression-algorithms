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
    public partial class LZ77_Decode : Form
    {
        public LZ77_Decode(List<StepInfo> stepInfos)
        {
            InitializeComponent();

            StringBuilder encoded = new StringBuilder();
            foreach (var stepInfo in stepInfos){
                encoded.Append(stepInfo.Output);
            }
            this.EncodedMessageTextBox.Text = encoded.ToString();
            this.encodedMessage = encoded.ToString();
            this.stepInfos = stepInfos;
            this.curEntry = 0;
            this.curPosition = 0;
            this.curEntryStart = 0;
            this.curEntryLen = this.stepInfos[0].Output.Length;
            this.decodedSoFar = new StringBuilder();
        }

        private void NextButton_Click(object sender, EventArgs e)
        {
            if(this.curEntry < this.stepInfos.Count)
            {
                string[] spearator = { "<", ">", "," };
                string[] strlist = this.stepInfos[curEntry].Output.Split(spearator,
                    StringSplitOptions.RemoveEmptyEntries);

                int matchLen = 1;
                int matchStartPosBack = 0;
                if (strlist.Length == 2)//this means that there is no match
                {
                    this.decodedSoFar.Append(strlist[1]);
                }
                else if (strlist.Length == 3)//this is the case when we have match
                {
                    Int32.TryParse(strlist[1], out matchStartPosBack);
                    Int32.TryParse(strlist[2], out matchLen);
                    int matchStart = this.curPosition - matchStartPosBack;

                    for (int i = matchStart; i < matchStart + matchLen; i++)
                    {
                        decodedSoFar.Append(this.decodedSoFar[i]);
                    }
                }
                updateAndBookkeeping(matchLen, matchStartPosBack);
                this.Refresh();
            }
            else
            {
                this.Close();
            }
        }

        private void updateAndBookkeeping(int matchLen, int matchStartPosBack)
        {
            DecodedSoFarTextBox.Text = decodedSoFar.ToString();
            MatchTextBox.Text = decodedSoFar.ToString();
            unsetPreviousStep();
            colorCurStep(matchLen, matchStartPosBack);

            curEntryStart += this.stepInfos[curEntry].Output.Length;
            curEntry++;
            if (this.curEntry < this.stepInfos.Count)
            {
                this.curEntryLen = this.stepInfos[curEntry].Output.Length;
            }
            else
            {
                this.NextButton.Text = "Close form";
            }

            curPosition += matchLen;
        }

        private void colorCurStep(int matchLen, int matchStartPosBack)
        {          

            DecodedSoFarTextBox.SelectionStart = decodedSoFar.Length - matchLen;
            DecodedSoFarTextBox.SelectionLength = matchLen;
            DecodedSoFarTextBox.SelectionColor = Utils.c1;

            EncodedMessageTextBox.SelectionStart = curEntryStart;
            EncodedMessageTextBox.SelectionLength = curEntryLen;
            EncodedMessageTextBox.SelectionColor = Utils.c1;

            MatchTextBox.SelectionStart = curPosition - matchStartPosBack;
            MatchTextBox.SelectionLength = matchLen <= matchStartPosBack ? matchLen : matchStartPosBack;
            MatchTextBox.SelectionColor = Utils.c1;

            if(matchLen > matchStartPosBack && matchStartPosBack > 0)
            {
                MatchTextBox.SelectionStart = curPosition;
                MatchTextBox.SelectionLength = matchLen - matchStartPosBack;
                MatchTextBox.SelectionColor = Utils.c3;
            }

        }

        private void unsetPreviousStep()
        {
            DecodedSoFarTextBox.SelectionStart = 0;
            DecodedSoFarTextBox.SelectionLength = decodedSoFar.Length;
            DecodedSoFarTextBox.SelectionColor = Color.Black;

            MatchTextBox.SelectionStart = 0;
            MatchTextBox.SelectionLength = decodedSoFar.Length;
            MatchTextBox.SelectionColor = Color.Black;

            EncodedMessageTextBox.SelectionColor = Color.Black;
        }
    }
}
