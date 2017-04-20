using Examine;
using Examine.LuceneEngine;
using Examine.LuceneEngine.Providers;
using Examine.Providers;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Net.Http.Formatting;
using Umbraco.Web.Models.Trees;
using Umbraco.Web.Mvc;
using Umbraco.Web.Trees;
using umbraco.BusinessLogic.Actions;
using Our.Umbraco.ExamineTree.Actions;
using System.Globalization;

namespace Our.Umbraco.ExamineTree.Controllers
{
    [Tree("developer", "Searchers", "Searchers")]
    [PluginController("OurUmbracoExamineTree")]
    public class ExamineSearcherTreeController : TreeController
    {

        protected override MenuItemCollection GetMenuForNode(string id, FormDataCollection queryStrings)
        {
            MenuItemCollection collection = new MenuItemCollection();

            if (id == "-1")
            {
                collection.Items.Add<RefreshNode, ActionRefresh>(Localize("actions/" + ActionRefresh.Instance.Alias));
            }

            return collection;
        }

        protected override TreeNodeCollection GetTreeNodes(string id, FormDataCollection queryStrings)
        {
            TreeNodeCollection nodes = new TreeNodeCollection();

            if (id == "-1")
            { 
                var searchers = ExamineManager.Instance.SearchProviderCollection.Cast<BaseSearchProvider>().Select(x => x.Name);

                foreach (var searcher in searchers)
                {
                    nodes.Add(CreateTreeNode(searcher, id, queryStrings, searcher, "icon-search"));
                }
            }

            return nodes;
        }

        private string Localize(string key)
        {
            return ApplicationContext.Services.TextService.Localize(key, CultureInfo.CurrentCulture);
        }
    }
}
