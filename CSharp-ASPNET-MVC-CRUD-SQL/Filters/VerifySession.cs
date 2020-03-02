using System;
using System.Web;
using System.Web.Mvc;
using CSharp_ASPNET_MVC_CRUD_SQL.Controllers;
using CSharp_ASPNET_MVC_CRUD_SQL.Models;

namespace CSharp_ASPNET_MVC_CRUD_SQL.Filters
{
    public class VerifySession : ActionFilterAttribute
    {
        private Users oUser;
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            try
            {
                base.OnActionExecuted(filterContext);

                oUser = (Users)HttpContext.Current.Session["txtUser"];

                //Validar si no hay session redireccionar al login
                if (oUser == null)
                {
                    if (filterContext.Controller is SignInController == false)
                    {
                        filterContext.HttpContext.Response.Redirect("/SignIn/Login");
                    }
                }
            }
            catch (Exception)
            {
                filterContext.Result = new RedirectResult("~/SignIn/Login");
            }
        }
    }
}