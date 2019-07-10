using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InterestingLife_Core.Models.Abstractions;
using Microsoft.AspNetCore.Identity;

namespace InterestingLife_Core.Models
{
    public sealed class User : Entity
    {
        public Role Role { get; set; }    
        public string Login { get; set; }
        public string Email { get; set; }   
        public string PasswordHash { get; set; }
        public string Salt { get; set; }
        public string ReferalLink { get; set; } 
    }
}
