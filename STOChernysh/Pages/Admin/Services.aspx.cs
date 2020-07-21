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
    public partial class Services : System.Web.UI.Page
    {
        private Repository repository = new Repository();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public IEnumerable<Service> GetServices() => repository.Service;


        public void UpdateService(int gameID)
        {
            Service myGame = repository.Service.Where(p => p.ServiceId == gameID).FirstOrDefault();
            if (myGame != null && TryUpdateModel(myGame, new FormValueProvider(ModelBindingExecutionContext)))
            {
                repository.SaveGame(myGame);
            }
        }

        public void DeleteService(int gameID)
        {
            Service myGame = repository.Service.Where(p => p.ServiceId == gameID).FirstOrDefault();
            if (myGame != null)
            {
                repository.DeleteGame(myGame);
            }
        }
        public void InsertService()
        {
            Service service = new Service();
            if (TryUpdateModel(service, new FormValueProvider(ModelBindingExecutionContext)))
            {
                repository.SaveGame(service);
            }
        }
        public string GetCategory(int ctgid)
        {
            return repository.Category.Where(c => c.CategoryId == ctgid).FirstOrDefault().Name;
        }
    }
}