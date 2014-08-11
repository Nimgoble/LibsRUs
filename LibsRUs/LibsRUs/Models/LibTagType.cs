using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibsRUs.Models
{
    public class LibTagType
    {
        public LibTagType()
        {
            this.LibTags = new HashSet<LibTag>();
        }

        public Int32 ID { get; set; }
        public String Name { get; set; }

        public virtual ICollection<LibTag> LibTags { get; set; }
    }
}