using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace LibsRUs.Models
{
    public class Lib
    {
        public Lib()
        {
            this.LibTags = new HashSet<LibTag>();
            this.UserFavoriteLibs = new HashSet<UserFavoriteLib>();
        }

        public Int32 ID { get; set; }
        [Required]
        public String Name { get; set; }
        [Required]
        public String Description { get; set; }
        [Required]
        [Display(Name="Library Site")]
        public String LibURL { get; set; }

        public virtual ICollection<LibTag> LibTags { get; set; }
        public virtual ICollection<UserFavoriteLib> UserFavoriteLibs { get; set; }
    }
}