using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        [Index("TagTextIndex", IsUnique = true)]
        [StringLength(75)]
        public String TagText { get; set; }

        public String Description { get; set; }

        public virtual ICollection<Lib> Libs { get; set; }
    }
}