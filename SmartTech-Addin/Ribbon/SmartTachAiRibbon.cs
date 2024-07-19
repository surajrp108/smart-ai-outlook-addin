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
using static System.Net.WebRequestMethods;

namespace SmartTech_Addin
{
    [ComVisible(true)]
    public class SmartTachAiRibbon : Office.IRibbonExtensibility
    {
        private Office.IRibbonUI ribbon;
        private ApiHandler apiHandler = new ApiHandler();

        public SmartTachAiRibbon()
        {
        }

        #region IRibbonExtensibility Members

        public string GetCustomUI(string ribbonID)
        {
            return GetResourceText("SmartTech_Addin.Ribbon.SmartTechAiRibbon.xml");
        }

        #endregion

        #region Ribbon Functions
        public void Invalidate()
        {
            this.ribbon?.Invalidate();
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

        private void drafReplayAll(string replyText)
        {

            var mailItem = Globals.ThisAddIn.SelectedEmail as MailItem;
            if (mailItem != null)
            {
                try
                {
                    var replyAll = mailItem.ReplyAll();
                    replyAll.Body = replyText + replyAll.HTMLBody;
                    replyAll.Display();
                }
                catch (System.Exception e)
                {
                    MessageBox.Show(e.Message, "error");
                }
            }
        }


        #region Component Event Handling
        public void Ribbon_Load(Office.IRibbonUI ribbonUI)
        {
            this.ribbon = ribbonUI;
            Globals.ThisAddIn.RibbonInstance = this;
        }

        public void onClickAiSuggestion(IRibbonControl control)
        {
            LoaderForm form = new LoaderForm();
            form.Show();
            var response = this.apiHandler.getAiSuggestResponse(Globals.ThisAddIn.SelectedEmail);
            form.Close();

            var mailItem = Globals.ThisAddIn.SelectedEmail as MailItem;
            if (mailItem != null)
            {
                DraftAiResponse draftAiResponse = new DraftAiResponse();
                draftAiResponse.Subject = mailItem.Subject;
                draftAiResponse.Message = response;
                draftAiResponse.drafReply = (message) =>
                {
                    draftAiResponse.Close();
                    drafReplayAll(message);
                };
                draftAiResponse.Show();
            }
        }

        public void onClickRepharse(IRibbonControl control)
        {
            if (isReadOnlyMode())
            {
                MessageBox.Show("Only allowed on Daft email");
                return;
            }
        }

        public void onClickSummarizeBtn(IRibbonControl control)
        {
            var mailItem = Globals.ThisAddIn.SelectedEmail;
            LoaderForm form = new LoaderForm();
            form.Show();
            var response = this.apiHandler.getAiSuggestResponse(mailItem);
            form.Close();

            var popup = new SummarizeForm();
            popup.Subject = mailItem.Subject;
            popup.InitialMessage = mailItem.Body;
            popup.OnDraftClick = drafReplayAll;
            popup.Show();

        }
        #endregion

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
