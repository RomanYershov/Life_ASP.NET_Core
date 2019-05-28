using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterestingLife_Core.Models.Abstractions
{
    public abstract class Entity
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }    
    }
}
