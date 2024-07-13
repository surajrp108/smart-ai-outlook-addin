using Outlook = Microsoft.Office.Interop.Outlook;
using Microsoft.Office.Interop.Outlook;
using Microsoft.Office.Tools;
using System;

namespace SmartTech_Addin
{
    public partial class ThisAddIn
    {
        private CustomTaskPane myCustomTaskPane;
        private Outlook.Inspectors inspectors;
        private Outlook.MailItem selectedEmail;

        public CustomTaskPane TaskPane
        {
            get
            {
                return myCustomTaskPane;
            }
        }
        public Outlook.MailItem SelectedEmail
        {
            get
            {
                return selectedEmail;
            }
        }

        protected override Microsoft.Office.Core.IRibbonExtensibility CreateRibbonExtensibilityObject()
        {
            return new SmartTachAiRibbon();
        }

        private void ThisAddIn_Startup(object sender, System.EventArgs e)
        {
            Outlook.Explorer explorer = this.Application.ActiveExplorer();
            explorer.SelectionChange += new Outlook.ExplorerEvents_10_SelectionChangeEventHandler(Explorer_SelectionChange);

            /*
              myCustomTaskPane.Visible = true;

             inspectors = this.Application.Inspectors;
             inspectors.NewInspector +=
             new Microsoft.Office.Interop.Outlook.InspectorsEvents_NewInspectorEventHandler(Inspectors_NewInspector);
             */
        }

        private void Explorer_SelectionChange()
        {
            Outlook.Explorer explorer = this.Application.ActiveExplorer();
            Outlook.Selection selection = explorer.Selection;

            if (selection.Count > 0)
            {
                Object selectedItem = selection[1]; // Get the first selected item

                if (selectedItem is Outlook.MailItem)
                {
                    selectedEmail = (Outlook.MailItem)selectedItem;
                }
            }
        }

        private void Inspectors_NewInspector(Inspector Inspector)
        {
            Outlook.MailItem mailItem = Inspector.CurrentItem as Outlook.MailItem;
            if (mailItem != null)
            {
                if (mailItem.EntryID == null)
                {
                    mailItem.Subject = "This text was added by using code";
                    mailItem.Body = "This text was added by using code";
                }

            }
        }

        private void ThisAddIn_Shutdown(object sender, System.EventArgs e)
        {
            // Note: Outlook no longer raises this event. If you have code that 
            //    must run when Outlook shuts down, see https://go.microsoft.com/fwlink/?LinkId=506785
        }

        #region VSTO generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InternalStartup()
        {
            this.Startup += new System.EventHandler(ThisAddIn_Startup);
            this.Shutdown += new System.EventHandler(ThisAddIn_Shutdown);
        }
        
        #endregion
    }
}
