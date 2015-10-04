using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using umbraco.interfaces;

namespace ExportImportDictionaryItems.Actions
{
    public class DictionaryItemsImportAction : IAction
    {
        public static readonly DictionaryItemsImportAction Instance = new DictionaryItemsImportAction();

        public string Alias { get { return "Import"; } }
        public bool CanBePermissionAssigned { get { return true; } }
        public string Icon { get { return ""; } }
        public string JsFunctionName { get { return "OpenImportWindow();"; } }
        public char Letter { get { return 'i'; } }
        public bool ShowInNotifier { get { return true; } }

        public string JsSource
        {
            get
            {
                var js = @"function OpenImportWindow() {
                            var idurl = '/umbraco/plugins/Inetdesign.ExportImportDictionaryItems/import.aspx?nodeId=' + UmbClientMgr.mainTree().getActionNode().nodeId + '&rnd=' + (Math.floor(Math.random()*(75800000-59438709))+59438709);
                            UmbClientMgr.openModalWindow(idurl, 'Import dictionary items', true, 450, 380);
                       };";
                return js;
            }
        }
    }
}
