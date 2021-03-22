using System;
using System.Collections.Generic;
using System.Web;
using System.Linq;
using System.Data.Entity;
using dynmicMenu.Models;
using System.Web.Mvc;
using dynmicMenu.Models.Entity;

namespace dynmicMenu.Controllers {
    public class HomeController : Controller {

        DBDynamicEntities db = new DBDynamicEntities();
       


        public ActionResult Index() {

            var model = new Common();
            model.Mlist = db.MainMenus.ToList();// Menülerin Listesi
            model.Nlist = db.News.ToList();//Haberler Listelenmesi
            return View(model);
        }
        public ActionResult Video()
        {
            return View();
        }
        public ActionResult Panel()
        {
            return View();
        }

        public ActionResult T() {
            using (var db = new DBDynamicEntities()) {
      
                var model = new Common();
                model.Mlist = db.MainMenus.ToList();

                var subMenus = db.SubMenus.Include(s => s.MainMenu);
                model.Slist = subMenus.ToList();
                return View(model);
            }
          
        }







    }
}
