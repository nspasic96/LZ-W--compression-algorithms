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
        private List<LZ77DecodeStepInfo> decodeSteps;
        private LZ77DecodeStepInfo currDecodeEntry;
        private int currStep;
        private int curPosition;
        private int currentEncodedPos;

        public LZ77_Decode(List<StepInfo> stepInfos)
        {
            InitializeComponent();

            StringBuilder encoded = new StringBuilder();
            foreach (var stepInfo in stepInfos){
                encoded.Append(stepInfo.Output);
            }
            this.EncodedMessageTextBox.Text = encoded.ToString();
            this.encodedMessage = encoded.ToString();
            this.decodeSteps = new List<LZ77DecodeStepInfo>();
            this.encodeSteps = stepInfos;
            this.currStep = -1;
            this.curPosition = 0;
            this.currentEncodedPos = 0;
            this.decodedSoFar = new StringBuilder();
        }
        
        private void unsetPreviousStep()
        {
            EncodedMessageTextBox.SelectionColor = Color.Black;

            DecodedSoFarTextBox.Text = "";
            MatchTextBox.Text = "";
            MessageLabel.Text = "";
        }

        private void processCurrentStep()
        {
            string[] spearator = { "<", ">", "," };
            string[] strlist = this.encodeSteps[currStep].Output.Split(spearator,
                StringSplitOptions.RemoveEmptyEntries);

            string message;
            if (strlist.Length == 2)//this means that there is no match
            {
                message = "No match found within the window, just copying character from currenty entry.";
                decodeSteps.Add(new LZ77DecodeStepInfo(false, decodedSoFar.Append(strlist[1]).ToString(), 1, 0, encodeSteps[currStep].Output.Length, curPosition, currentEncodedPos, message));
                curPosition += 1;
            }
            else if (strlist.Length == 3)//this is the case when we have match
            {
                int matchLen = 1;
                int matchStartPosBack = 0;
                Int32.TryParse(strlist[1], out matchStartPosBack);
                Int32.TryParse(strlist[2], out matchLen);
                int matchStart = this.curPosition - matchStartPosBack;

                for (int i = matchStart; i < matchStart + matchLen; i++)
                {
                    decodedSoFar.Append(decodedSoFar[i]);
                }

                if (matchLen > matchStartPosBack && matchStartPosBack > 0)
                {
                    message = "Match found {0} positions back with length {1}. Note that string matched overalps with string added at this step(overlap marked blue).";
                    message = string.Format(message, matchStartPosBack, matchLen);
                }
                else
                {
                    message = "Match found {0} positions back with length {1}.";
                    message = string.Format(message, matchStartPosBack, matchLen);
                }

                decodeSteps.Add(new LZ77DecodeStepInfo(true, decodedSoFar.ToString(), matchLen, matchStartPosBack, encodeSteps[currStep].Output.Length, curPosition, currentEncodedPos, message));
                curPosition += encodeSteps[currStep].MatchLen;
            }
            currentEncodedPos += encodeSteps[currStep].Output.Length;

        }
        private void paint()
        {
            DecodedSoFarTextBox.Text = currDecodeEntry.DecodedSoFar;
            MatchTextBox.Text = currDecodeEntry.DecodedSoFar;

            DecodedSoFarTextBox.SelectionStart = currDecodeEntry.DecodedSoFar.Length - currDecodeEntry.MatchLen;
            DecodedSoFarTextBox.SelectionLength = currDecodeEntry.MatchLen;
            DecodedSoFarTextBox.SelectionColor = Utils.c1;

            EncodedMessageTextBox.SelectionStart = currDecodeEntry.CurrentEncodedPos;
            EncodedMessageTextBox.SelectionLength = currDecodeEntry.EncodedSelectionLength;
            EncodedMessageTextBox.SelectionColor = Utils.c1;

            MatchTextBox.SelectionStart = currDecodeEntry.CurPosition - currDecodeEntry.MatchStartPosBack;
            MatchTextBox.SelectionLength = currDecodeEntry.MatchLen <= currDecodeEntry.MatchStartPosBack ? currDecodeEntry.MatchLen : currDecodeEntry.MatchStartPosBack;
            MatchTextBox.SelectionColor = Utils.c1;

            if (currDecodeEntry.MatchLen > currDecodeEntry.MatchStartPosBack && currDecodeEntry.MatchStartPosBack > 0)
            {
                MatchTextBox.SelectionStart = currDecodeEntry.CurPosition;
                MatchTextBox.SelectionLength = currDecodeEntry.MatchLen - currDecodeEntry.MatchStartPosBack;
                MatchTextBox.SelectionColor = Utils.c3;
            }

            MessageLabel.Text = currDecodeEntry.Message;

        }
        private void updateButtons()
        {
            if (currStep == -1)
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
                if (decodeSteps.Count == currStep)
                {
                    processCurrentStep();
                }
                currDecodeEntry = decodeSteps[currStep];
                unsetPreviousStep();
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
            if(currStep > -1)
            {
                currDecodeEntry = decodeSteps[currStep];
                unsetPreviousStep();
                paint();
            }
            else
            {
                unsetPreviousStep();
            }
            updateButtons();
            Refresh();
        }
    }
}
