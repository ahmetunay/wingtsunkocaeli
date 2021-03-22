using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using dynmicMenu.Models.Entity;
using System.IO;
namespace dynmicMenu.Controllers
{
    public class PhotoController : Controller
    {
        private DBDynamicEntities db = new DBDynamicEntities();

        // GET: Photo
        public ActionResult Index()
        {
            var images = db.Images.Include(i => i.Galery);
            return View(images.ToList());
        }
        [HttpGet]
        public ActionResult Add()
        {
            ViewBag.galeryid = new SelectList(db.Galeries, "id", "name");
            return View();
        }
        [HttpPost]
        public ActionResult Add(Image image)
        {
       

            return View();

        }

        // GET: Photo/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Image image = db.Images.Find(id);
            if (image == null)
            {
                return HttpNotFound();
            }
            return View(image);
        }

        // GET: Photo/Create
        public ActionResult Create()
        {
            ViewBag.galeryid = new SelectList(db.Galeries, "id", "name");
            return View();
        }

        // POST: Photo/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,imagename,imageurl,galeryid")] Image image)
        {
            if (ModelState.IsValid)
            {
                db.Images.Add(image);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.galeryid = new SelectList(db.Galeries, "id", "name", image.galeryid);
            return View(image);
        }

        // GET: Photo/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Image image = db.Images.Find(id);
            if (image == null)
            {
                return HttpNotFound();
            }
            ViewBag.galeryid = new SelectList(db.Galeries, "id", "name", image.galeryid);
            return View(image);
        }

        // POST: Photo/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,imagename,imageurl,galeryid")] Image image)
        {
            if (ModelState.IsValid)
            {
                db.Entry(image).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.galeryid = new SelectList(db.Galeries, "id", "name", image.galeryid);
            return View(image);
        }

        // GET: Photo/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Image image = db.Images.Find(id);
            if (image == null)
            {
                return HttpNotFound();
            }
            return View(image);
        }

        // POST: Photo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Image image = db.Images.Find(id);
            db.Images.Remove(image);
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
