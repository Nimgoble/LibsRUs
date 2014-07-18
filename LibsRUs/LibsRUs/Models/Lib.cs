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
            this.ProgrammingLanguages = new HashSet<ProgrammingLanguage>();
            this.Platforms = new HashSet<Platform>();
        }

        public Int32 ID { get; set; }
        [Required]
        public String Name { get; set; }
        [Required]
        public String Description { get; set; }
        [Required]
        public String LibURL { get; set; }

        public virtual ICollection<LibTag> LibTags { get; set; }
        public virtual ICollection<UserFavoriteLib> UserFavoriteLibs { get; set; }
        public virtual ICollection<ProgrammingLanguage> ProgrammingLanguages { get; set; }
        public virtual ICollection<Platform> Platforms { get; set; }
    }
}