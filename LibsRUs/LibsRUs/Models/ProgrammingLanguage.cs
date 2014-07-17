using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace LibsRUs.Models
{
    public class ProgrammingLanguage
    {
        public Int32 ID { get; set; }
        [Required]
        public String Name { get; set; }
        [Required]
        public String Abbreviation { get; set; }
    }
}