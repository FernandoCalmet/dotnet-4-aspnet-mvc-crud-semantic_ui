using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using CSharp_ASPNET_MVC_CRUD_SQL.Models;
using CSharp_ASPNET_MVC_CRUD_SQL.Filters;

namespace CSharp_ASPNET_MVC_CRUD_SQL.Controllers
{
    public class UserController : Controller
    {
        private ExampleDBEntities db = new ExampleDBEntities();

        // GET: User
        [VerifyAuth(id_operation: 20)]
        public ActionResult Index()
        {
            var users = db.Users.Include(u => u.Roles);
            return View(users.ToList());
        }

        // GET: User/Details/5
        [VerifyAuth(id_operation: 18)]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Users users = db.Users.Find(id);
            if (users == null)
            {
                return HttpNotFound();
            }
            return View(users);
        }

        // GET: User/Create
        [VerifyAuth(id_operation: 16)]
        public ActionResult Create()
        {
            ViewBag.id_role = new SelectList(db.Roles, "id_role", "name");
            return View();
        }

        // POST: User/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [VerifyAuth(id_operation: 16)]
        public ActionResult Create([Bind(Include = "id_user,id_role,email,password,name")] Users users)
        {
            if (ModelState.IsValid)
            {
                db.Users.Add(users);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_role = new SelectList(db.Roles, "id_role", "name", users.id_role);
            return View(users);
        }

        // GET: User/Edit/5
        [VerifyAuth(id_operation: 19)]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Users users = db.Users.Find(id);
            if (users == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_role = new SelectList(db.Roles, "id_role", "name", users.id_role);
            return View(users);
        }

        // POST: User/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [VerifyAuth(id_operation: 19)]
        public ActionResult Edit([Bind(Include = "id_user,id_role,email,password,name")] Users users)
        {
            if (ModelState.IsValid)
            {
                db.Entry(users).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_role = new SelectList(db.Roles, "id_role", "name", users.id_role);
            return View(users);
        }

        // GET: User/Delete/5
        [VerifyAuth(id_operation: 17)]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Users users = db.Users.Find(id);
            if (users == null)
            {
                return HttpNotFound();
            }
            return View(users);
        }

        // POST: User/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [VerifyAuth(id_operation: 17)]
        public ActionResult DeleteConfirmed(int id)
        {
            Users users = db.Users.Find(id);
            db.Users.Remove(users);
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
