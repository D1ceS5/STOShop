using STOChernysh.Models;
using STOChernysh.Models.Repository;
using STOChernysh.Pages.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace STOChernysh.Pages.Admin
{
    public partial class Master : System.Web.UI.Page
    {
        Repository repository = new Repository();
        protected void Page_Load(object sender, EventArgs e)
        {
            int dispatchID;
            if (int.TryParse(Request.Form["dispatch"], out dispatchID))
            {
                Order myOrder = repository.Order.Where(x => x.OrderId == dispatchID).FirstOrDefault();
                if (myOrder != null)
                {
                    repository.DeleteOrder(myOrder);
                }
            }
        }
        public IEnumerable<Order> GetOrders()
        {
         
                return repository.Order.Where(o => o.Masters_MasterId == MasterHelper.MasterId);
        }
        public void GetMasterName()
        {
            Response.Write(repository.Master.Where(m => m.MasterId == MasterHelper.MasterId).FirstOrDefault().Name);
        }
    }
}