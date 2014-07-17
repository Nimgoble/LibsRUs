using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibsRUs.Models
{
    public class ProgrammingLanguage
    {
        public Int32 ID { get; set; }
        //[Index("IX_Name", 1, )]
        [Required]
        public String Name { get; set; }
        public String Abbreviation { get; set; }

        public virtual ICollection<Lib> Libs { get; set; }
    }
}