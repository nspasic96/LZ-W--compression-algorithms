
using static LZ_W__algortihms.Utils;
using System.Collections.Generic;

namespace LZ_W__algortihms
{
    partial class Form2
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
            this.WindowLabel = new System.Windows.Forms.Label();
            this.RestLabel = new System.Windows.Forms.Label();
            this.CurrentMatchFirstLabel = new System.Windows.Forms.Label();
            this.CurrentMatchSecondLabel = new System.Windows.Forms.Label();
            this.RestTextBox = new System.Windows.Forms.RichTextBox();
            this.WindowTextBox = new System.Windows.Forms.RichTextBox();
            this.CurrentMatchFirstTextBox = new System.Windows.Forms.RichTextBox();
            this.CurrentMatchSecondTextBox = new System.Windows.Forms.RichTextBox();
            this.CurrentOutputTextBox = new System.Windows.Forms.TextBox();
            this.LongestMatchTextBox = new System.Windows.Forms.TextBox();
            this.NextButton = new System.Windows.Forms.Button();
            this.CurrentOutputLabel = new System.Windows.Forms.Label();
            this.LongestMatchLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // WindowLabel
            // 
            this.WindowLabel.AutoSize = true;
            this.WindowLabel.Location = new System.Drawing.Point(68, 84);
            this.WindowLabel.Name = "WindowLabel";
            this.WindowLabel.Size = new System.Drawing.Size(46, 13);
            this.WindowLabel.TabIndex = 0;
            this.WindowLabel.Text = "Window";
            // 
            // RestLabel
            // 
            this.RestLabel.AutoSize = true;
            this.RestLabel.Location = new System.Drawing.Point(68, 56);
            this.RestLabel.Name = "RestLabel";
            this.RestLabel.Size = new System.Drawing.Size(32, 13);
            this.RestLabel.TabIndex = 1;
            this.RestLabel.Text = "Rest ";
            // 
            // CurrentMatchFirstLabel
            // 
            this.CurrentMatchFirstLabel.AutoSize = true;
            this.CurrentMatchFirstLabel.Location = new System.Drawing.Point(68, 118);
            this.CurrentMatchFirstLabel.Name = "CurrentMatchFirstLabel";
            this.CurrentMatchFirstLabel.Size = new System.Drawing.Size(82, 13);
            this.CurrentMatchFirstLabel.TabIndex = 2;
            this.CurrentMatchFirstLabel.Text = "Current match 1";
            // 
            // CurrentMatchSecondLabel
            // 
            this.CurrentMatchSecondLabel.AutoSize = true;
            this.CurrentMatchSecondLabel.Location = new System.Drawing.Point(68, 147);
            this.CurrentMatchSecondLabel.Name = "CurrentMatchSecondLabel";
            this.CurrentMatchSecondLabel.Size = new System.Drawing.Size(82, 13);
            this.CurrentMatchSecondLabel.TabIndex = 3;
            this.CurrentMatchSecondLabel.Text = "Current match 2";
            // 
            // RestTextBox
            // 
            this.RestTextBox.Location = new System.Drawing.Point(324, 56);
            this.RestTextBox.Name = "RestTextBox";
            this.RestTextBox.Size = new System.Drawing.Size(342, 21);
            this.RestTextBox.TabIndex = 4;
            this.RestTextBox.ReadOnly = true;
            this.RestTextBox.Text = "";
            // 
            // WindowTextBox
            // 
            this.WindowTextBox.Location = new System.Drawing.Point(324, 84);
            this.WindowTextBox.Name = "WindowTextBox";
            this.WindowTextBox.Size = new System.Drawing.Size(342, 23);
            this.WindowTextBox.TabIndex = 5;
            this.WindowTextBox.ReadOnly = true;
            this.WindowTextBox.Text = "";
            // 
            // CurrentMatchFirstTextBox
            // 
            this.CurrentMatchFirstTextBox.Location = new System.Drawing.Point(324, 118);
            this.CurrentMatchFirstTextBox.Name = "CurrentMatchFirstTextBox";
            this.CurrentMatchFirstTextBox.Size = new System.Drawing.Size(342, 23);
            this.CurrentMatchFirstTextBox.TabIndex = 6;
            this.CurrentMatchFirstTextBox.ReadOnly = true;
            this.CurrentMatchFirstTextBox.Text = "";
            // 
            // CurrentMatchSecondTextBox
            // 
            this.CurrentMatchSecondTextBox.Location = new System.Drawing.Point(324, 147);
            this.CurrentMatchSecondTextBox.Name = "CurrentMatchSecondTextBox";
            this.CurrentMatchSecondTextBox.Size = new System.Drawing.Size(342, 22);
            this.CurrentMatchSecondTextBox.TabIndex = 7;
            this.CurrentMatchSecondTextBox.ReadOnly = true;
            this.CurrentMatchSecondTextBox.Text = "";
            // 
            // CurrentOutputTextBox
            // 
            this.CurrentOutputTextBox.Location = new System.Drawing.Point(370, 215);
            this.CurrentOutputTextBox.Name = "CurrentOutputTextBox";
            this.CurrentOutputTextBox.Size = new System.Drawing.Size(100, 20);
            this.CurrentOutputTextBox.ReadOnly = true;
            this.CurrentOutputTextBox.TabIndex = 8;
            // 
            // LongestMatchTextBox
            // 
            this.LongestMatchTextBox.Location = new System.Drawing.Point(370, 253);
            this.LongestMatchTextBox.Name = "LongestMatchTextBox";
            this.LongestMatchTextBox.Size = new System.Drawing.Size(100, 20);
            this.LongestMatchTextBox.ReadOnly = true;
            this.LongestMatchTextBox.TabIndex = 9;
            // 
            // NextButton
            // 
            this.NextButton.Location = new System.Drawing.Point(370, 305);
            this.NextButton.Name = "NextButton";
            this.NextButton.Size = new System.Drawing.Size(75, 23);
            this.NextButton.TabIndex = 10;
            this.NextButton.Text = "Next";
            this.NextButton.UseVisualStyleBackColor = true;
            this.NextButton.Click += new System.EventHandler(this.NextButton_Click);
            // 
            // CurrentOutputLabel
            // 
            this.CurrentOutputLabel.AutoSize = true;
            this.CurrentOutputLabel.Location = new System.Drawing.Point(239, 222);
            this.CurrentOutputLabel.Name = "CurrentOutputLabel";
            this.CurrentOutputLabel.Size = new System.Drawing.Size(74, 13);
            this.CurrentOutputLabel.TabIndex = 11;
            this.CurrentOutputLabel.Text = "Current output";
            // 
            // LongestMatchLabel
            // 
            this.LongestMatchLabel.AutoSize = true;
            this.LongestMatchLabel.Location = new System.Drawing.Point(239, 260);
            this.LongestMatchLabel.Name = "LongestMatchLabel";
            this.LongestMatchLabel.Size = new System.Drawing.Size(77, 13);
            this.LongestMatchLabel.TabIndex = 12;
            this.LongestMatchLabel.Text = "Longest match";
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.LongestMatchLabel);
            this.Controls.Add(this.CurrentOutputLabel);
            this.Controls.Add(this.NextButton);
            this.Controls.Add(this.LongestMatchTextBox);
            this.Controls.Add(this.CurrentOutputTextBox);
            this.Controls.Add(this.CurrentMatchSecondTextBox);
            this.Controls.Add(this.CurrentMatchFirstTextBox);
            this.Controls.Add(this.WindowTextBox);
            this.Controls.Add(this.RestTextBox);
            this.Controls.Add(this.CurrentMatchSecondLabel);
            this.Controls.Add(this.CurrentMatchFirstLabel);
            this.Controls.Add(this.RestLabel);
            this.Controls.Add(this.WindowLabel);
            this.Name = "Form2";
            this.Text = "Form2";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label WindowLabel;
        private System.Windows.Forms.Label RestLabel;
        private System.Windows.Forms.Label CurrentMatchFirstLabel;
        private System.Windows.Forms.Label CurrentMatchSecondLabel;
        private System.Windows.Forms.RichTextBox RestTextBox;
        private System.Windows.Forms.RichTextBox WindowTextBox;
        private System.Windows.Forms.RichTextBox CurrentMatchFirstTextBox;
        private System.Windows.Forms.RichTextBox CurrentMatchSecondTextBox;
        private System.Windows.Forms.TextBox CurrentOutputTextBox;
        private System.Windows.Forms.TextBox LongestMatchTextBox;
        private System.Windows.Forms.Button NextButton;
        private System.Windows.Forms.Label CurrentOutputLabel;
        private System.Windows.Forms.Label LongestMatchLabel;
        
        private int position;
        private string input;
        private int windowSize;
        private int currIdx;
        private List<StepInfo> infos;
    }
}