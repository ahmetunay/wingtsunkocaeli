//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace dynmicMenu.Models.Entity
{
    using System;
    using System.Collections.Generic;
    
    public partial class Video
    {
        public int id { get; set; }
        public string videourl { get; set; }
        public Nullable<int> galeryid { get; set; }
    
        public virtual Galery Galery { get; set; }
    }
}
