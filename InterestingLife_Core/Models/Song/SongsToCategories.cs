using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InterestingLife_Core.Models.Abstractions;

namespace InterestingLife_Core.Models.Song
{
    public class SongsToCategories : Entity
    {
        public Song Song { get; set; }
        public Category Category { get; set; }  
    }
}
