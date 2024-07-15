using Outlook = Microsoft.Office.Interop.Outlook;
using Microsoft.Office.Interop.Outlook;
using Microsoft.Office.Tools;
using System;
using Microsoft.Office.Tools.Outlook;
using System.Collections.Generic;
using Microsoft.Office.Core;

namespace SmartTech_Addin
{
    public partial class ThisAddIn
    {
        private Outlook.Inspectors inspectors;
        private Outlook.MailItem selectedEmail;
        public SmartTachAiRibbon RibbonInstance { get; set; }

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

        public void InvalidateRibbon()
        {
            if (Globals.ThisAddIn.RibbonInstance != null)
            {
                Globals.ThisAddIn.RibbonInstance.Invalidate();
            }
        }

        private void ThisAddIn_Startup(object sender, System.EventArgs e)
        {
            Outlook.Explorer explorer = this.Application.ActiveExplorer();
            explorer.SelectionChange += new Outlook.ExplorerEvents_10_SelectionChangeEventHandler(Explorer_SelectionChange);

            this.Application.Inspectors.NewInspector += Inspectors_NewInspector;
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
            InvalidateRibbon();

        }

        private void Inspectors_NewInspector(Inspector Inspector)
        {
            ((Outlook.InspectorEvents_10_Event)Inspector).Activate += Inspector_Activate;
        }

        private void Inspector_Activate()
        {
            Outlook.Inspector inspector = this.Application.ActiveInspector();
            if (inspector != null)
            {
                Outlook.MailItem mailItem = inspector.CurrentItem as Outlook.MailItem;
                if (mailItem != null)
                {
                    selectedEmail = mailItem;
                }
            }
            InvalidateRibbon();
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
