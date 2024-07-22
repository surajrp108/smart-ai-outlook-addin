﻿using System;
using System.Windows.Forms;

namespace SmartTech_Addin.Forms
{
    public partial class DraftAiResponse : Form
    {
        private string subject;
        private string message;
        internal Action<string> drafReply;

        public string Subject
        {
            get { return subject; }
            set
            {
                subject = value;
                subjectBox.Text = value;
            }
        }
        public string Message
        {
            get { return message; }
            set
            {
                message = value;
                messageBox.Text = value;
            }
        }

        public DraftAiResponse()
        {
            InitializeComponent();
        }

        private void cpy2ClipBoardBtn_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Clipboard.SetText(messageBox.Text);
        }

        private void draftReplyBtn_Click(object sender, EventArgs e)
        {
            if(drafReply != null)
            {
                drafReply.Invoke(messageBox.Text);
            }
        }
    }
}
