using STOChernysh.Models;
using STOChernysh.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace STOChernysh.Pages.Admin
{
    public partial class Orders : System.Web.UI.Page
    {
        private Repository repository = new Repository();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                int dispatchID;
                if (int.TryParse(Request.Form["dispatch"], out dispatchID))
                {
                    Order myOrder = repository.Order.Where(x => x.OrderId == dispatchID).FirstOrDefault();
                    if (myOrder != null)
                    {
                        myOrder.Dispatched = true;
                        repository.SaveOrder(myOrder);
                    }
                }
            }
        }

        public IEnumerable<Order> GetOrders([Control] bool showDispatched)
        {
            if (showDispatched)
                return repository.Order;
            else
                return repository.Order.Where(o => !o.Dispatched);
        }

        public decimal Total(IEnumerable<OrderLine> orderLines)
        {
            decimal total = 0;
            foreach (OrderLine ol in orderLines)
            {
                total += ol.Service.Price * ol.Quantity;
            }
            return total;
        }

    }
}