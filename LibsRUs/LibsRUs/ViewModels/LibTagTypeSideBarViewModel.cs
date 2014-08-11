using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using LibsRUs.Models;
namespace LibsRUs.ViewModels
{
    public class LibTagTypeSideBarViewModel
    {
        public LibTagTypeSideBarViewModel()
        {
            this.LibTags = new List<LibTag>();
            //this.ID = model.ID;
            //this.Name = model.Name;
            //this.LibTags = model.LibTags.OrderByDescending(x => x.Libs.Count).Take(/*maxViewableTags*/ 10).ToList();
            //this.HasMoreLibTags = model.LibTags.Count > 10;// maxViewableTags;
        }

        public Int32 ID { get; set; }
        public String Name { get; set; }
        public String PluralName { get { return (Name.EndsWith("Y", StringComparison.OrdinalIgnoreCase) ? Name.Substring(0, Name.Length - 1) + "ies" : Name + "s"); } }
        public Boolean HasMoreLibTags { get; set; }

        public List<LibTag> LibTags { get; set; }
    }
}