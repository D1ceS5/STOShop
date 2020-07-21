using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace STOChernysh.Pages.Admin
{
    public partial class Admin : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        private string GenerateUrl(string routeName) => RouteTable.Routes.GetVirtualPath(null, routeName, null).VirtualPath;

        public string OrdersUrl
        {
            get { return GenerateUrl("admin_orders"); }
        }
        public string GamesUrl
        {
            get { return GenerateUrl("admin_services"); }
        }
    }
}