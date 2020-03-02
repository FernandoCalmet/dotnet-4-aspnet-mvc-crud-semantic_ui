using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CSharp_ASPNET_MVC_CRUD_SQL.Models;

namespace CSharp_ASPNET_MVC_CRUD_SQL.Filters
{
    // Verificar por metodos
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public class VerifyAuth : AuthorizeAttribute
    {
        private Users oUser;
        private ExampleDBEntities bd = new ExampleDBEntities();
        private int idOperation;

        public VerifyAuth(int id_operation = 0)
        {
            this.idOperation = id_operation;
        }

        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            String operationName = "";
            String moduleName = "";

            try
            {
                // Obtener la session del usuario
                oUser = (Users)HttpContext.Current.Session["txtUser"];
                var operationsList = from m in bd.Permissions
                                       where m.id_role == oUser.id_role
                                       && m.id_operation == idOperation
                                       select m;

                if (operationsList.ToList().Count() == 0)
                {
                    // En caso de no tener autorizacion
                    var oOperacion = bd.Operations.Find(idOperation);
                    int? idModulo = oOperacion.id_module;
                    operationName = getOperationName(idOperation);
                    moduleName = getModuleName(idModulo);
                    filterContext.Result = new RedirectResult("~/Error/UnauthorizedOperation?operation=" + operationName);
                }
            }
            catch (Exception)
            {
                filterContext.Result = new RedirectResult("~/Error/UnauthorizedOperation?operation=" + operationName);
            }
        }

        public string getOperationName(int id_operation)
        {
            var oOperation = from op in bd.Operations
                            where op.id_operation == id_operation
                            select op.name;

            String operationName;

            try
            {
                operationName = oOperation.First();
            }
            catch (Exception)
            {
                operationName = "";
            }

            return operationName;
        }

        public string getModuleName(int? id_module)
        {
            var oModule = from m in bd.Modules
                         where m.id_module == id_module
                         select m.name;

            String moduleName;

            try
            {
                moduleName = oModule.First();
            }
            catch (Exception)
            {
                moduleName = "";
            }

            return moduleName;
        }
    }
}