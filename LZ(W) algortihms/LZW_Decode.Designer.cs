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
            this.BackButton = new System.Windows.Forms.Button();
            this.MessageLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // EncodedMessageTextBox
            // 
            this.EncodedMessageTextBox.Location = new System.Drawing.Point(186, 24);
            this.EncodedMessageTextBox.Name = "EncodedMessageTextBox";
            this.EncodedMessageTextBox.ReadOnly = true;
            this.EncodedMessageTextBox.Size = new System.Drawing.Size(224, 57);
            this.EncodedMessageTextBox.TabIndex = 0;
            this.EncodedMessageTextBox.Text = "";
            // 
            // DecodedSoFarTextBox
            // 
            this.DecodedSoFarTextBox.Location = new System.Drawing.Point(575, 21);
            this.DecodedSoFarTextBox.Name = "DecodedSoFarTextBox";
            this.DecodedSoFarTextBox.ReadOnly = true;
            this.DecodedSoFarTextBox.Size = new System.Drawing.Size(316, 55);
            this.DecodedSoFarTextBox.TabIndex = 1;
            this.DecodedSoFarTextBox.Text = "";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Location = new System.Drawing.Point(67, 87);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(840, 324);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // EncodedMessageLabel
            // 
            this.EncodedMessageLabel.AutoSize = true;
            this.EncodedMessageLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EncodedMessageLabel.Location = new System.Drawing.Point(48, 40);
            this.EncodedMessageLabel.Name = "EncodedMessageLabel";
            this.EncodedMessageLabel.Size = new System.Drawing.Size(132, 18);
            this.EncodedMessageLabel.TabIndex = 3;
            this.EncodedMessageLabel.Text = "Encoded message";
            // 
            // DecodedSoFarLabel
            // 
            this.DecodedSoFarLabel.AutoSize = true;
            this.DecodedSoFarLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DecodedSoFarLabel.Location = new System.Drawing.Point(459, 40);
            this.DecodedSoFarLabel.Name = "DecodedSoFarLabel";
            this.DecodedSoFarLabel.Size = new System.Drawing.Size(110, 18);
            this.DecodedSoFarLabel.TabIndex = 4;
            this.DecodedSoFarLabel.Text = "Decoded so far";
            // 
            // NextButton
            // 
            this.NextButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NextButton.Location = new System.Drawing.Point(575, 522);
            this.NextButton.Name = "NextButton";
            this.NextButton.Size = new System.Drawing.Size(160, 48);
            this.NextButton.TabIndex = 5;
            this.NextButton.Text = "Next";
            this.NextButton.UseVisualStyleBackColor = true;
            this.NextButton.Click += new System.EventHandler(this.NextButton_Click);
            // 
            // BackButton
            // 
            this.BackButton.Enabled = false;
            this.BackButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BackButton.Location = new System.Drawing.Point(274, 522);
            this.BackButton.Name = "BackButton";
            this.BackButton.Size = new System.Drawing.Size(148, 48);
            this.BackButton.TabIndex = 6;
            this.BackButton.Text = "Back";
            this.BackButton.UseVisualStyleBackColor = true;
            this.BackButton.Click += new System.EventHandler(this.BackButton_Click);
            // 
            // MessageLabel
            // 
            this.MessageLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MessageLabel.Location = new System.Drawing.Point(67, 414);
            this.MessageLabel.Name = "MessageLabel";
            this.MessageLabel.Size = new System.Drawing.Size(840, 86);
            this.MessageLabel.TabIndex = 7;
            // 
            // LZW_Decode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(947, 582);
            this.Controls.Add(this.MessageLabel);
            this.Controls.Add(this.BackButton);
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
        private System.Windows.Forms.Button BackButton;
        private System.Windows.Forms.Label MessageLabel;
    }
}