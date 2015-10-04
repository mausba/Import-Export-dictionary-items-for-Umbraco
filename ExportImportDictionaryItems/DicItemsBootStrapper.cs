using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using umbraco.cms.businesslogic.web;
using Umbraco.Core;
using Umbraco.Core.Events;
using Umbraco.Core.Models;
using Umbraco.Core.Publishing;
using Umbraco.Core.Services;
using umbraco.cms.presentation.Trees;
using umbraco.interfaces;
using umbraco.BusinessLogic.Actions;
using umbraco;
using ExportImportDictionaryItems.Actions;

namespace Inetdesign.ExportImportDictionaryItems
{
    public class BootStrapper : IApplicationEventHandler
    {
        public BootStrapper()
        {
            BaseTree.NodeActionsCreated += BaseTree_NodeActionsCreated;
        }

        void BaseTree_NodeActionsCreated(object sender, NodeActionsEventArgs e)
        {
            if (sender is loadDictionary)
            {
                e.AllowedActions.Add(ContextMenuSeperator.Instance);
                e.AllowedActions.Add(DictionaryItemsExportAction.Instance);
                e.AllowedActions.Add(DictionaryItemsImportAction.Instance);
            }
        }

        public void OnApplicationInitialized(UmbracoApplicationBase umbracoApplication, ApplicationContext applicationContext)
        {
           
        }

        public void OnApplicationStarted(UmbracoApplicationBase umbracoApplication, ApplicationContext applicationContext)
        {
            
        }

        public void OnApplicationStarting(UmbracoApplicationBase umbracoApplication, ApplicationContext applicationContext)
        {
           
        }
    }
}