using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using CSharp_ASPNET_MVC_CRUD_SQL.Models;
using CSharp_ASPNET_MVC_CRUD_SQL.Filters;

namespace CSharp_ASPNET_MVC_CRUD_SQL.Controllers
{
    public class OperationController : Controller
    {
        private ExampleDBEntities db = new ExampleDBEntities();

        // GET: Operation
        [VerifyAuth(id_operation: 5)]
        public ActionResult Index()
        {
            var operations = db.Operations.Include(o => o.Modules);
            return View(operations.ToList());
        }

        // GET: Operation/Details/5
        [VerifyAuth(id_operation: 3)]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Operations operations = db.Operations.Find(id);
            if (operations == null)
            {
                return HttpNotFound();
            }
            return View(operations);
        }

        // GET: Operation/Create
        [VerifyAuth(id_operation: 1)]
        public ActionResult Create()
        {
            ViewBag.id_module = new SelectList(db.Modules, "id_module", "name");
            return View();
        }

        // POST: Operation/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [VerifyAuth(id_operation: 1)]
        public ActionResult Create([Bind(Include = "id_operation,name,id_module")] Operations operations)
        {
            if (ModelState.IsValid)
            {
                db.Operations.Add(operations);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_module = new SelectList(db.Modules, "id_module", "name", operations.id_module);
            return View(operations);
        }

        // GET: Operation/Edit/5
        [VerifyAuth(id_operation: 4)]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Operations operations = db.Operations.Find(id);
            if (operations == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_module = new SelectList(db.Modules, "id_module", "name", operations.id_module);
            return View(operations);
        }

        // POST: Operation/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [VerifyAuth(id_operation: 4)]
        public ActionResult Edit([Bind(Include = "id_operation,name,id_module")] Operations operations)
        {
            if (ModelState.IsValid)
            {
                db.Entry(operations).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_module = new SelectList(db.Modules, "id_module", "name", operations.id_module);
            return View(operations);
        }

        // GET: Operation/Delete/5
        [VerifyAuth(id_operation: 2)]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Operations operations = db.Operations.Find(id);
            if (operations == null)
            {
                return HttpNotFound();
            }
            return View(operations);
        }

        // POST: Operation/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [VerifyAuth(id_operation: 2)]
        public ActionResult DeleteConfirmed(int id)
        {
            Operations operations = db.Operations.Find(id);
            db.Operations.Remove(operations);
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
