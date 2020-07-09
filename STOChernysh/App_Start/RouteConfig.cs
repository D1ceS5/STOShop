using System.Web.Routing;

namespace STOChernysh
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.MapPageRoute(null, "", "~/Pages/Default.aspx");
            routes.MapPageRoute(null, "main", "~/Pages/Default.aspx");
            routes.MapPageRoute(null, "main/{page}", "~/Pages/Default.aspx");
            routes.MapPageRoute(null, "main/{category}/{page}", "~/Pages/Default.aspx");
        }
    }
}