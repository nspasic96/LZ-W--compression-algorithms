using System.Collections.Generic;
using System.Text;
using static LZ_W__algortihms.Utils;

namespace LZ_W__algortihms
{
    partial class LZ77_Decode
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.EncodedMessageTextBox = new System.Windows.Forms.RichTextBox();
            this.DecodedSoFarTextBox = new System.Windows.Forms.RichTextBox();
            this.NextButton = new System.Windows.Forms.Button();
            this.EncodedLabel = new System.Windows.Forms.Label();
            this.DecodedSoFarLabel = new System.Windows.Forms.Label();
            this.MatchTextBox = new System.Windows.Forms.RichTextBox();
            this.MatchLabel = new System.Windows.Forms.Label();
            this.BackButton = new System.Windows.Forms.Button();
            this.MessageLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // EncodedMessageTextBox
            // 
            this.EncodedMessageTextBox.Location = new System.Drawing.Point(225, 12);
            this.EncodedMessageTextBox.Name = "EncodedMessageTextBox";
            this.EncodedMessageTextBox.ReadOnly = true;
            this.EncodedMessageTextBox.Size = new System.Drawing.Size(462, 63);
            this.EncodedMessageTextBox.TabIndex = 0;
            this.EncodedMessageTextBox.Text = "";
            // 
            // DecodedSoFarTextBox
            // 
            this.DecodedSoFarTextBox.Location = new System.Drawing.Point(225, 234);
            this.DecodedSoFarTextBox.Name = "DecodedSoFarTextBox";
            this.DecodedSoFarTextBox.ReadOnly = true;
            this.DecodedSoFarTextBox.Size = new System.Drawing.Size(463, 67);
            this.DecodedSoFarTextBox.TabIndex = 1;
            this.DecodedSoFarTextBox.Text = "";
            // 
            // NextButton
            // 
            this.NextButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NextButton.Location = new System.Drawing.Point(480, 449);
            this.NextButton.Name = "NextButton";
            this.NextButton.Size = new System.Drawing.Size(113, 50);
            this.NextButton.TabIndex = 2;
            this.NextButton.Text = "Next";
            this.NextButton.UseVisualStyleBackColor = true;
            this.NextButton.Click += new System.EventHandler(this.NextButton_Click);
            // 
            // EncodedLabel
            // 
            this.EncodedLabel.AutoSize = true;
            this.EncodedLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EncodedLabel.Location = new System.Drawing.Point(68, 29);
            this.EncodedLabel.Name = "EncodedLabel";
            this.EncodedLabel.Size = new System.Drawing.Size(99, 18);
            this.EncodedLabel.TabIndex = 3;
            this.EncodedLabel.Text = "Encoded data";
            // 
            // DecodedSoFarLabel
            // 
            this.DecodedSoFarLabel.AutoSize = true;
            this.DecodedSoFarLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DecodedSoFarLabel.Location = new System.Drawing.Point(68, 251);
            this.DecodedSoFarLabel.Name = "DecodedSoFarLabel";
            this.DecodedSoFarLabel.Size = new System.Drawing.Size(110, 18);
            this.DecodedSoFarLabel.TabIndex = 4;
            this.DecodedSoFarLabel.Text = "Decoded so far";
            // 
            // MatchTextBox
            // 
            this.MatchTextBox.Location = new System.Drawing.Point(225, 129);
            this.MatchTextBox.Name = "MatchTextBox";
            this.MatchTextBox.ReadOnly = true;
            this.MatchTextBox.Size = new System.Drawing.Size(462, 62);
            this.MatchTextBox.TabIndex = 5;
            this.MatchTextBox.Text = "";
            // 
            // MatchLabel
            // 
            this.MatchLabel.AutoSize = true;
            this.MatchLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MatchLabel.Location = new System.Drawing.Point(68, 150);
            this.MatchLabel.Name = "MatchLabel";
            this.MatchLabel.Size = new System.Drawing.Size(49, 18);
            this.MatchLabel.TabIndex = 6;
            this.MatchLabel.Text = "Match";
            // 
            // BackButton
            // 
            this.BackButton.Enabled = false;
            this.BackButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BackButton.Location = new System.Drawing.Point(225, 449);
            this.BackButton.Name = "BackButton";
            this.BackButton.Size = new System.Drawing.Size(100, 50);
            this.BackButton.TabIndex = 7;
            this.BackButton.Text = "Back";
            this.BackButton.UseVisualStyleBackColor = true;
            this.BackButton.Click += new System.EventHandler(this.BackButton_Click);
            // 
            // MessageLabel
            // 
            this.MessageLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MessageLabel.Location = new System.Drawing.Point(225, 286);
            this.MessageLabel.Name = "MessageLabel";
            this.MessageLabel.Size = new System.Drawing.Size(463, 87);
            this.MessageLabel.TabIndex = 8;
            // 
            // LZ77_Decode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(850, 543);
            this.Controls.Add(this.MessageLabel);
            this.Controls.Add(this.BackButton);
            this.Controls.Add(this.MatchLabel);
            this.Controls.Add(this.MatchTextBox);
            this.Controls.Add(this.DecodedSoFarLabel);
            this.Controls.Add(this.EncodedLabel);
            this.Controls.Add(this.NextButton);
            this.Controls.Add(this.DecodedSoFarTextBox);
            this.Controls.Add(this.EncodedMessageTextBox);
            this.Name = "LZ77_Decode";
            this.Text = "LZ77_Decode";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox EncodedMessageTextBox;
        private System.Windows.Forms.RichTextBox DecodedSoFarTextBox;
        private System.Windows.Forms.Button NextButton;
        private System.Windows.Forms.Label EncodedLabel;
        private System.Windows.Forms.Label DecodedSoFarLabel;
        private List<StepInfo> encodeSteps;
        private string encodedMessage;
        private StringBuilder decodedSoFar;
        private System.Windows.Forms.RichTextBox MatchTextBox;
        private System.Windows.Forms.Label MatchLabel;
        private System.Windows.Forms.Button BackButton;
        private System.Windows.Forms.Label MessageLabel;
    }
}