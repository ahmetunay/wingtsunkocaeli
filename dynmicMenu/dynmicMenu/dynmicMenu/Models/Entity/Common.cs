using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace dynmicMenu.Models.Entity {
    public class Common {
        public MainMenu mm { set; get; }
        public List<MainMenu> Mlist { get; set; }

        public SubMenu ss { set; get; }
        public List<SubMenu> Slist { get; set; }

        public Contact c { set; get; }
        public List<Contact> Clist { get; set; }
      
        public News n { set; get; }
        public List<News> Nlist { get; set; }

        public Visit v { set; get; }
        public List<Visit> Vlist { get; set; }

        public List<News> SearchedNlist { get; set; } //Test

        public Image Img{ set; get; }
        public List<Image> ImgList { get; set; }

        public Galery g   { set; get; }
        public List<Galery> gList { get; set; }






    }
}