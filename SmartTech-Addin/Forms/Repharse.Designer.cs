namespace SmartTech_Addin.Forms
{
    partial class Repharse
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.copyBtn = new System.Windows.Forms.Button();
            this.draftReplyBtn = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.messageBox = new System.Windows.Forms.RichTextBox();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.copyBtn);
            this.panel2.Controls.Add(this.draftReplyBtn);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 302);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(800, 46);
            this.panel2.TabIndex = 1;
            // 
            // copyBtn
            // 
            this.copyBtn.Location = new System.Drawing.Point(713, 3);
            this.copyBtn.Name = "copyBtn";
            this.copyBtn.Size = new System.Drawing.Size(75, 36);
            this.copyBtn.TabIndex = 1;
            this.copyBtn.Text = "Copy";
            this.copyBtn.UseVisualStyleBackColor = true;
            this.copyBtn.Click += new System.EventHandler(this.copyBtn_Click);
            // 
            // draftReplyBtn
            // 
            this.draftReplyBtn.Location = new System.Drawing.Point(632, 3);
            this.draftReplyBtn.Name = "draftReplyBtn";
            this.draftReplyBtn.Size = new System.Drawing.Size(75, 36);
            this.draftReplyBtn.TabIndex = 0;
            this.draftReplyBtn.Text = "Draft Reply";
            this.draftReplyBtn.UseVisualStyleBackColor = true;
            this.draftReplyBtn.Visible = false;
            this.draftReplyBtn.Click += new System.EventHandler(this.draftReplyBtn_Click_1);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.messageBox);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(100);
            this.panel1.Size = new System.Drawing.Size(800, 302);
            this.panel1.TabIndex = 2;
            // 
            // messageBox
            // 
            this.messageBox.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.messageBox.Location = new System.Drawing.Point(10, 0);
            this.messageBox.Margin = new System.Windows.Forms.Padding(20, 3, 6, 20);
            this.messageBox.Name = "messageBox";
            this.messageBox.Size = new System.Drawing.Size(784, 302);
            this.messageBox.TabIndex = 3;
            this.messageBox.Text = "";
            // 
            // Repharse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 348);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.MaximizeBox = false;
            this.Name = "Repharse";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Repharse";
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button copyBtn;
        private System.Windows.Forms.Button draftReplyBtn;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RichTextBox messageBox;
    }
}