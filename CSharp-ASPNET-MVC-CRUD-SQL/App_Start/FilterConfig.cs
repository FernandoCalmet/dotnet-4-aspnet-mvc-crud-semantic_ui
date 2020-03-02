using System.Web;
using System.Web.Mvc;

namespace CSharp_ASPNET_MVC_CRUD_SQL
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new Filters.VerifySession()); //Activar el filtro del login
        }
    }
}
