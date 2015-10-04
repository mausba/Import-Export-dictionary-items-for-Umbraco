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

namespace Inetdesign.ExportImportDictionaryItems.Controls
{
    public partial class export : UmbracoEnsuredPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int dictionaryItemId = int.TryParse(Request["nodeId"], out dictionaryItemId) ? dictionaryItemId : 0;

            //There is an issue in v6 with LocalizationService methods throwing "Sequence contains no elements"
            //var localizationService = UmbracoContext.Current.Application.Services.LocalizationService;

            var dicItems = new List<Dictionary.DictionaryItem>();

            if (dictionaryItemId > 0)
            {
                var dicItem = new Dictionary.DictionaryItem(dictionaryItemId);
                if (dicItem == null) return;

                dicItems.Add(dicItem);
            }
            else
            {
                //export all dictionary items
                foreach (var dicItem in Dictionary.getTopMostItems)
                {
                    dicItems.Add(dicItem);
                }
            }


            var fileName = dictionaryItemId == 0 ? "dictionaryitems" : dicItems.First().key;
            Path.GetInvalidFileNameChars().ToList().ForEach(c => fileName = fileName.Replace(c, '_'));

            Response.AddHeader("Content-Disposition", "attachment;filename=" + fileName + ".dic");
            Response.ContentType = "application/octet-stream";

            var doc = new XmlDocument();
            var parent = doc.CreateElement("DictionaryItems");
            foreach (var dicItem in dicItems)
            {
                parent.AppendChild(dicItem.ToXml(doc));
            }

            doc.AppendChild(parent);

            var writerSettings = new XmlWriterSettings();
            writerSettings.Indent = true;

            var xmlWriter = XmlWriter.Create(Response.OutputStream, writerSettings);
            doc.Save(xmlWriter);
        }
    }
}