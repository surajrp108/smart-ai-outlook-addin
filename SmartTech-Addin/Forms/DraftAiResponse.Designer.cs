namespace SmartTech_Addin.Forms
{
    partial class DraftAiResponse
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
            this.mainTable = new System.Windows.Forms.TableLayoutPanel();
            this.drftAiResponseLbl = new System.Windows.Forms.Label();
            this.subjectLbl = new System.Windows.Forms.Label();
            this.subjectBox = new System.Windows.Forms.TextBox();
            this.mainContentPanel = new System.Windows.Forms.Panel();
            this.messageBox = new System.Windows.Forms.RichTextBox();
            this.mainButtonPanel = new System.Windows.Forms.Panel();
            this.buttonPanel = new System.Windows.Forms.Panel();
            this.cpy2ClipBoardBtn = new System.Windows.Forms.Button();
            this.draftReplyBtn = new System.Windows.Forms.Button();
            this.mainTable.SuspendLayout();
            this.mainContentPanel.SuspendLayout();
            this.mainButtonPanel.SuspendLayout();
            this.buttonPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainTable
            // 
            this.mainTable.ColumnCount = 2;
            this.mainTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15.125F));
            this.mainTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 84.875F));
            this.mainTable.Controls.Add(this.drftAiResponseLbl, 0, 1);
            this.mainTable.Controls.Add(this.subjectLbl, 0, 0);
            this.mainTable.Controls.Add(this.subjectBox, 1, 0);
            this.mainTable.Controls.Add(this.mainContentPanel, 1, 1);
            this.mainTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainTable.Location = new System.Drawing.Point(0, 0);
            this.mainTable.Name = "mainTable";
            this.mainTable.RowCount = 2;
            this.mainTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.777778F));
            this.mainTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 94.22222F));
            this.mainTable.Size = new System.Drawing.Size(800, 450);
            this.mainTable.TabIndex = 0;
            // 
            // drftAiResponseLbl
            // 
            this.drftAiResponseLbl.AutoSize = true;
            this.drftAiResponseLbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.drftAiResponseLbl.Location = new System.Drawing.Point(3, 26);
            this.drftAiResponseLbl.Name = "drftAiResponseLbl";
            this.drftAiResponseLbl.Size = new System.Drawing.Size(115, 424);
            this.drftAiResponseLbl.TabIndex = 2;
            this.drftAiResponseLbl.Text = "AI Response";
            this.drftAiResponseLbl.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // subjectLbl
            // 
            this.subjectLbl.AutoSize = true;
            this.subjectLbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.subjectLbl.Location = new System.Drawing.Point(3, 0);
            this.subjectLbl.Name = "subjectLbl";
            this.subjectLbl.Size = new System.Drawing.Size(115, 26);
            this.subjectLbl.TabIndex = 0;
            this.subjectLbl.Text = "Subject";
            this.subjectLbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // subjectBox
            // 
            this.subjectBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.subjectBox.Enabled = false;
            this.subjectBox.Location = new System.Drawing.Point(124, 3);
            this.subjectBox.Name = "subjectBox";
            this.subjectBox.Size = new System.Drawing.Size(673, 20);
            this.subjectBox.TabIndex = 1;
            // 
            // mainContentPanel
            // 
            this.mainContentPanel.Controls.Add(this.messageBox);
            this.mainContentPanel.Controls.Add(this.mainButtonPanel);
            this.mainContentPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainContentPanel.Location = new System.Drawing.Point(124, 29);
            this.mainContentPanel.Name = "mainContentPanel";
            this.mainContentPanel.Size = new System.Drawing.Size(673, 418);
            this.mainContentPanel.TabIndex = 3;
            // 
            // messageBox
            // 
            this.messageBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.messageBox.Location = new System.Drawing.Point(0, 0);
            this.messageBox.MinimumSize = new System.Drawing.Size(20, 20);
            this.messageBox.Name = "messageBox";
            this.messageBox.Size = new System.Drawing.Size(673, 380);
            this.messageBox.TabIndex = 1;
            // 
            // mainButtonPanel
            // 
            this.mainButtonPanel.Controls.Add(this.buttonPanel);
            this.mainButtonPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.mainButtonPanel.Location = new System.Drawing.Point(0, 380);
            this.mainButtonPanel.Name = "mainButtonPanel";
            this.mainButtonPanel.Size = new System.Drawing.Size(673, 38);
            this.mainButtonPanel.TabIndex = 0;
            // 
            // buttonPanel
            // 
            this.buttonPanel.Controls.Add(this.cpy2ClipBoardBtn);
            this.buttonPanel.Controls.Add(this.draftReplyBtn);
            this.buttonPanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.buttonPanel.Location = new System.Drawing.Point(430, 0);
            this.buttonPanel.Name = "buttonPanel";
            this.buttonPanel.Size = new System.Drawing.Size(243, 38);
            this.buttonPanel.TabIndex = 0;
            // 
            // cpy2ClipBoardBtn
            // 
            this.cpy2ClipBoardBtn.Location = new System.Drawing.Point(65, 6);
            this.cpy2ClipBoardBtn.Name = "cpy2ClipBoardBtn";
            this.cpy2ClipBoardBtn.Size = new System.Drawing.Size(75, 23);
            this.cpy2ClipBoardBtn.TabIndex = 1;
            this.cpy2ClipBoardBtn.Text = "Copy";
            this.cpy2ClipBoardBtn.UseVisualStyleBackColor = true;
            this.cpy2ClipBoardBtn.Click += new System.EventHandler(this.cpy2ClipBoardBtn_Click);
            // 
            // draftReplyBtn
            // 
            this.draftReplyBtn.Location = new System.Drawing.Point(159, 6);
            this.draftReplyBtn.Name = "draftReplyBtn";
            this.draftReplyBtn.Size = new System.Drawing.Size(75, 23);
            this.draftReplyBtn.TabIndex = 0;
            this.draftReplyBtn.Text = "Draft this";
            this.draftReplyBtn.UseVisualStyleBackColor = true;
            this.draftReplyBtn.Click += new System.EventHandler(this.draftReplyBtn_Click);
            // 
            // DraftAiResponse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.mainTable);
            this.Name = "DraftAiResponse";
            this.Text = "DraftAiResponse";
            this.mainTable.ResumeLayout(false);
            this.mainTable.PerformLayout();
            this.mainContentPanel.ResumeLayout(false);
            this.mainButtonPanel.ResumeLayout(false);
            this.buttonPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel mainTable;
        private System.Windows.Forms.Label subjectLbl;
        private System.Windows.Forms.TextBox subjectBox;
        private System.Windows.Forms.Label drftAiResponseLbl;
        private System.Windows.Forms.Panel mainContentPanel;
        private System.Windows.Forms.RichTextBox messageBox;
        private System.Windows.Forms.Panel mainButtonPanel;
        private System.Windows.Forms.Panel buttonPanel;
        private System.Windows.Forms.Button cpy2ClipBoardBtn;
        private System.Windows.Forms.Button draftReplyBtn;
    }
}