using System.Web.Mvc;

namespace CSharp_ASPNET_MVC_CRUD_SQL.Controllers
{
    public class SignOutController : Controller
    {
        // GET: SignOut
        public ActionResult Logout()
        {
            Session["txtUser"] = null;
            return View();
        }
    }
}