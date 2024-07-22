using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartTech_Addin.Forms
{
    public partial class Repharse : Form
    {
        internal Action<string> drafReply;
        private string message;

        public string Message
        {
            get { return message; }
            set
            {
                message = value;
                messageBox.Text = value;
            }
        }

        public Repharse()
        {
            InitializeComponent();
        }

        private void copyBtn_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Clipboard.SetText(messageBox.Text);
        }

        private void draftReplyBtn_Click_1(object sender, EventArgs e)
        {
            if (drafReply != null)
            {
                drafReply.Invoke(messageBox.Text);
            }
        }
    }
}
