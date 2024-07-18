using System;
using System.Linq;
using System.Windows.Forms;

namespace SmartTech_Addin.Forms
{
    public partial class SummarizeForm : Form
    {
        private string subject;
        private string message;
        private string lastMessage;
        private int index = 0;

        public string Subject
        {
            get { return subject; }
            set { subject = value; 
                this.subjectBox.Text = value;
            }
        }

        public String LastMessage
        {
            get { return lastMessage; }
        }

        public string Message
        {
            get { return message; }
            set { 
                message = value;
                WebBrowser broswer = this.mainContentPanel.Controls.Find("messageBox" + index, true).First() as WebBrowser;
                if (broswer != null) {
                    broswer.DocumentText = message;
                }
            }
        }

        public Action<string> OnDraftClick { get; internal set; }

        public SummarizeForm()
        {
            InitializeComponent();
            addEmptyContentPanel(index);
        }

        private void explainMoreBtn_Click(object sender, EventArgs e)
        {
            (this.mainContentPanel.Controls.Find("explainMoreBtn" + index, true).First() as Button).Enabled = false;
            index++;
            addEmptyContentPanel(index);

            this.lastMessage = "<p>Here is more explaination you needed: -----> </p><hr> ";
            Message = this.lastMessage;
        }

        private void DraftResponseBtn_Click(object sender, EventArgs e)
        {
            OnDraftClick(LastMessage);
        }
    }
}
