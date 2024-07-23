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
            this.mainContentPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.sumrraizePanel = new System.Windows.Forms.Panel();
            this.summraizeTextBox = new System.Windows.Forms.RichTextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.copyBtn = new System.Windows.Forms.Button();
            this.subjectLbl = new System.Windows.Forms.Label();
            this.summarizationLbl = new System.Windows.Forms.Label();
            this.subjectBox = new System.Windows.Forms.RichTextBox();
            this.mainTbl.SuspendLayout();
            this.mainContentPanel.SuspendLayout();
            this.sumrraizePanel.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainTbl
            // 
            this.mainTbl.ColumnCount = 2;
            this.mainTbl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.89011F));
            this.mainTbl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 90.10989F));
            this.mainTbl.Controls.Add(this.mainContentPanel, 1, 1);
            this.mainTbl.Controls.Add(this.subjectLbl, 0, 0);
            this.mainTbl.Controls.Add(this.summarizationLbl, 0, 1);
            this.mainTbl.Controls.Add(this.subjectBox, 1, 0);
            this.mainTbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainTbl.Location = new System.Drawing.Point(0, 0);
            this.mainTbl.Name = "mainTbl";
            this.mainTbl.RowCount = 2;
            this.mainTbl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.854839F));
            this.mainTbl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 93.14516F));
            this.mainTbl.Size = new System.Drawing.Size(1241, 645);
            this.mainTbl.TabIndex = 0;
            // 
            // mainContentPanel
            // 
            this.mainContentPanel.AutoScroll = true;
            this.mainContentPanel.Controls.Add(this.sumrraizePanel);
            this.mainContentPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainContentPanel.Location = new System.Drawing.Point(125, 47);
            this.mainContentPanel.Name = "mainContentPanel";
            this.mainContentPanel.Size = new System.Drawing.Size(1113, 595);
            this.mainContentPanel.TabIndex = 9;
            // 
            // sumrraizePanel
            // 
            this.sumrraizePanel.Controls.Add(this.summraizeTextBox);
            this.sumrraizePanel.Controls.Add(this.panel2);
            this.sumrraizePanel.Location = new System.Drawing.Point(3, 3);
            this.sumrraizePanel.Name = "sumrraizePanel";
            this.sumrraizePanel.Size = new System.Drawing.Size(1106, 589);
            this.sumrraizePanel.TabIndex = 11;
            // 
            // summraizeTextBox
            // 
            this.summraizeTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.summraizeTextBox.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.summraizeTextBox.Location = new System.Drawing.Point(0, 0);
            this.summraizeTextBox.Margin = new System.Windows.Forms.Padding(3, 3, 3, 20);
            this.summraizeTextBox.Name = "summraizeTextBox";
            this.summraizeTextBox.Size = new System.Drawing.Size(1106, 553);
            this.summraizeTextBox.TabIndex = 1;
            this.summraizeTextBox.Text = "";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.copyBtn);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 553);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1106, 36);
            this.panel2.TabIndex = 0;
            // 
            // copyBtn
            // 
            this.copyBtn.Location = new System.Drawing.Point(1031, 0);
            this.copyBtn.Name = "copyBtn";
            this.copyBtn.Size = new System.Drawing.Size(75, 36);
            this.copyBtn.TabIndex = 0;
            this.copyBtn.Text = "Copy";
            this.copyBtn.UseVisualStyleBackColor = true;
            this.copyBtn.Click += new System.EventHandler(this.copyBtn_Click);
            // 
            // subjectLbl
            // 
            this.subjectLbl.AutoSize = true;
            this.subjectLbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.subjectLbl.Location = new System.Drawing.Point(3, 0);
            this.subjectLbl.Name = "subjectLbl";
            this.subjectLbl.Size = new System.Drawing.Size(116, 44);
            this.subjectLbl.TabIndex = 0;
            this.subjectLbl.Text = "Subject";
            this.subjectLbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // summarizationLbl
            // 
            this.summarizationLbl.AutoSize = true;
            this.summarizationLbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.summarizationLbl.Location = new System.Drawing.Point(3, 44);
            this.summarizationLbl.Name = "summarizationLbl";
            this.summarizationLbl.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.summarizationLbl.Size = new System.Drawing.Size(116, 601);
            this.summarizationLbl.TabIndex = 2;
            this.summarizationLbl.Text = "Summarization";
            this.summarizationLbl.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // subjectBox
            // 
            this.subjectBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.subjectBox.Enabled = false;
            this.subjectBox.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.subjectBox.Location = new System.Drawing.Point(128, 3);
            this.subjectBox.Margin = new System.Windows.Forms.Padding(6, 3, 6, 3);
            this.subjectBox.Name = "subjectBox";
            this.subjectBox.Size = new System.Drawing.Size(1107, 38);
            this.subjectBox.TabIndex = 7;
            this.subjectBox.Text = "";
            // 
            // SummarizeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1241, 645);
            this.Controls.Add(this.mainTbl);
            this.Name = "SummarizeForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Summarize";
            this.SizeChanged += new System.EventHandler(this.MainForm_SizeChanged);
            this.Resize += new System.EventHandler(this.MainForm_SizeChanged);
            this.mainTbl.ResumeLayout(false);
            this.mainTbl.PerformLayout();
            this.mainContentPanel.ResumeLayout(false);
            this.sumrraizePanel.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        private void MainForm_SizeChanged(object sender, EventArgs e)
        {
            foreach (Control ctrl in mainContentPanel.Controls)
            {
                ctrl.Size = new System.Drawing.Size(mainContentPanel.Width-40, ctrl.Height);
            }
        }


        #endregion
        

        private System.Windows.Forms.TableLayoutPanel mainTbl;
        private System.Windows.Forms.Label summarizationLbl;
        private System.Windows.Forms.RichTextBox subjectBox;
        private Label subjectLbl;
        private FlowLayoutPanel mainContentPanel;
        private Panel sumrraizePanel;
        private RichTextBox summraizeTextBox;
        private Panel panel2;
        private Button copyBtn;
    }
}