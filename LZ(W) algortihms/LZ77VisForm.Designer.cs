
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
            this.WindowLabel.Location = new System.Drawing.Point(52, 80);
            this.WindowLabel.Name = "WindowLabel";
            this.WindowLabel.Size = new System.Drawing.Size(85, 37);
            this.WindowLabel.TabIndex = 0;
            this.WindowLabel.Text = "Window";
            this.WindowLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // RestLabel
            // 
            this.RestLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RestLabel.Location = new System.Drawing.Point(52, 24);
            this.RestLabel.Name = "RestLabel";
            this.RestLabel.Size = new System.Drawing.Size(94, 33);
            this.RestLabel.TabIndex = 1;
            this.RestLabel.Text = "Rest ";
            this.RestLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // CurrentMatchFirstLabel
            // 
            this.CurrentMatchFirstLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CurrentMatchFirstLabel.Location = new System.Drawing.Point(52, 148);
            this.CurrentMatchFirstLabel.Name = "CurrentMatchFirstLabel";
            this.CurrentMatchFirstLabel.Size = new System.Drawing.Size(164, 33);
            this.CurrentMatchFirstLabel.TabIndex = 2;
            this.CurrentMatchFirstLabel.Text = "Match starting in window";
            this.CurrentMatchFirstLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // CurrentMatchSecondLabel
            // 
            this.CurrentMatchSecondLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CurrentMatchSecondLabel.Location = new System.Drawing.Point(52, 219);
            this.CurrentMatchSecondLabel.Name = "CurrentMatchSecondLabel";
            this.CurrentMatchSecondLabel.Size = new System.Drawing.Size(150, 34);
            this.CurrentMatchSecondLabel.TabIndex = 3;
            this.CurrentMatchSecondLabel.Text = "Match starting in rest";
            this.CurrentMatchSecondLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // RestTextBox
            // 
            this.RestTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RestTextBox.Location = new System.Drawing.Point(236, 24);
            this.RestTextBox.Name = "RestTextBox";
            this.RestTextBox.ReadOnly = true;
            this.RestTextBox.Size = new System.Drawing.Size(342, 40);
            this.RestTextBox.TabIndex = 4;
            this.RestTextBox.Text = "";
            // 
            // WindowTextBox
            // 
            this.WindowTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.WindowTextBox.Location = new System.Drawing.Point(236, 80);
            this.WindowTextBox.Name = "WindowTextBox";
            this.WindowTextBox.ReadOnly = true;
            this.WindowTextBox.Size = new System.Drawing.Size(342, 37);
            this.WindowTextBox.TabIndex = 5;
            this.WindowTextBox.Text = "";
            // 
            // CurrentMatchFirstTextBox
            // 
            this.CurrentMatchFirstTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CurrentMatchFirstTextBox.Location = new System.Drawing.Point(236, 145);
            this.CurrentMatchFirstTextBox.Name = "CurrentMatchFirstTextBox";
            this.CurrentMatchFirstTextBox.ReadOnly = true;
            this.CurrentMatchFirstTextBox.Size = new System.Drawing.Size(342, 36);
            this.CurrentMatchFirstTextBox.TabIndex = 6;
            this.CurrentMatchFirstTextBox.Text = "";
            // 
            // CurrentMatchSecondTextBox
            // 
            this.CurrentMatchSecondTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CurrentMatchSecondTextBox.Location = new System.Drawing.Point(236, 216);
            this.CurrentMatchSecondTextBox.Name = "CurrentMatchSecondTextBox";
            this.CurrentMatchSecondTextBox.ReadOnly = true;
            this.CurrentMatchSecondTextBox.Size = new System.Drawing.Size(342, 37);
            this.CurrentMatchSecondTextBox.TabIndex = 7;
            this.CurrentMatchSecondTextBox.Text = "";
            // 
            // NextButton
            // 
            this.NextButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NextButton.Location = new System.Drawing.Point(385, 495);
            this.NextButton.Name = "NextButton";
            this.NextButton.Size = new System.Drawing.Size(157, 44);
            this.NextButton.TabIndex = 10;
            this.NextButton.Text = "Start visualization";
            this.NextButton.UseVisualStyleBackColor = true;
            this.NextButton.Click += new System.EventHandler(this.NextButton_Click);
            // 
            // CurrentOutputLabel
            // 
            this.CurrentOutputLabel.AutoSize = true;
            this.CurrentOutputLabel.Location = new System.Drawing.Point(52, 427);
            this.CurrentOutputLabel.Name = "CurrentOutputLabel";
            this.CurrentOutputLabel.Size = new System.Drawing.Size(77, 13);
            this.CurrentOutputLabel.TabIndex = 11;
            this.CurrentOutputLabel.Text = "Longest match";
            // 
            // LongestMatchLabel
            // 
            this.LongestMatchLabel.AutoSize = true;
            this.LongestMatchLabel.Location = new System.Drawing.Point(52, 459);
            this.LongestMatchLabel.Name = "LongestMatchLabel";
            this.LongestMatchLabel.Size = new System.Drawing.Size(74, 13);
            this.LongestMatchLabel.TabIndex = 12;
            this.LongestMatchLabel.Text = "Current output";
            // 
            // StepNumberLabel
            // 
            this.StepNumberLabel.AutoSize = true;
            this.StepNumberLabel.Location = new System.Drawing.Point(52, 394);
            this.StepNumberLabel.Name = "StepNumberLabel";
            this.StepNumberLabel.Size = new System.Drawing.Size(67, 13);
            this.StepNumberLabel.TabIndex = 15;
            this.StepNumberLabel.Text = "Step number";
            // 
            // BackButton
            // 
            this.BackButton.Enabled = false;
            this.BackButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BackButton.Location = new System.Drawing.Point(164, 495);
            this.BackButton.Name = "BackButton";
            this.BackButton.Size = new System.Drawing.Size(142, 44);
            this.BackButton.TabIndex = 17;
            this.BackButton.Text = "Back";
            this.BackButton.UseVisualStyleBackColor = true;
            this.BackButton.Click += new System.EventHandler(this.BackButton_Click);
            // 
            // CurrentOutputTextBox
            // 
            this.CurrentOutputTextBox.AutoSize = true;
            this.CurrentOutputTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CurrentOutputTextBox.Location = new System.Drawing.Point(161, 459);
            this.CurrentOutputTextBox.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.CurrentOutputTextBox.Name = "CurrentOutputTextBox";
            this.CurrentOutputTextBox.Size = new System.Drawing.Size(0, 13);
            this.CurrentOutputTextBox.TabIndex = 18;
            // 
            // LongestMatchTextBox
            // 
            this.LongestMatchTextBox.AccessibleRole = System.Windows.Forms.AccessibleRole.MenuBar;
            this.LongestMatchTextBox.AutoSize = true;
            this.LongestMatchTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LongestMatchTextBox.Location = new System.Drawing.Point(161, 427);
            this.LongestMatchTextBox.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LongestMatchTextBox.Name = "LongestMatchTextBox";
            this.LongestMatchTextBox.Size = new System.Drawing.Size(0, 13);
            this.LongestMatchTextBox.TabIndex = 19;
            // 
            // MessageTextBox
            // 
            this.MessageTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MessageTextBox.Location = new System.Drawing.Point(237, 287);
            this.MessageTextBox.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.MessageTextBox.Name = "MessageTextBox";
            this.MessageTextBox.Size = new System.Drawing.Size(341, 86);
            this.MessageTextBox.TabIndex = 20;
            // 
            // StepNumberTextBox
            // 
            this.StepNumberTextBox.AutoSize = true;
            this.StepNumberTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StepNumberTextBox.Location = new System.Drawing.Point(161, 394);
            this.StepNumberTextBox.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.StepNumberTextBox.Name = "StepNumberTextBox";
            this.StepNumberTextBox.Size = new System.Drawing.Size(0, 13);
            this.StepNumberTextBox.TabIndex = 21;
            // 
            // LZ77VisForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(674, 580);
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
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
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