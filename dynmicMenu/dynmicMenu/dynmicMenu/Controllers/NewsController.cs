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
    public class NewsController : Controller
    {
        private DBDynamicEntities db = new DBDynamicEntities();

        // GET: News
        public ActionResult Index()
        {
            return View(db.News.ToList());
        }
        public ActionResult Haberler() {
            var model = new Common();
            model.Mlist = db.MainMenus.ToList();// Menülerin Listesi
            model.Nlist = db.News.ToList();//Haberler Listelenmesi

            return View(model);
        }
        public ActionResult TagSearch(string search)
        {
            var model = new Common();
            model.Mlist = db.MainMenus.ToList();// Menülerin Listesi
            model.Nlist = db.News.ToList();//Haberler Listelenmesi

            string words = search;
            var posts = (from p in db.News where words.Any(w => p.news1.Contains(w)) select p).ToList();
            model.SearchedNlist = posts;
            return View(model);
        }

        // GET: News/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            News news = db.News.Find(id);
            if (news == null)
            {
                return HttpNotFound();
            }
            return View(news);
        }
        public ActionResult Show(int? id) {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var model = new Common();
            News news = db.News.Find(id);


            if (news == null) {
                return HttpNotFound();
            }

            model.Mlist = db.MainMenus.ToList();// Menülerin Listesi
            model.Nlist = db.News.ToList();//Haberlerin Listelenmesi
            model.n = news;
            return View(model);

        }

        // GET: News/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: News/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,newstitle,news1,date")] News news)
        {
            if (ModelState.IsValid)
            {
                db.News.Add(news);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(news);
        }

        // GET: News/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            News news = db.News.Find(id);
            if (news == null)
            {
                return HttpNotFound();
            }
            return View(news);
        }

        // POST: News/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,newstitle,news1,date")] News news)
        {
            if (ModelState.IsValid)
            {
                db.Entry(news).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(news);
        }

        // GET: News/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            News news = db.News.Find(id);
            if (news == null)
            {
                return HttpNotFound();
            }
            return View(news);
        }

        // POST: News/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            News news = db.News.Find(id);
            db.News.Remove(news);
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
