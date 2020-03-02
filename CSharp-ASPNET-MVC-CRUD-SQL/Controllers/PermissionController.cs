using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using CSharp_ASPNET_MVC_CRUD_SQL.Models;
using CSharp_ASPNET_MVC_CRUD_SQL.Filters;

namespace CSharp_ASPNET_MVC_CRUD_SQL.Controllers
{
    public class PermissionController : Controller
    {
        private ExampleDBEntities db = new ExampleDBEntities();

        // GET: Permission
        [VerifyAuth(id_operation: 15)]
        public ActionResult Index()
        {
            var permissions = db.Permissions.Include(p => p.Operations).Include(p => p.Roles);
            return View(permissions.ToList());
        }

        // GET: Permission/Details/5
        [VerifyAuth(id_operation: 13)]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Permissions permissions = db.Permissions.Find(id);
            if (permissions == null)
            {
                return HttpNotFound();
            }
            return View(permissions);
        }

        // GET: Permission/Create
        [VerifyAuth(id_operation: 11)]
        public ActionResult Create()
        {
            ViewBag.id_operation = new SelectList(db.Operations, "id_operation", "name");
            ViewBag.id_role = new SelectList(db.Roles, "id_role", "name");
            return View();
        }

        // POST: Permission/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [VerifyAuth(id_operation: 11)]
        public ActionResult Create([Bind(Include = "id_permission,id_role,id_operation")] Permissions permissions)
        {
            if (ModelState.IsValid)
            {
                db.Permissions.Add(permissions);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_operation = new SelectList(db.Operations, "id_operation", "name", permissions.id_operation);
            ViewBag.id_role = new SelectList(db.Roles, "id_role", "name", permissions.id_role);
            return View(permissions);
        }

        // GET: Permission/Edit/5
        [VerifyAuth(id_operation: 14)]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Permissions permissions = db.Permissions.Find(id);
            if (permissions == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_operation = new SelectList(db.Operations, "id_operation", "name", permissions.id_operation);
            ViewBag.id_role = new SelectList(db.Roles, "id_role", "name", permissions.id_role);
            return View(permissions);
        }

        // POST: Permission/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [VerifyAuth(id_operation: 14)]
        public ActionResult Edit([Bind(Include = "id_permission,id_role,id_operation")] Permissions permissions)
        {
            if (ModelState.IsValid)
            {
                db.Entry(permissions).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_operation = new SelectList(db.Operations, "id_operation", "name", permissions.id_operation);
            ViewBag.id_role = new SelectList(db.Roles, "id_role", "name", permissions.id_role);
            return View(permissions);
        }

        // GET: Permission/Delete/5
        [VerifyAuth(id_operation: 12)]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Permissions permissions = db.Permissions.Find(id);
            if (permissions == null)
            {
                return HttpNotFound();
            }
            return View(permissions);
        }

        // POST: Permission/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [VerifyAuth(id_operation: 12)]
        public ActionResult DeleteConfirmed(int id)
        {
            Permissions permissions = db.Permissions.Find(id);
            db.Permissions.Remove(permissions);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
