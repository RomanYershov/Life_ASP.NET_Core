using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InterestingLife_Core.Models.Abstractions;

namespace InterestingLife_Core.Models
{
    public class User : Entity
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PaswordHash { get; set; }     
        public bool IsAuthenticated { get; set; }
    }
}
