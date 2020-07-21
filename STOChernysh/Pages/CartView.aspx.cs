using STOChernysh.Models;
using STOChernysh.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace STOChernysh.Pages
{
    public partial class CartView : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                Repository repository = new Repository();
                int serviceId;
                if (int.TryParse(Request.Form["remove"], out serviceId))
                {
                    Service serviceToRemove = repository.Service.Where(g => g.ServiceId == serviceId).FirstOrDefault();
                    if (serviceId != null)
                    {
                        SessionHelper.GetCart(Session).RemoveLine(serviceToRemove);
                    }
                }
            }
        }

        public IEnumerable<STOChernysh.Models.CrtLine> GetCartLines()
        {
            return SessionHelper.GetCart(Session).Lines;
        }

        public decimal CartTotal { get { return SessionHelper.GetCart(Session).ComputeTotalPrice(); } }

        public string ReturnUrl { get { return SessionHelper.Get<string>(Session, SessionKey.RETURN_URL); } }
        public string CheckoutUrl { get { return RouteTable.Routes.GetVirtualPath(null, "checkout", null).VirtualPath; } }
    }
}