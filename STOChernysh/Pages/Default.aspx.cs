using STOChernysh.Models;
using STOChernysh.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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

        }

        private List<Service> FilterService()
        {
            List<Service> service = repository.Service.ToList();
            string currentCategory = (string)RouteData.Values["category"] ??
                Request.QueryString["category"];
            return currentCategory == null ? service :
                service.Where(p => p.Category.Where(c=>c.Name==currentCategory).ToList() != null).ToList();
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