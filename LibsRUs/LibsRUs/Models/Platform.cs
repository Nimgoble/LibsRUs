using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibsRUs.Models
{
    public class Platform
    {
        public Platform()
        {
            this.Libs = new HashSet<Lib>();
        }

        public Int32 ID { get; set; }
        [Required]
        [Index("NameIndex", IsUnique = true)]
        [StringLength(50)]
        public String Name { get; set; }

        public virtual ICollection<Lib> Libs { get; set; }
    }
}