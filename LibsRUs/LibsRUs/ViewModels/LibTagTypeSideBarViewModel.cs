using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using LibsRUs.Models;
namespace LibsRUs.ViewModels
{
    public class LibTagTypeSideBarViewModel : LibTagTypeViewModel
    {
        public LibTagTypeSideBarViewModel()
        {
            this.LibTags = new List<LibTag>();
        }
        public Boolean HasMoreLibTags { get; set; }
    }
}