using Outlook = Microsoft.Office.Interop.Outlook;
using Microsoft.Office.Interop.Outlook;
using System;

namespace SmartTech_Addin
{
    public partial class ThisAddIn
    {
        private string draftEmailText = null;

        private Outlook.Explorers explorers;
        private Outlook.Explorer currentExplorer;
        private Outlook.MailItem selectedMailItem;

        public SmartTachAiRibbon RibbonInstance { get; set; }

        public Outlook.MailItem SelectedEmail
        {
            get
            {
                return selectedMailItem;
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
            this.Application.ItemLoad += new ApplicationEvents_11_ItemLoadEventHandler(ItemLoad);
            this.Application.Inspectors.NewInspector += Inspectors_NewInspector;
        }

        private void Inspectors_NewInspector(Inspector Inspector)
        {
            if (Inspector.CurrentItem is Outlook.MailItem)
            {
                var currentInspector = Inspector;
                this.selectedMailItem = (Outlook.MailItem)Inspector.CurrentItem;
            }
        }

        private void ItemLoad(object Item)
        {
            this.selectedMailItem = Item as MailItem;
        }

        private void ThisAddIn_Shutdown(object sender, System.EventArgs e)
        {
            Application.Inspectors.NewInspector -= Inspectors_NewInspector;
            this.Application.ItemLoad -= new ApplicationEvents_11_ItemLoadEventHandler(ItemLoad);
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
