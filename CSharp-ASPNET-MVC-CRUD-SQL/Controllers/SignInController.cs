using System;
using System.Linq;
using System.Web.Mvc;
using CSharp_ASPNET_MVC_CRUD_SQL.Models;

namespace CSharp_ASPNET_MVC_CRUD_SQL.Controllers
{
    public class SignInController : Controller
    {
        // GET: SignIn
        public ActionResult Login()
        {
            return View();
        }

        // Solicitud POST del login
        [HttpPost]
        public ActionResult Login(string txtUser, string txtPassword)
        {
            try
            {
                using (ExampleDBEntities bd = new ExampleDBEntities())
                {
                    var oUser = (from d in bd.Users
                                 where d.email == txtUser.Trim() && d.password == txtPassword.Trim()
                                 select d).FirstOrDefault(); //retornar el elemento o null

                    if (oUser == null)
                    {
                        ViewBag.Error = "Username or password is not valid.";
                        return View();
                    }

                    Session["txtUser"] = oUser;
                }
                return RedirectToAction("Index", "Home");
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View();
            }
        }
    }
}