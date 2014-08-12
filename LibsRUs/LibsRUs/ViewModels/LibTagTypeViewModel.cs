using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using LibsRUs.Models;

namespace LibsRUs.ViewModels
{
    public class LibTagTypeViewModel
    {
        public LibTagTypeViewModel()
        {
            this.LibTags = new List<LibTag>();
        }

        public LibTagTypeViewModel(LibTagType model)
        {
            this.LibTags = model.LibTags.ToList();
            this.ID = model.ID;
            this.Name = model.Name;
        }

        public Int32 ID { get; set; }
        public String Name { get; set; }
        public String PluralName { get { return (Name.EndsWith("Y", StringComparison.OrdinalIgnoreCase) ? Name.Substring(0, Name.Length - 1) + "ies" : Name + "s"); } }

        public List<LibTag> LibTags { get; set; }
    }
}