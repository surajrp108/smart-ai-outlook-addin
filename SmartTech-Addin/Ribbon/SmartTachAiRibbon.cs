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
            //DraftReplyAllAsync("replyText");
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

        private string GetSelecteEmailTempSavedPath()
        {
            string tempPath = null;
            var mailItem = Globals.ThisAddIn.SelectedEmail as MailItem;

            if (mailItem != null)
            {
                tempPath = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString() + ".msg");
                mailItem.SaveAs(tempPath, Outlook.OlSaveAsType.olMSG);
            }
            
        }

        private async Task SendMailAsAttachmentAsync()
        {
            String path = GetSelecteEmailTempSavedPath();
            byte[] fileData = File.ReadAllBytes(path); 

            using (var client = new HttpClient())
            using (var content = new MultipartFormDataContent())
            {
                var fileContent = new ByteArrayContent(fileData);
                fileContent.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
                content.Add(fileContent, "file", Path.GetFileName(path));

                string apiUrl = "https://your-api-endpoint.com/upload";

                HttpResponseMessage response = await client.PostAsync(apiUrl, content);
                if (response.IsSuccessStatusCode)
                {
                    // Handle success
                }
                else
                {
                    // Handle error
                }
            }
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
