using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using umbraco.BasePages;
using umbraco.cms.businesslogic;
using umbraco.IO;
using Umbraco.Core.Logging;

namespace Inetdesign.ExportImportDictionaryItems.Controls
{
    public partial class import : UmbracoEnsuredPage
    {
        private int DictionaryItemId;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                submit.Text = "Import";
                btnImport.Text = "Import";
            }
            DictionaryItemId = int.TryParse(Request["nodeid"], out DictionaryItemId) ? DictionaryItemId : 0;
        }
        protected void submit_Click(object sender, EventArgs e)
        {
            if (dicItemsFile.PostedFile.ContentLength == 0) return;

            var tempFileName = "justDelete_" + Guid.NewGuid().ToString() + ".dic";
            var fileName = Server.MapPath(SystemDirectories.Data + "/" + tempFileName);
            tempFile.Value = fileName;

            dicItemsFile.PostedFile.SaveAs(fileName);

            try
            {
                var xd = new XmlDocument();
                xd.Load(fileName);
                var dicItems = xd.DocumentElement.SelectSingleNode("//DictionaryItems");

                var parentDicItem = DictionaryItemId > 0 ? new Dictionary.DictionaryItem(DictionaryItemId) : null;
                dtImportTo.Text = "Import to: " + (parentDicItem != null ? parentDicItem.key : "Dictionary") + " node?";
            }
            catch
            {
                lblError.Text = "Unknown file format";
                return;
            }

            Wizard.Visible = false;
            done.Visible = false;
            Confirm.Visible = true;
        }

        protected void import_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tempFile.Value)) return;

            var doc = new XmlDocument();
            doc.Load(tempFile.Value);

            var parent = DictionaryItemId > 0 ? new Dictionary.DictionaryItem(DictionaryItemId) : null;

            foreach (XmlNode node in doc.SelectNodes("//DictionaryItems/DictionaryItem"))
            {
                Dictionary.DictionaryItem.Import(node, parent);
            }

            // Try to clean up the temporary file.
            try
            {
                File.Delete(tempFile.Value);
            }
            catch (Exception ex)
            {
                LogHelper.Error(typeof(import), "Error cleaning up temporary dic file in App_Data: " + ex.Message, ex);
            }

            Wizard.Visible = false;
            Confirm.Visible = false;
            done.Visible = true;
        }
    }
}