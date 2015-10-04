using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using umbraco.interfaces;

namespace ExportImportDictionaryItems.Actions
{
    public class DictionaryItemsExportAction : IAction
    {
        public static readonly DictionaryItemsExportAction Instance = new DictionaryItemsExportAction();

        public string Alias { get { return "Export"; } }
        public bool CanBePermissionAssigned { get { return true; } }
        public string Icon { get { return ""; } }
        public string JsFunctionName { get { return "OpenExportWindow();"; } }
        public char Letter { get { return 'e'; } }
        public bool ShowInNotifier { get { return true; } }

        public string JsSource
        {
            get
            {
                var js = @"function OpenExportWindow() {
                            var idurl = '/umbraco/plugins/Inetdesign.ExportImportDictionaryItems/export.aspx?nodeId=' + UmbClientMgr.mainTree().getActionNode().nodeId + '&rnd=' + (Math.floor(Math.random()*(75800000-59438709))+59438709);
                            UmbClientMgr.mainWindow().open(idurl, 'Export dictionary item', true, 350, 380);
                       };";
                return js;
            }
        }
    }
}
