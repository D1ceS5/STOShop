using STOChernysh.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace STOChernysh.Controls
{
    public partial class CartSummary : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Crt cart = SessionHelper.GetCart(Session);
            csQuantity.InnerText = cart.Lines.Sum(x => x.Quantity).ToString();
            csTotal.InnerText = cart.ComputeTotalPrice().ToString("c");
            csLink.HRef = RouteTable.Routes.GetVirtualPath(null, "cart", null).VirtualPath;
        }
    }
}