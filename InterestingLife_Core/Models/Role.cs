using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InterestingLife_Core.Models.Abstractions;
using Microsoft.AspNetCore.Identity;

namespace InterestingLife_Core.Models
{
    public class Role : Entity
    {
        public string Name { get; set; } 
        public virtual List<Permission> Permissions { get; set; }

        public Role()
        {
            Permissions = new List<Permission>();
        }
    }
}
