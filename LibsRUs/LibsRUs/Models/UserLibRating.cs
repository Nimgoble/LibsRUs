using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibsRUs.Models
{
    public class UserLibRating
    {
        [Key, Column(Order = 0)]
        public Int32 LibID { get; set; }
        [Key, Column(Order = 1)]
        public Int32 UserID { get; set; }

        public virtual Lib Lib { get; set; }
        public virtual User User { get; set; }

        [Required]
        public Int32 Rating { get; set; }
    }
}