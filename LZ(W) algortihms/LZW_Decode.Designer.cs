namespace LZ_W__algortihms
{
    partial class LZW_Decode
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.EncodedMessageLabel = new System.Windows.Forms.Label();
            this.DecodedSoFarLabel = new System.Windows.Forms.Label();
            this.NextButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // EncodedMessageTextBox
            // 
            this.EncodedMessageTextBox.Location = new System.Drawing.Point(324, 24);
            this.EncodedMessageTextBox.Name = "EncodedMessageTextBox";
            this.EncodedMessageTextBox.ReadOnly = true;
            this.EncodedMessageTextBox.Size = new System.Drawing.Size(413, 57);
            this.EncodedMessageTextBox.TabIndex = 0;
            this.EncodedMessageTextBox.Text = "";
            // 
            // DecodedSoFarTextBox
            // 
            this.DecodedSoFarTextBox.Location = new System.Drawing.Point(326, 98);
            this.DecodedSoFarTextBox.Name = "DecodedSoFarTextBox";
            this.DecodedSoFarTextBox.ReadOnly = true;
            this.DecodedSoFarTextBox.Size = new System.Drawing.Size(411, 55);
            this.DecodedSoFarTextBox.TabIndex = 1;
            this.DecodedSoFarTextBox.Text = "";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Location = new System.Drawing.Point(67, 173);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(669, 168);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // EncodedMessageLabel
            // 
            this.EncodedMessageLabel.AutoSize = true;
            this.EncodedMessageLabel.Location = new System.Drawing.Point(143, 47);
            this.EncodedMessageLabel.Name = "EncodedMessageLabel";
            this.EncodedMessageLabel.Size = new System.Drawing.Size(95, 13);
            this.EncodedMessageLabel.TabIndex = 3;
            this.EncodedMessageLabel.Text = "Encoded message";
            // 
            // DecodedSoFarLabel
            // 
            this.DecodedSoFarLabel.AutoSize = true;
            this.DecodedSoFarLabel.Location = new System.Drawing.Point(143, 117);
            this.DecodedSoFarLabel.Name = "DecodedSoFarLabel";
            this.DecodedSoFarLabel.Size = new System.Drawing.Size(80, 13);
            this.DecodedSoFarLabel.TabIndex = 4;
            this.DecodedSoFarLabel.Text = "Decoded so far";
            // 
            // NextButton
            // 
            this.NextButton.Location = new System.Drawing.Point(418, 377);
            this.NextButton.Name = "NextButton";
            this.NextButton.Size = new System.Drawing.Size(241, 52);
            this.NextButton.TabIndex = 5;
            this.NextButton.Text = "Next";
            this.NextButton.UseVisualStyleBackColor = true;
            this.NextButton.Click += new System.EventHandler(this.NextButton_Click);
            // 
            // LZW_Decode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.NextButton);
            this.Controls.Add(this.DecodedSoFarLabel);
            this.Controls.Add(this.EncodedMessageLabel);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.DecodedSoFarTextBox);
            this.Controls.Add(this.EncodedMessageTextBox);
            this.Name = "LZW_Decode";
            this.Text = "LZW_Decode";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox EncodedMessageTextBox;
        private System.Windows.Forms.RichTextBox DecodedSoFarTextBox;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label EncodedMessageLabel;
        private System.Windows.Forms.Label DecodedSoFarLabel;
        private System.Windows.Forms.Button NextButton;
    }
}