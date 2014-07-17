using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNet.Identity.EntityFramework;

namespace LibsRUs.Models
{
    public class User: IdentityUser
    {
        public User()
        {
            this.UserFavoriteLibs = new HashSet<UserFavoriteLib>();
        }

        public virtual ICollection<UserFavoriteLib> UserFavoriteLibs { get; set; }
    }
}