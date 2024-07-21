using Outlook = Microsoft.Office.Interop.Outlook;
using Microsoft.Office.Interop.Outlook;
using Microsoft.Office.Tools;
using System;
using Microsoft.Office.Tools.Outlook;
using System.Collections.Generic;
using Microsoft.Office.Core;
using System.Windows.Forms;

namespace SmartTech_Addin
{
    public partial class ThisAddIn
    {
        private string draftEmailText = null;

        private Outlook.Explorers explorers;
        private Outlook.Explorer currentExplorer;
        private Outlook.MailItem selectedMailItem;
        private Outlook.MailItem editModeMailItem;
        private string originalBodyOfOpenEmail;

        private string OpenedEmailLastContent
        {

            get
            {
                return originalBodyOfOpenEmail;
            }
        }

        public SmartTachAiRibbon RibbonInstance { get; set; }

        public Outlook.MailItem SelectedEmail
        {
            get
            {
                return selectedMailItem;
            }
        }

        public string DraftEmailText
        {
            get { return GetUserAddedContent(selectedMailItem?.Body, editModeMailItem?.Body); }
        }


        private string GetUserAddedContent(string original, string current)
        {
            if (string.IsNullOrEmpty(original)) return current;
            if (!current.StartsWith(original))
            {
                var lastindex = current.IndexOf(original);
                return current.Substring(0, lastindex);
            }
            return current;
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
            explorers = this.Application.Explorers;
            explorers.NewExplorer += new Outlook.ExplorersEvents_NewExplorerEventHandler(Explorers_NewExplorer);
            this.Application.ItemLoad += new ApplicationEvents_11_ItemLoadEventHandler(ItemLoad);

            // Setup the initial explorer
            currentExplorer = this.Application.ActiveExplorer();
            AttachExplorerEvents(currentExplorer);

            //New email
            this.Application.Inspectors.NewInspector += Inspectors_NewInspector;
        }

        private void ItemLoad(object Item)
        {
            this.selectedMailItem= Item as MailItem;
        }

        private void AttachExplorerEvents(Explorer currentExplorer)
        {
            if (currentExplorer != null)
            {
                currentExplorer.SelectionChange += new Outlook.ExplorerEvents_10_SelectionChangeEventHandler(CurrentExplorer_SelectionChange);
            }
        }

        private void CurrentExplorer_SelectionChange()
        {
            Outlook.Selection selection = currentExplorer.Selection;
            if (selection.Count > 0)
            {
                if (selection[1] is Outlook.MailItem)
                {
                    cleanupSelectedMailEvents();
                    selectedMailItem = (Outlook.MailItem)selection[1];
                    Outlook.Inspector inspector = selectedMailItem.GetInspector;
                    ((ItemEvents_10_Event)selectedMailItem).Reply += new Outlook.ItemEvents_10_ReplyEventHandler(SelectedMailItem_Reply);
                    ((ItemEvents_10_Event)selectedMailItem).ReplyAll += new Outlook.ItemEvents_10_ReplyAllEventHandler(SelectedMailItem_ReplyAll);
                    ((ItemEvents_10_Event)selectedMailItem).Forward += new Outlook.ItemEvents_10_ForwardEventHandler(SelectedMailItem_Forward);
                    ((ItemEvents_10_Event)selectedMailItem).Close += SelectedMailItem_Close;
                    ((InspectorEvents_10_Event)inspector).Close += new Outlook.InspectorEvents_10_CloseEventHandler(Inspector_Close);
                }
            }
        }

        private void cleanupSelectedMailEvents()
        {
            if (selectedMailItem != null)
            {
                Outlook.Inspector inspector = selectedMailItem.GetInspector;
                ((ItemEvents_10_Event)selectedMailItem).Reply -= new Outlook.ItemEvents_10_ReplyEventHandler(SelectedMailItem_Reply);
                ((ItemEvents_10_Event)selectedMailItem).ReplyAll -= new Outlook.ItemEvents_10_ReplyAllEventHandler(SelectedMailItem_ReplyAll);
                ((ItemEvents_10_Event)selectedMailItem).Forward -= new Outlook.ItemEvents_10_ForwardEventHandler(SelectedMailItem_Forward);
                ((ItemEvents_10_Event)selectedMailItem).Close -= SelectedMailItem_Close;
                ((InspectorEvents_10_Event)inspector).Close -= new Outlook.InspectorEvents_10_CloseEventHandler(Inspector_Close);
            }
        }

        private void Inspector_Close()
        {
            cleanupSelectedMailEvents();
        }

        private void SelectedMailItem_Close(ref bool Cancel)
        {
            cleanupSelectedMailEvents();
        }

        private void SelectedMailItem_Forward(object Forward, ref bool Cancel)
        {
            this.editModeMailItem = Forward as MailItem;
            CurrentMailItem_Open(ref Cancel);
        }

        private void SelectedMailItem_ReplyAll(object Response, ref bool Cancel)
        {
            this.editModeMailItem = Response as MailItem;
            CurrentMailItem_Open(ref Cancel);
        }

        private void SelectedMailItem_Reply(object Response, ref bool Cancel)
        {
            this.editModeMailItem = Response as MailItem;
            CurrentMailItem_Open(ref Cancel);
        }

        private void Explorers_NewExplorer(Explorer Explorer)
        {
            AttachExplorerEvents(Explorer);
        }

        private void Inspectors_NewInspector(Inspector Inspector)
        {
            if (Inspector.CurrentItem is Outlook.MailItem)
            {
                var currentInspector = Inspector;
                editModeMailItem = (Outlook.MailItem)Inspector.CurrentItem;
                editModeMailItem.Open += new Outlook.ItemEvents_10_OpenEventHandler(CurrentMailItem_Open);
                ((ItemEvents_10_Event)editModeMailItem).Close += SelectedMailItem_Close;
            }
        }

        private void CurrentMailItem_Open(ref bool Cancel)
        {
            originalBodyOfOpenEmail = editModeMailItem.Body;
        }


        private void ThisAddIn_Shutdown(object sender, System.EventArgs e)
        {
            if (currentExplorer != null)
            {
                currentExplorer.SelectionChange -= new Outlook.ExplorerEvents_10_SelectionChangeEventHandler(CurrentExplorer_SelectionChange);
            }
            Application.Inspectors.NewInspector -= Inspectors_NewInspector;

            if (explorers != null)
                explorers.NewExplorer -= new Outlook.ExplorersEvents_NewExplorerEventHandler(Explorers_NewExplorer);
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
