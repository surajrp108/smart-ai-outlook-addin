﻿using Microsoft.Office.Core;
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
using System.Drawing;

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
                    replyAll.HTMLBody = parseBodyInHtml(replyText) + replyAll.HTMLBody;
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
            var response = this.apiHandler.getAiSuggestResponse(Globals.ThisAddIn.SelectedEmail);

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
            var email = Globals.ThisAddIn.SelectedEmail;
            if(email == null || email.Saved || email.Sent)
            {
                MessageBox.Show("Rephrasing can be done on the drafted email.");
                return;
            }

            var emailBody = Globals.ThisAddIn.SelectedEmail.Body;
            int indexOfDraft = emailBody.IndexOf("\r\nFrom:");

            if (indexOfDraft >= 0)
            {
                string draftPart = emailBody.Substring(0, indexOfDraft).Trim();
                string repharseTxt = apiHandler.getRepharse(draftPart);
                Repharse repharse = new Repharse();
                repharse.Message = repharseTxt;
                repharse.drafReply = (message) =>
                {
                    repharse.Close();
                    drafReplayAll(message);
                };
                repharse.Show();
            }
        }

        public void onClickSummarizeBtn(IRibbonControl control)
        {
            var mailItem = Globals.ThisAddIn.SelectedEmail;
            LoaderForm form = new LoaderForm();
            form.Show();
            var response = this.apiHandler.getAiSummarize(mailItem);
            form.Close();

            var popup = new SummarizeForm();
            popup.Subject = mailItem.Subject;
            popup.InitialMessage = response;
            popup.OnDraftClick = drafReplayAll;
            popup.Show();

        }

        #endregion

        #endregion

        #region Helpers

        public Bitmap GetImage(Office.IRibbonControl control)
        {
            switch (control.Id)
            {
                case "draftBtn1":
                case "draftBtn2":
                case "draftBtn3":
                    return LoadImageFromResource("SmartTech_Addin.images.suggest.png");
                case "summarizeBtn1":
                case "summarizeBtn2":
                case "summarizeBtn3":
                    return LoadImageFromResource("SmartTech_Addin.images.summary.png");
                case "repharseBtn1":
                case "repharseBtn2":
                case "repharseBtn3":
                    return LoadImageFromResource("SmartTech_Addin.images.repharse.png");
                default:
                    return null;
            }
        }

        private Bitmap LoadImageFromResource(string resourceName)
        {
            var assembly = Assembly.GetExecutingAssembly();
            using (var stream = assembly.GetManifestResourceStream(resourceName))
            {
                if (stream != null)
                {
                    return new Bitmap(stream);
                }
                else
                {
                    throw new System.Exception("Resource not found: " + resourceName);
                }
            }
        }



        private string parseBodyInHtml(string msg)
        {
            return msg.Replace("\n", "<br/>");
        }

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
