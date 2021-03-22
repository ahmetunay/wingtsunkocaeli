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
    public class GaleriesController : Controller
    {
        private DBDynamicEntities db = new DBDynamicEntities();

        // GET: Galeries
        public ActionResult Index()
        {
            return View(db.Galeries.ToList());
        }

        // GET: Galeries/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var model = new Common();

            model.gList = db.Galeries.ToList();
         
            return View(model);
        }
        public ActionResult VideoGaleri(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var model = new Common();
            Galery g = db.Galeries.Find(id);
            model.Mlist = db.MainMenus.ToList();// Menülerin Listesi
            model.Nlist = db.News.ToList();//Haberlerin Listelenmesi
            model.gList = db.Galeries.ToList();//Videoların Listelenmesi
            model.g = g;
        
            return View(model);

        }

        // GET: Galeries/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Galeries/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,name")] Galery galery)
        {
            if (ModelState.IsValid)
            {
                db.Galeries.Add(galery);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(galery);
        }

        // GET: Galeries/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Galery galery = db.Galeries.Find(id);
            if (galery == null)
            {
                return HttpNotFound();
            }
            return View(galery);
        }

        // POST: Galeries/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,name")] Galery galery)
        {
            if (ModelState.IsValid)
            {
                db.Entry(galery).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(galery);
        }

        // GET: Galeries/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Galery galery = db.Galeries.Find(id);
            if (galery == null)
            {
                return HttpNotFound();
            }
            return View(galery);
        }

        // POST: Galeries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Galery galery = db.Galeries.Find(id);
            db.Galeries.Remove(galery);
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
