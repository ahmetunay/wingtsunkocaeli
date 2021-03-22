using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using dynmicMenu.Models.Entity;

namespace dynmicMenu.Controllers
{
    public class SubMenusController : Controller
    {
        private DBDynamicEntities db = new DBDynamicEntities();


        // GET: SubMenus
        public ActionResult Index()
        {
            var subMenus = db.SubMenus.Include(s => s.MainMenu);
            return View(subMenus.ToList());
        }

        // GET: SubMenus/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SubMenu subMenu = db.SubMenus.Find(id);
            if (subMenu == null)
            {
                return HttpNotFound();
            }
            return View(subMenu);
        }

        public ActionResult Show(int? id) {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var model = new Common();
            SubMenu subMenu = db.SubMenus.Find(id);


            if (subMenu == null) {
                return HttpNotFound();
            }

            model.Mlist = db.MainMenus.ToList();// Menülerin Listesi
            model.Nlist = db.News.ToList();
            model.ss = subMenu;
            return View(model);

        }



        // GET: SubMenus/Create
        public ActionResult Create()
        {
            ViewBag.mainmenuid = new SelectList(db.MainMenus, "id", "menuname");
            return View();
        }

        // POST: SubMenus/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,submenuname,submenuurl,mainmenuid,text")] SubMenu subMenu)
        {
            if (ModelState.IsValid)
            {
                db.SubMenus.Add(subMenu);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.mainmenuid = new SelectList(db.MainMenus, "id", "menuname", subMenu.mainmenuid);
            return View(subMenu);
        }

        // GET: SubMenus/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SubMenu subMenu = db.SubMenus.Find(id);
            if (subMenu == null)
            {
                return HttpNotFound();
            }
            ViewBag.mainmenuid = new SelectList(db.MainMenus, "id", "menuname", subMenu.mainmenuid);
            return View(subMenu);
        }

        // POST: SubMenus/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,submenuname,submenuurl,mainmenuid,text")] SubMenu subMenu)
        {
            if (ModelState.IsValid)
            {
                db.Entry(subMenu).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.mainmenuid = new SelectList(db.MainMenus, "id", "menuname", subMenu.mainmenuid);
            return View(subMenu);
        }

        // GET: SubMenus/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SubMenu subMenu = db.SubMenus.Find(id);
            if (subMenu == null)
            {
                return HttpNotFound();
            }
            return View(subMenu);
        }

        // POST: SubMenus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SubMenu subMenu = db.SubMenus.Find(id);
            db.SubMenus.Remove(subMenu);
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
