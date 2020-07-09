using STOChernysh.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace STOChernysh.Controls
{
    public partial class CategoryList : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected IEnumerable<string> GetCategories() => new Repository().Category.Select(p=>p.Name);
        protected string CreateHomeLinkHtml()
        {
            string path = RouteTable.Routes.GetVirtualPath(null, null).VirtualPath;
            return string.Format("<a href='{0}'>Главная страница</a>", path);
        }

        protected string CreateLinkHtml(string category)
        {
            string selectedCategory = (string)Page.RouteData.Values["category"] ?? Request.QueryString["category"];
            string path = RouteTable.Routes.GetVirtualPath(null, null, new RouteValueDictionary() { { "category", category }, { "page", "1" } }).VirtualPath;
            return string.Format("<a href='{0}' {1}> {2} </a>", path, category == selectedCategory ? "class='selected'" : "class='category'", category);
        }
    }
}