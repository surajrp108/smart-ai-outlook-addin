using Microsoft.Office.Core;
using Microsoft.Office.Interop.Outlook;
using System;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using Office = Microsoft.Office.Core;
using System.Net.Http;
using System.Threading.Tasks;

namespace SmartTech_Addin
{
    [ComVisible(true)]
    public class SmartTachAiRibbon : Office.IRibbonExtensibility
    {
        private Office.IRibbonUI ribbon;
        private static readonly HttpClient client = new HttpClient();

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
        public void Ribbon_Load(Office.IRibbonUI ribbonUI)
        {
            this.ribbon = ribbonUI;
        }

        public void onClickDraftBtn(IRibbonControl control)
        {
            DraftReplyAllAsync();
        }

        public void onClickSummarizeBtn(IRibbonControl control)
        {
            Globals.ThisAddIn.TaskPane.Visible = true;
        }

        public void onClickRepharse(IRibbonControl control)
        {
            DraftReplyWithAttachment();
        }

        public bool isEmailSelected() 
        {
            var application = Globals.ThisAddIn.SelectedEmail;
            bool email = application != null;
            return email;
        }

        private async Task DraftReplyAllAsync()
        {
            string url = "https://google.com/";
            //string response = await GetApiDataAsync(url);
            //Console.WriteLine(response);

            var mailItem = Globals.ThisAddIn.SelectedEmail as MailItem;
            if (mailItem != null)
            {
                var replyAll = mailItem.ReplyAll();
                replyAll.HTMLBody = "hello" + "\n" + replyAll.HTMLBody;
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


        async Task<string> GetApiDataAsync(string url)
        {
            HttpResponseMessage response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode(); // Throw an exception if the status code is not 2xx

            string responseBody = await response.Content.ReadAsStringAsync();
            return responseBody;
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
