namespace MyVisionApp
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.https://docs.microsoft.com/ru-ru/azure/cognitive-services/computer-vision/quickstarts-sdk/csharp-analyze-sdk
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
            this.textBoxLink = new System.Windows.Forms.TextBox();
            this.buttonScan = new System.Windows.Forms.Button();
            this.textBoxObjects = new System.Windows.Forms.TextBox();
            this.textBoxTags = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBoxLink
            // 
            this.textBoxLink.Location = new System.Drawing.Point(28, 31);
            this.textBoxLink.Name = "textBoxLink";
            this.textBoxLink.Size = new System.Drawing.Size(340, 20);
            this.textBoxLink.TabIndex = 0;
            // 
            // buttonScan
            // 
            this.buttonScan.Location = new System.Drawing.Point(390, 28);
            this.buttonScan.Name = "buttonScan";
            this.buttonScan.Size = new System.Drawing.Size(75, 23);
            this.buttonScan.TabIndex = 1;
            this.buttonScan.Text = "Scan";
            this.buttonScan.UseVisualStyleBackColor = true;
            this.buttonScan.Click += new System.EventHandler(this.ButtonScan_Click);
            // 
            // textBoxObjects
            // 
            this.textBoxObjects.Location = new System.Drawing.Point(28, 94);
            this.textBoxObjects.Multiline = true;
            this.textBoxObjects.Name = "textBoxObjects";
            this.textBoxObjects.Size = new System.Drawing.Size(437, 55);
            this.textBoxObjects.TabIndex = 2;
            // 
            // textBoxTags
            // 
            this.textBoxTags.Location = new System.Drawing.Point(28, 182);
            this.textBoxTags.Multiline = true;
            this.textBoxTags.Name = "textBoxTags";
            this.textBoxTags.Size = new System.Drawing.Size(437, 72);
            this.textBoxTags.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 78);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Objects";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 166);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Tags";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(486, 450);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxTags);
            this.Controls.Add(this.textBoxObjects);
            this.Controls.Add(this.buttonScan);
            this.Controls.Add(this.textBoxLink);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxLink;
        private System.Windows.Forms.Button buttonScan;
        private System.Windows.Forms.TextBox textBoxObjects;
        private System.Windows.Forms.TextBox textBoxTags;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}

