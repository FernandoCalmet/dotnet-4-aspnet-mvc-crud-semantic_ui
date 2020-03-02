using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using CSharp_ASPNET_MVC_CRUD_SQL.Models;
using CSharp_ASPNET_MVC_CRUD_SQL.Filters;

namespace CSharp_ASPNET_MVC_CRUD_SQL.Controllers
{
    public class ModuleController : Controller
    {
        private ExampleDBEntities db = new ExampleDBEntities();

        // GET: Module
        [VerifyAuth(id_operation: 25)]
        public ActionResult Index()
        {
            return View(db.Modules.ToList());
        }

        // GET: Module/Details/5
        [VerifyAuth(id_operation: 18)]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Modules modules = db.Modules.Find(id);
            if (modules == null)
            {
                return HttpNotFound();
            }
            return View(modules);
        }

        // GET: Module/Create
        [VerifyAuth(id_operation: 21)]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Module/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [VerifyAuth(id_operation: 21)]
        public ActionResult Create([Bind(Include = "id_module,name")] Modules modules)
        {
            if (ModelState.IsValid)
            {
                db.Modules.Add(modules);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(modules);
        }

        // GET: Module/Edit/5
        [VerifyAuth(id_operation: 19)]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Modules modules = db.Modules.Find(id);
            if (modules == null)
            {
                return HttpNotFound();
            }
            return View(modules);
        }

        // POST: Module/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [VerifyAuth(id_operation: 19)]
        public ActionResult Edit([Bind(Include = "id_module,name")] Modules modules)
        {
            if (ModelState.IsValid)
            {
                db.Entry(modules).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(modules);
        }

        // GET: Module/Delete/5
        [VerifyAuth(id_operation: 17)]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Modules modules = db.Modules.Find(id);
            if (modules == null)
            {
                return HttpNotFound();
            }
            return View(modules);
        }

        // POST: Module/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [VerifyAuth(id_operation: 17)]
        public ActionResult DeleteConfirmed(int id)
        {
            Modules modules = db.Modules.Find(id);
            db.Modules.Remove(modules);
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
