
using static LZ_W__algortihms.Utils;
using System.Collections.Generic;

namespace LZ_W__algortihms
{
    partial class LZ77VisForm
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
            this.NextButton = new System.Windows.Forms.Button();
            this.CurrentOutputLabel = new System.Windows.Forms.Label();
            this.LongestMatchLabel = new System.Windows.Forms.Label();
            this.StepNumberLabel = new System.Windows.Forms.Label();
            this.BackButton = new System.Windows.Forms.Button();
            this.CurrentOutputTextBox = new System.Windows.Forms.Label();
            this.LongestMatchTextBox = new System.Windows.Forms.Label();
            this.MessageTextBox = new System.Windows.Forms.Label();
            this.StepNumberTextBox = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // WindowLabel
            // 
            this.WindowLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.WindowLabel.Location = new System.Drawing.Point(69, 98);
            this.WindowLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.WindowLabel.Name = "WindowLabel";
            this.WindowLabel.Size = new System.Drawing.Size(113, 45);
            this.WindowLabel.TabIndex = 0;
            this.WindowLabel.Text = "Window";
            this.WindowLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // RestLabel
            // 
            this.RestLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RestLabel.Location = new System.Drawing.Point(69, 30);
            this.RestLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.RestLabel.Name = "RestLabel";
            this.RestLabel.Size = new System.Drawing.Size(126, 41);
            this.RestLabel.TabIndex = 1;
            this.RestLabel.Text = "Rest ";
            this.RestLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // CurrentMatchFirstLabel
            // 
            this.CurrentMatchFirstLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CurrentMatchFirstLabel.Location = new System.Drawing.Point(69, 182);
            this.CurrentMatchFirstLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.CurrentMatchFirstLabel.Name = "CurrentMatchFirstLabel";
            this.CurrentMatchFirstLabel.Size = new System.Drawing.Size(219, 41);
            this.CurrentMatchFirstLabel.TabIndex = 2;
            this.CurrentMatchFirstLabel.Text = "Match starting in window";
            this.CurrentMatchFirstLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // CurrentMatchSecondLabel
            // 
            this.CurrentMatchSecondLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CurrentMatchSecondLabel.Location = new System.Drawing.Point(69, 269);
            this.CurrentMatchSecondLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.CurrentMatchSecondLabel.Name = "CurrentMatchSecondLabel";
            this.CurrentMatchSecondLabel.Size = new System.Drawing.Size(200, 42);
            this.CurrentMatchSecondLabel.TabIndex = 3;
            this.CurrentMatchSecondLabel.Text = "Match starting in rest";
            this.CurrentMatchSecondLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // RestTextBox
            // 
            this.RestTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RestTextBox.Location = new System.Drawing.Point(314, 30);
            this.RestTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.RestTextBox.Name = "RestTextBox";
            this.RestTextBox.ReadOnly = true;
            this.RestTextBox.Size = new System.Drawing.Size(455, 48);
            this.RestTextBox.TabIndex = 4;
            this.RestTextBox.Text = "";
            // 
            // WindowTextBox
            // 
            this.WindowTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.WindowTextBox.Location = new System.Drawing.Point(314, 98);
            this.WindowTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.WindowTextBox.Name = "WindowTextBox";
            this.WindowTextBox.ReadOnly = true;
            this.WindowTextBox.Size = new System.Drawing.Size(455, 45);
            this.WindowTextBox.TabIndex = 5;
            this.WindowTextBox.Text = "";
            // 
            // CurrentMatchFirstTextBox
            // 
            this.CurrentMatchFirstTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CurrentMatchFirstTextBox.Location = new System.Drawing.Point(314, 179);
            this.CurrentMatchFirstTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.CurrentMatchFirstTextBox.Name = "CurrentMatchFirstTextBox";
            this.CurrentMatchFirstTextBox.ReadOnly = true;
            this.CurrentMatchFirstTextBox.Size = new System.Drawing.Size(455, 44);
            this.CurrentMatchFirstTextBox.TabIndex = 6;
            this.CurrentMatchFirstTextBox.Text = "";
            // 
            // CurrentMatchSecondTextBox
            // 
            this.CurrentMatchSecondTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CurrentMatchSecondTextBox.Location = new System.Drawing.Point(314, 266);
            this.CurrentMatchSecondTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.CurrentMatchSecondTextBox.Name = "CurrentMatchSecondTextBox";
            this.CurrentMatchSecondTextBox.ReadOnly = true;
            this.CurrentMatchSecondTextBox.Size = new System.Drawing.Size(455, 45);
            this.CurrentMatchSecondTextBox.TabIndex = 7;
            this.CurrentMatchSecondTextBox.Text = "";
            // 
            // NextButton
            // 
            this.NextButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NextButton.Location = new System.Drawing.Point(513, 609);
            this.NextButton.Margin = new System.Windows.Forms.Padding(4);
            this.NextButton.Name = "NextButton";
            this.NextButton.Size = new System.Drawing.Size(209, 54);
            this.NextButton.TabIndex = 10;
            this.NextButton.Text = "Start visualization";
            this.NextButton.UseVisualStyleBackColor = true;
            this.NextButton.Click += new System.EventHandler(this.NextButton_Click);
            // 
            // CurrentOutputLabel
            // 
            this.CurrentOutputLabel.AutoSize = true;
            this.CurrentOutputLabel.Location = new System.Drawing.Point(81, 484);
            this.CurrentOutputLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.CurrentOutputLabel.Name = "CurrentOutputLabel";
            this.CurrentOutputLabel.Size = new System.Drawing.Size(99, 17);
            this.CurrentOutputLabel.TabIndex = 11;
            this.CurrentOutputLabel.Text = "Current output";
            // 
            // LongestMatchLabel
            // 
            this.LongestMatchLabel.AutoSize = true;
            this.LongestMatchLabel.Location = new System.Drawing.Point(81, 523);
            this.LongestMatchLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LongestMatchLabel.Name = "LongestMatchLabel";
            this.LongestMatchLabel.Size = new System.Drawing.Size(101, 17);
            this.LongestMatchLabel.TabIndex = 12;
            this.LongestMatchLabel.Text = "Longest match";
            // 
            // StepNumberLabel
            // 
            this.StepNumberLabel.AutoSize = true;
            this.StepNumberLabel.Location = new System.Drawing.Point(81, 443);
            this.StepNumberLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.StepNumberLabel.Name = "StepNumberLabel";
            this.StepNumberLabel.Size = new System.Drawing.Size(89, 17);
            this.StepNumberLabel.TabIndex = 15;
            this.StepNumberLabel.Text = "Step number";
            // 
            // BackButton
            // 
            this.BackButton.Enabled = false;
            this.BackButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BackButton.Location = new System.Drawing.Point(219, 609);
            this.BackButton.Margin = new System.Windows.Forms.Padding(4);
            this.BackButton.Name = "BackButton";
            this.BackButton.Size = new System.Drawing.Size(190, 54);
            this.BackButton.TabIndex = 17;
            this.BackButton.Text = "Back";
            this.BackButton.UseVisualStyleBackColor = true;
            this.BackButton.Click += new System.EventHandler(this.BackButton_Click);
            // 
            // CurrentOutputTextBox
            // 
            this.CurrentOutputTextBox.AutoSize = true;
            this.CurrentOutputTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CurrentOutputTextBox.Location = new System.Drawing.Point(227, 523);
            this.CurrentOutputTextBox.Name = "CurrentOutputTextBox";
            this.CurrentOutputTextBox.Size = new System.Drawing.Size(52, 17);
            this.CurrentOutputTextBox.TabIndex = 18;
            this.CurrentOutputTextBox.Text = "label1";
            // 
            // LongestMatchTextBox
            // 
            this.LongestMatchTextBox.AccessibleRole = System.Windows.Forms.AccessibleRole.MenuBar;
            this.LongestMatchTextBox.AutoSize = true;
            this.LongestMatchTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LongestMatchTextBox.Location = new System.Drawing.Point(227, 484);
            this.LongestMatchTextBox.Name = "LongestMatchTextBox";
            this.LongestMatchTextBox.Size = new System.Drawing.Size(61, 17);
            this.LongestMatchTextBox.TabIndex = 19;
            this.LongestMatchTextBox.Text = "label18";
            // 
            // MessageTextBox
            // 
            this.MessageTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MessageTextBox.Location = new System.Drawing.Point(314, 354);
            this.MessageTextBox.Name = "MessageTextBox";
            this.MessageTextBox.Size = new System.Drawing.Size(455, 106);
            this.MessageTextBox.TabIndex = 20;
            this.MessageTextBox.Text = "label1";
            // 
            // StepNumberTextBox
            // 
            this.StepNumberTextBox.AutoSize = true;
            this.StepNumberTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StepNumberTextBox.Location = new System.Drawing.Point(227, 443);
            this.StepNumberTextBox.Name = "StepNumberTextBox";
            this.StepNumberTextBox.Size = new System.Drawing.Size(52, 17);
            this.StepNumberTextBox.TabIndex = 21;
            this.StepNumberTextBox.Text = "label1";
            // 
            // LZ77VisForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(898, 714);
            this.Controls.Add(this.StepNumberTextBox);
            this.Controls.Add(this.MessageTextBox);
            this.Controls.Add(this.LongestMatchTextBox);
            this.Controls.Add(this.CurrentOutputTextBox);
            this.Controls.Add(this.BackButton);
            this.Controls.Add(this.StepNumberLabel);
            this.Controls.Add(this.LongestMatchLabel);
            this.Controls.Add(this.CurrentOutputLabel);
            this.Controls.Add(this.NextButton);
            this.Controls.Add(this.CurrentMatchSecondTextBox);
            this.Controls.Add(this.CurrentMatchFirstTextBox);
            this.Controls.Add(this.WindowTextBox);
            this.Controls.Add(this.RestTextBox);
            this.Controls.Add(this.CurrentMatchSecondLabel);
            this.Controls.Add(this.CurrentMatchFirstLabel);
            this.Controls.Add(this.RestLabel);
            this.Controls.Add(this.WindowLabel);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "LZ77VisForm";
            this.Text = "LZ77 Algorithm Visualization";
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
        private System.Windows.Forms.Button NextButton;
        private System.Windows.Forms.Label CurrentOutputLabel;
        private System.Windows.Forms.Label LongestMatchLabel;
        
        private int position;
        private string input;
        private int windowSize;
        private int currIdx;
        private List<StepInfo> infos;
        private System.Windows.Forms.Label StepNumberLabel;
        private System.Windows.Forms.Button BackButton;
        private System.Windows.Forms.Label CurrentOutputTextBox;
        private System.Windows.Forms.Label LongestMatchTextBox;
        private System.Windows.Forms.Label MessageTextBox;
        private System.Windows.Forms.Label StepNumberTextBox;
    }
}