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
        List<LZWDecodeEntry> currChunkDecodeSteps;
        List<LZWDecodeEntry> lastChunkDecodeSteps;
        List<LZWDecodeStepInfo> decodeStepInfos;
        LZWDecodeStepInfo currStepInfo;
        private int currStep;
        private int lastReset;
        private string[] encodedSteps;
        private char[] alphabet;
        private bool isReset;
        private bool wasReset;
        private int offset;
        private int currChunk;
        private int totalChunks;
        private int lastAction;
        private int totalBits;
        private int showEntriesMax;
        private int limit;

        public LZW_Decode(StringBuilder encodedMessage, char[] alphabet, int totalBits, bool onFullDictReset)
        {
            InitializeComponent();
            decodedSoFar = new StringBuilder();
            EncodedMessageTextBox.Text = encodedMessage.ToString();
            string[] spearator = { " " };
            encodedSteps = encodedMessage.ToString().Split(spearator,
                StringSplitOptions.RemoveEmptyEntries);
            this.alphabet = alphabet;
            isReset = false;
            wasReset = true;
            currStep = -1;
            lastReset = 0;
            offset = 0;
            currChunk = 0;
            lastAction = 0;
            if (onFullDictReset)
            {
                showEntriesMax = -1;
            }
            else
            {
                showEntriesMax = 1 << totalBits;
            }
            this.totalBits = totalBits;
            decodeStepInfos = new List<LZWDecodeStepInfo>();
            resetDictionary();
            drawTable();
        }

        private void resetDictionary()
        {
            currChunkDecodeSteps = new List<LZWDecodeEntry>();
            int i = 0;
            foreach (var c in alphabet)
            {
                currChunkDecodeSteps.Add(new LZWDecodeEntry(i, c.ToString(), "", c.ToString()));
                i++;
            }
        }

        private void unsetPreviousStep()
        {
            DecodedSoFarTextBox.SelectionStart = 0;
            DecodedSoFarTextBox.SelectionLength = decodedSoFar.Length;
            DecodedSoFarTextBox.SelectionColor = Color.Black;
            EncodedMessageTextBox.SelectionStart = 0;
            EncodedMessageTextBox.SelectionLength = EncodedMessageTextBox.Text.Length;
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

            for (int k = lastReset + 1; k <= limit; k++)
            {

                LZWDecodeEntry entry = currChunkDecodeSteps[k - lastReset - 1];

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
            string message;
            if (encodedSteps[currStep] == "|")//this the case where onFullDict = reset
            {
                message = "Dictionary is full and it is reset in this step.";

                LZWDecodeStepInfo previous = decodeStepInfos[currStep - 1];
                previous.Entries = currChunkDecodeSteps.ConvertAll(ent => new LZWDecodeEntry(ent.DictIdx, ent.Start, ent.Next, ent.Whole));
                decodeStepInfos[currStep - 1] = previous;
                decodeStepInfos.Add(new LZWDecodeStepInfo(true, currStep, 1, currStep - lastReset - 1 + alphabet.Length, decodedSoFar.ToString(), 0, message));
                resetDictionary();
                totalChunks++;
            }
            else
            {
                int refIdx;
                Int32.TryParse(encodedSteps[currStep], out refIdx);
                if (showEntriesMax == -1 || currStep + 1 < showEntriesMax)
                {
                    if (1 << totalBits == currStep + alphabet.Length)
                    {
                        message = "Entry with index {0}(marked blue) has been matched. Dictionary is full and will be reset in next step, so no new entry is acctualy added, but it shown here(entry with index {1}) for visualization. Previous entry ends with first character of new(imaginary) entry(marked yellow).";
                        message = string.Format(message, refIdx, currStep + alphabet.Length);
                    }
                    else
                    {
                        if (currStep > 0 && !wasReset)
                        {
                            message = "Entry with index {0}(marked blue) has been matched. New entry starts with word of matched entry and last character of previous entry is first character of new entry(marked yellow)";
                            message = string.Format(message, refIdx);
                        }
                        else
                        {
                            message = "Entry with index {0}(marked blue) has been matched. New entry starts with word of matched entry.";
                            message = string.Format(message, refIdx);
                        }
                    }
                }
                else
                {
                    message = "Entry with index {0}(marked blue) has been matched. Dictionary is full, no entries are added further.";
                    message = string.Format(message, refIdx);
                }
                if (showEntriesMax == currStep + alphabet.Length)
                {
                    message = "Entry with index {0}(marked blue) has been matched. Dictionary is full and not reset, so no new entry is acctualy added, but it shown here(entry with index {1}) for visualization. Previous entry ends with first character of new(imaginary) entry(marked yellow).";
                    message = string.Format(message, refIdx, showEntriesMax);

                }
                LZWDecodeEntry newStep = new LZWDecodeEntry(currStep - lastReset - offset + alphabet.Length, currChunkDecodeSteps[refIdx].Whole, "", currChunkDecodeSteps[refIdx].Whole);
                currChunkDecodeSteps.Add(newStep);
                decodeStepInfos.Add(new LZWDecodeStepInfo(false, lastReset, offset, currStep - lastReset - offset + alphabet.Length, decodedSoFar.Append(currChunkDecodeSteps[currStep - lastReset + alphabet.Length - offset].Whole).ToString(), currChunkDecodeSteps[currStep - lastReset + alphabet.Length - offset].Whole.Length, message));
            }
        }
        private void updateFormElems()
        {
            if (!isReset)
            {
                int refIdx;
                Int32.TryParse(encodedSteps[currStep], out refIdx);

                if (currStep > 0 && !wasReset)
                {
                    LZWDecodeEntry previousStep = currChunkDecodeSteps[currStepInfo.RelativeDecodeStepIdx - 1];
                    previousStep.Next = currChunkDecodeSteps[refIdx].Whole[0].ToString();
                    previousStep.Whole = string.Concat(previousStep.Start, previousStep.Next);
                    currChunkDecodeSteps[currStepInfo.RelativeDecodeStepIdx - 1] = previousStep;
                    if (refIdx == currStepInfo.RelativeDecodeStepIdx - 1 && !decodeStepInfos[currStep].Refined)//check this edge case and edit decode entry just once(first time encou
                    {
                        LZWDecodeEntry thisStep = currChunkDecodeSteps[currStepInfo.RelativeDecodeStepIdx];
                        thisStep.Start = currChunkDecodeSteps[refIdx].Whole;
                        thisStep.Whole = currChunkDecodeSteps[refIdx].Whole;
                        currChunkDecodeSteps[currStepInfo.RelativeDecodeStepIdx] = thisStep;

                        LZWDecodeStepInfo thisInfo = decodeStepInfos[currStep];
                        decodedSoFar.Length -= thisInfo.DecodedSoFarSelectionLength;
                        decodedSoFar.Append(currChunkDecodeSteps[refIdx].Whole);
                        thisInfo.DecodedSoFarSelectionLength = currChunkDecodeSteps[refIdx].Whole.Length;
                        thisInfo.DecodedSoFar = decodedSoFar.ToString();
                        thisInfo.Refined = true;
                        decodeStepInfos[currStep] = thisInfo;
                        currStepInfo = thisInfo;
                    }
                }

                DecodedSoFarTextBox.Text = currStepInfo.DecodedSoFar;
                if (currStep == encodedSteps.Length - 1)
                {
                    NextButton.Text = "Close form";
                }
                else
                {
                    NextButton.Text = "Next";
                }
                if (currStep == 0)
                {
                    BackButton.Enabled = false;
                }
                else
                {
                    BackButton.Enabled = true;
                }
            }
            else
            {
                DecodedSoFarTextBox.Text = decodeStepInfos[currStep - 1].DecodedSoFar;
            }
        }
        private void paint()
        {
            if (!isReset)
            {
                int relativeDecodeStepIdx = currStepInfo.RelativeDecodeStepIdx;
                int decodedSoFarSelectionStart = currStepInfo.DecodedSoFar.Length - currStepInfo.DecodedSoFarSelectionLength;
                int decodedSoFarSelectionLength = currStepInfo.DecodedSoFarSelectionLength;

                DecodedSoFarTextBox.SelectionStart = decodedSoFarSelectionStart;
                DecodedSoFarTextBox.SelectionLength = decodedSoFarSelectionLength;
                DecodedSoFarTextBox.SelectionColor = Utils.c1;

                EncodedMessageTextBox.SelectionStart = 2 * currStep;
                EncodedMessageTextBox.SelectionLength = 1;
                EncodedMessageTextBox.SelectionColor = Utils.c3;

                if (showEntriesMax == -1 || currStep + 1 < showEntriesMax)//just not marked steps that are not shown in table(important when onFullDict = stopAdding)
                {
                    if (currStep > 0 && !wasReset)
                    {
                        Label lStart = tableLayoutPanel1.GetControlFromPosition(1, relativeDecodeStepIdx + 1) as Label;
                        lStart.BackColor = Utils.c2;
                    }

                    if (currStep > 0 && !wasReset)
                    {
                        Label lNextPrev = tableLayoutPanel1.GetControlFromPosition(2, relativeDecodeStepIdx) as Label;
                        Label lWholePrev = tableLayoutPanel1.GetControlFromPosition(3, relativeDecodeStepIdx) as Label;

                        lNextPrev.BackColor = Utils.c2;
                        lWholePrev.BackColor = Utils.c2;
                    }

                    Label lWhole = tableLayoutPanel1.GetControlFromPosition(3, relativeDecodeStepIdx + 1) as Label;
                    Label lNext = tableLayoutPanel1.GetControlFromPosition(2, relativeDecodeStepIdx + 1) as Label;
                    if (lNext.Text != "")//mask next character and last character in whole word(this happens only when going backwards)
                    {
                        lNext.Text = "";
                        lWhole.Text = lWhole.Text.Substring(0, lWhole.Text.Length - 1);
                    }
                    lWhole.BackColor = Utils.c1;

                    int refIdx;
                    Int32.TryParse(encodedSteps[currStep], out refIdx);
                    Label lIdx = tableLayoutPanel1.GetControlFromPosition(0, refIdx + 1) as Label;
                    lIdx.BackColor = Utils.c3;
                }
                else
                {
                    int refIdx;
                    Int32.TryParse(encodedSteps[currStep], out refIdx);
                    Label lIdx = tableLayoutPanel1.GetControlFromPosition(0, refIdx + 1) as Label;
                    Label lWhole = tableLayoutPanel1.GetControlFromPosition(3, refIdx + 1) as Label;
                    lIdx.BackColor = Utils.c3;
                    lWhole.BackColor = Utils.c1;
                }
            }
            else
            {
                EncodedMessageTextBox.SelectionStart = 2 * currStep;
                EncodedMessageTextBox.SelectionLength = 1;
                EncodedMessageTextBox.SelectionColor = Utils.c3;
            }

            MessageLabel.Text = currStepInfo.Message;
        }

        private void prepareLocalsForStep()
        {
            isReset = currStepInfo.IsReset;
            lastReset = currStepInfo.LastReset;
            offset = currStepInfo.Offset;
            if (currStep == 0)
            {
                wasReset = false;
            }
            else
            {
                wasReset = decodeStepInfos[currStep - 1].IsReset;
            }

            if (currStepInfo.Entries != null && lastAction == -1)//when going back and encounter reset
            {
                currChunkDecodeSteps = currStepInfo.Entries;
                currChunk--;
            }

            if (lastAction == 1)
            {
                if (isReset)
                {
                    currChunk++;
                    if (totalChunks == currChunk)
                    {
                        if (currStep == decodeStepInfos.Count - 1)//when last chunck is visited first time
                        {
                            lastChunkDecodeSteps = currChunkDecodeSteps;
                        }
                        else //when last chunck is revisited
                        {
                            currChunkDecodeSteps = lastChunkDecodeSteps;
                        }
                    }
                }
            }

            limit = currStep + alphabet.Length + 1 - offset;
            if (showEntriesMax != -1)
            {
                limit = Math.Min(currStep + alphabet.Length + 1 - offset, showEntriesMax + 1);
                if (currStep + alphabet.Length > showEntriesMax)
                {
                    limit--;
                }
            }
        }

        private void NextButton_Click(object sender, EventArgs e)
        {
            currStep++;
            lastAction = 1;
            if (currStep < encodedSteps.Length)
            {
                unsetPreviousStep();
                if (decodeStepInfos.Count == currStep)
                {
                    processCurrInput();
                }
                currStepInfo = decodeStepInfos[currStep];
                prepareLocalsForStep();
                updateFormElems();
                drawTable();
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
            lastAction = -1;
            unsetPreviousStep();
            currStepInfo = decodeStepInfos[currStep];
            prepareLocalsForStep();
            updateFormElems();
            drawTable();
            paint();
            Refresh();

        }
    }
}