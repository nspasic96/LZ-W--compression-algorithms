using System.Collections.Generic;
using static LZ_W__algortihms.Utils;

namespace LZ_W__algortihms
{
    partial class LZWVisForm
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
            this.InputTextBoxLabel = new System.Windows.Forms.Label();
            this.InputTextBox = new System.Windows.Forms.RichTextBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.MessageLabel = new System.Windows.Forms.Label();
            this.MessageTextBox = new System.Windows.Forms.TextBox();
            this.NextButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // InputTextBoxLabel
            // 
            this.InputTextBoxLabel.AutoSize = true;
            this.InputTextBoxLabel.Location = new System.Drawing.Point(90, 44);
            this.InputTextBoxLabel.Name = "InputTextBoxLabel";
            this.InputTextBoxLabel.Size = new System.Drawing.Size(51, 13);
            this.InputTextBoxLabel.TabIndex = 2;
            this.InputTextBoxLabel.Text = "Input text";
            // 
            // InputTextBox
            // 
            this.InputTextBox.Enabled = false;
            this.InputTextBox.Location = new System.Drawing.Point(238, 44);
            this.InputTextBox.Name = "InputTextBox";
            this.InputTextBox.Size = new System.Drawing.Size(292, 23);
            this.InputTextBox.TabIndex = 3;
            this.InputTextBox.Text = "";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Location = new System.Drawing.Point(68, 73);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(913, 446);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // MessageLabel
            // 
            this.MessageLabel.AutoSize = true;
            this.MessageLabel.Location = new System.Drawing.Point(102, 542);
            this.MessageLabel.Name = "MessageLabel";
            this.MessageLabel.Size = new System.Drawing.Size(50, 13);
            this.MessageLabel.TabIndex = 5;
            this.MessageLabel.Text = "Message";
            // 
            // MessageTextBox
            // 
            this.MessageTextBox.Enabled = false;
            this.MessageTextBox.Location = new System.Drawing.Point(196, 535);
            this.MessageTextBox.Name = "MessageTextBox";
            this.MessageTextBox.Size = new System.Drawing.Size(575, 20);
            this.MessageTextBox.TabIndex = 6;
            // 
            // NextButton
            // 
            this.NextButton.Location = new System.Drawing.Point(861, 532);
            this.NextButton.Name = "NextButton";
            this.NextButton.Size = new System.Drawing.Size(75, 23);
            this.NextButton.TabIndex = 7;
            this.NextButton.Text = "Next";
            this.NextButton.UseVisualStyleBackColor = true;
            this.NextButton.Click += new System.EventHandler(this.NextButton_Click);
            // 
            // LZWVisForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1038, 584);
            this.Controls.Add(this.NextButton);
            this.Controls.Add(this.MessageTextBox);
            this.Controls.Add(this.MessageLabel);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.InputTextBox);
            this.Controls.Add(this.InputTextBoxLabel);
            this.Name = "LZWVisForm";
            this.Text = "LZW Algorithm Visualization";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label InputTextBoxLabel;
        private System.Windows.Forms.RichTextBox InputTextBox;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label MessageLabel;
        private System.Windows.Forms.TextBox MessageTextBox;
        private System.Windows.Forms.Button NextButton;
        private List<StepInfo> infos;
        private LZWEntry newOne;
        private int currIdx;
        private int cnt;
    }
}