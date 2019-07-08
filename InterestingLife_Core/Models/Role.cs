using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InterestingLife_Core.Models.Abstractions;
using Microsoft.AspNetCore.Identity;

namespace InterestingLife_Core.Models
{
    public class Role : IdentityRole
    {
        public string Name { get; set; }
        //public ISet<IdentityUser> Users { get; set; }   
        public List<Permission> Permissions { get; set; }

        public Role()
        {
            Permissions = new List<Permission>();
           // Users = new HashSet<IdentityUser>();
        }
    }
}
