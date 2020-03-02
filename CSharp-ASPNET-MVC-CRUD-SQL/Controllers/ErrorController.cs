using System;
using System.Web.Mvc;

namespace CSharp_ASPNET_MVC_CRUD_SQL.Controllers
{
    public class ErrorController : Controller
    {
        // GET: Error
        [HttpGet]
        public ActionResult UnauthorizedOperation(String operation, String module, String ErrorMsgException)
        {
            // Enviar a la vista los atributos de operacion, modulo y la excepcion
            ViewBag.operation = operation;
            ViewBag.module = module;
            ViewBag.errorMsgExcepcion = ErrorMsgException;
            return View();
        }
    }
}