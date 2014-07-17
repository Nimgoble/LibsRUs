using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace LibsRUs.Models
{
    public class LibTag
    {
        public LibTag()
        {
            this.Libs = new HashSet<Lib>();
        }

        public Int32 ID { get; set; }
        [Required]
        public String TagText { get; set; }

        public virtual ICollection<Lib> Libs { get; set; }
    }
}