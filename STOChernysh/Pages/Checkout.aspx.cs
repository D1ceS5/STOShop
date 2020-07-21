using STOChernysh.Models;
using STOChernysh.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace STOChernysh.Pages
{
    public partial class Checkout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            checkoutForm.Visible = true;
            checkoutMessage.Visible = false;

            if (IsPostBack)
            {
                Order order = new Order();
                if (TryUpdateModel(order, new FormValueProvider(ModelBindingExecutionContext)))
                {
                    order.OrderLines = new List<OrderLine>();

                    Crt cart = SessionHelper.GetCart(Session);

                    foreach (CrtLine line in cart.Lines)
                    {
                        order.OrderLines.Add(new OrderLine()
                        {
                            Order = order,
                            Service = line.Service,
                            Quantity = line.Quantity
                        });
                    }

                    new Repository().SaveOrder(order);
                    cart.Clear();

                    checkoutForm.Visible = false;
                    checkoutMessage.Visible = true;
                }
            }
        }
    }
}