using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InterestingLife_Core.Models.Abstractions;
using Microsoft.AspNetCore.Identity;

namespace InterestingLife_Core.Models
{
    public class Permission : Entity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        //public  RoleManager<Role> RoleManager;

        public Permission()
        {
           // RoleManager.Roles.Where(x => x.Name == "admin");
        }

    }
}
