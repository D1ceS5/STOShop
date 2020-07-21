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

            routes.MapPageRoute("cart", "cart", "~/Pages/CartView.aspx");

            routes.MapPageRoute("checkout", "checkout", "~/Pages/Checkout.aspx");


            routes.MapPageRoute("admin_orders", "admin/orders", "~/Pages/Admin/Orders.aspx");
            routes.MapPageRoute("admin_services", "admin/services", "~/Pages/Admin/Services.aspx");
        }
    }
}