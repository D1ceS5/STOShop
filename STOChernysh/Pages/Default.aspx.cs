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
    public partial class Default : System.Web.UI.Page
    {
        Repository repository = new Repository();
        private int pageSize = 4;

        protected int MaxPage
        {
            get
            {
                int prodCount = FilterService().Count();
                return (int)Math.Ceiling((decimal)prodCount / pageSize);
            }
        }

        private int GetPageFromRequest()
        {
            int page;
            string reqValue = (string)RouteData.Values["page"] ?? Request.QueryString["page"];
            return reqValue != null && int.TryParse(reqValue, out page) ? page : 1;
        }

        protected int CurrentPage
        {
            get
            {
                int page;
                page = GetPageFromRequest();
                return page > MaxPage ? MaxPage : page;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            int selectedServId;
            if (int.TryParse(Request.Form["add"], out selectedServId))
            {
                Service selectedGame = repository.Service.Where(g => g.ServiceId == selectedServId).FirstOrDefault();
                if (selectedGame != null)
                {
                    SessionHelper.GetCart(Session).AddItem(selectedGame, 1);
                    SessionHelper.Set(Session, SessionKey.RETURN_URL, Request.RawUrl);

                    Response.Redirect(RouteTable.Routes.GetVirtualPath(null, "cart", null).VirtualPath);
                }
            }
        }

        private IEnumerable<Service> FilterService()
        {
            IEnumerable<Service> service = repository.Service;
            
            string currentCategory = (string)RouteData.Values["category"] ?? Request.QueryString["category"];
            int ctgid = currentCategory == null?-1: repository.Category.Where(c => c.Name == currentCategory).FirstOrDefault().CategoryId;

            if (currentCategory != null)
            {
                Category category = repository.Category.Where(c => c.CategoryId == ctgid).FirstOrDefault();
                IEnumerable<Service> serviceFiltred = service.Where(ct=>ct.Categories_CategoryId == ctgid);
                return serviceFiltred;
            }
            return service;
        }

        public IEnumerable<STOChernysh.Models.Service> GetServices()
        {
            return FilterService().
                 OrderBy(g => g.ServiceId).
                 Skip((CurrentPage - 1) * pageSize).
                 Take(pageSize);
        }
    }
}