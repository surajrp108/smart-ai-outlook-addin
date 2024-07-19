﻿using System;
using System.Linq;
using System.Windows.Forms;

namespace SmartTech_Addin.Forms
{
    public partial class SummarizeForm : Form
    {
        private string rawInput;
        private string subject;

        public string Subject
        {
            get
            {
                return subject;
            }

            set
            {
                subject = value;
                subjectBox.Text = subject;
            }
        }

        public string InitialMessage
        {
            get
            {
                return rawInput;
            }
            set
            {
                rawInput = value;
                summraizeTextBox.Text = rawInput;
            }
        }

        public Action<string> OnDraftClick { get; internal set; }
        public Action<string> OnAiSuggestClick { get; internal set; }

        public SummarizeForm()
        {
            InitializeComponent();
        }

        private void sumarrizeDraftReplyBtn_Click(object sender, EventArgs e)
        {
            OnDraftClick(summraizeTextBox.Text);
        }

        private void sumarrizeAiSuggestBtn_Click(object sender, EventArgs e)
        {
            //OnAiSuggestClick(summraizeTextBox.Text);
            //Call API
            this.aiSuggestPanel.Visible = true;
            this.sumarrizeAiSuggestBtn.Enabled = false;
        }

        private void aiSuggestionDraftReplyBtn_Click(object sender, EventArgs e)
        {
            OnDraftClick(aiSuggestTextBox.Text);
        }
    }
}
