using System;
using System.Windows.Forms;

namespace SmartTech_Addin.Forms
{
    partial class SummarizeForm
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
            this.mainTbl = new System.Windows.Forms.TableLayoutPanel();
            this.subjectLbl = new System.Windows.Forms.Label();
            this.summarizationLbl = new System.Windows.Forms.Label();
            this.subjectBox = new System.Windows.Forms.RichTextBox();
            this.mainContentPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.mainTbl.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainTbl
            // 
            this.mainTbl.ColumnCount = 2;
            this.mainTbl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.89011F));
            this.mainTbl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 90.10989F));
            this.mainTbl.Controls.Add(this.subjectLbl, 0, 0);
            this.mainTbl.Controls.Add(this.summarizationLbl, 0, 1);
            this.mainTbl.Controls.Add(this.subjectBox, 1, 0);
            this.mainTbl.Controls.Add(this.mainContentPanel, 1, 1);
            this.mainTbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainTbl.Location = new System.Drawing.Point(0, 0);
            this.mainTbl.Name = "mainTbl";
            this.mainTbl.RowCount = 2;
            this.mainTbl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.854839F));
            this.mainTbl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 93.14516F));
            this.mainTbl.Size = new System.Drawing.Size(1227, 626);
            this.mainTbl.TabIndex = 0;
            // 
            // subjectLbl
            // 
            this.subjectLbl.AutoSize = true;
            this.subjectLbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.subjectLbl.Location = new System.Drawing.Point(3, 0);
            this.subjectLbl.Name = "subjectLbl";
            this.subjectLbl.Size = new System.Drawing.Size(115, 42);
            this.subjectLbl.TabIndex = 0;
            this.subjectLbl.Text = "Subject";
            this.subjectLbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // summarizationLbl
            // 
            this.summarizationLbl.AutoSize = true;
            this.summarizationLbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.summarizationLbl.Location = new System.Drawing.Point(3, 42);
            this.summarizationLbl.Name = "summarizationLbl";
            this.summarizationLbl.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.summarizationLbl.Size = new System.Drawing.Size(115, 584);
            this.summarizationLbl.TabIndex = 2;
            this.summarizationLbl.Text = "Summarization";
            this.summarizationLbl.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // subjectBox
            // 
            this.subjectBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.subjectBox.Enabled = false;
            this.subjectBox.Location = new System.Drawing.Point(124, 3);
            this.subjectBox.Name = "subjectBox";
            this.subjectBox.Size = new System.Drawing.Size(1100, 36);
            this.subjectBox.TabIndex = 7;
            this.subjectBox.Text = "";
            // 
            // mainContentPanel
            // 
            this.mainContentPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainContentPanel.Location = new System.Drawing.Point(124, 45);
            this.mainContentPanel.Name = "mainContentPanel";
            this.mainContentPanel.Size = new System.Drawing.Size(1100, 578);
            this.mainContentPanel.TabIndex = 8;
            this.mainContentPanel.FlowDirection = FlowDirection.TopDown;
            this.mainContentPanel.WrapContents = false;
            this.mainContentPanel.AutoScroll = true;
            // 
            // SummarizeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1227, 626);
            this.Controls.Add(this.mainTbl);
            this.Name = "SummarizeForm";
            this.Text = "Summarize";
            this.mainTbl.ResumeLayout(false);
            this.mainTbl.PerformLayout();
            this.ResumeLayout(false);

            this.SizeChanged += new EventHandler(MainForm_SizeChanged);
            this.Resize += new EventHandler(MainForm_SizeChanged);

        }

        private void MainForm_SizeChanged(object sender, EventArgs e)
        {
            foreach (Control ctrl in mainContentPanel.Controls)
            {
                ctrl.Size = new System.Drawing.Size(mainContentPanel.Width, ctrl.Height);
            }
        }

        public void addEmptyContentPanel(int index)
        {

            System.Windows.Forms.Panel contentPanel = new System.Windows.Forms.Panel();
            System.Windows.Forms.WebBrowser messageBox = new System.Windows.Forms.WebBrowser();
            System.Windows.Forms.Panel buttonMainPanel = new System.Windows.Forms.Panel();
            System.Windows.Forms.Panel buttonPanel = new System.Windows.Forms.Panel();
            System.Windows.Forms.Button draftResponseBtn = new System.Windows.Forms.Button();
            System.Windows.Forms.Button explainMoreBtn = new System.Windows.Forms.Button();

            contentPanel.SuspendLayout();
            buttonMainPanel.SuspendLayout();
            buttonPanel.SuspendLayout();

            // 
            // contentPanel
            // 
            contentPanel.Controls.Add(messageBox);
            contentPanel.Controls.Add(buttonMainPanel);
            contentPanel.Name = "contentPanel"+index;
            contentPanel.Size = new System.Drawing.Size(mainContentPanel.Width, 498);
            // 
            // messageBox
            // 
            messageBox.Dock = System.Windows.Forms.DockStyle.Fill;
            messageBox.MinimumSize = new System.Drawing.Size(20, 20);
            messageBox.Name = "messageBox" + index;
            messageBox.Size = new System.Drawing.Size(833, 457);
            // 
            // buttonMainPanel
            // 
            buttonMainPanel.Controls.Add(buttonPanel);
            buttonMainPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            buttonMainPanel.Name = "buttonMainPanel" + index;
            buttonMainPanel.Size = new System.Drawing.Size(833, 41);
            // 
            // buttonPanel
            // 
            buttonPanel.Controls.Add(draftResponseBtn);
            buttonPanel.Controls.Add(explainMoreBtn);
            buttonPanel.Dock = System.Windows.Forms.DockStyle.Right;
            buttonPanel.Name = "buttonPanel" + index;
            buttonPanel.Size = new System.Drawing.Size(200, 41);
            // 
            // DraftResponseBtn
            // 
            draftResponseBtn.Name = "DraftResponseBtn" + index;
            draftResponseBtn.Size = new System.Drawing.Size(75, 33);
            draftResponseBtn.Location = new System.Drawing.Point(110, 3);
            draftResponseBtn.Text = "Draft Reply";
            draftResponseBtn.UseVisualStyleBackColor = true;
            draftResponseBtn.Click += new System.EventHandler(DraftResponseBtn_Click);
            // 
            // explainMoreBtn
            // 
            explainMoreBtn.Name = "explainMoreBtn" + index;
            explainMoreBtn.Size = new System.Drawing.Size(92, 33);
            explainMoreBtn.Location = new System.Drawing.Point(10, 3);
            explainMoreBtn.Text = "AI Suggestion";
            explainMoreBtn.UseVisualStyleBackColor = true;
            explainMoreBtn.Click += new System.EventHandler(explainMoreBtn_Click);

            contentPanel.ResumeLayout(false);
            buttonMainPanel.ResumeLayout(false);
            buttonPanel.ResumeLayout(false);

            int controlHeight = contentPanel.Height;
            foreach (Control ctrl in mainContentPanel.Controls)
            {
                ctrl.Top += controlHeight;
            }
            contentPanel.Top = 0;
            this.mainContentPanel.Controls.Add(contentPanel);
            this.mainContentPanel.Controls.SetChildIndex(contentPanel, 0);
            this.mainContentPanel.AutoScrollPosition = new System.Drawing.Point(0, 0);
        }



        #endregion

        private System.Windows.Forms.TableLayoutPanel mainTbl;
        private System.Windows.Forms.Label subjectLbl;
        private System.Windows.Forms.Label summarizationLbl;
        private System.Windows.Forms.RichTextBox subjectBox;
        private System.Windows.Forms.FlowLayoutPanel mainContentPanel;
    }
}