using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InterestingLife_Core.Models.Abstractions;
using Microsoft.AspNetCore.Identity;

namespace InterestingLife_Core.Models
{
    public class User : IdentityUser
    {
        //public List<Role> Roles { get; set; }
        public string ReferalLink { get; set; } 
        //public User() => Roles = new List<Role>();
    }
}
