using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InterestingLife_Core.Models.Abstractions;

namespace InterestingLife_Core.Models.Song
{
    public class Song : Entity
    {
        public string Name { get; set; }    
        public string Lyrics { get; set; }
        public DateTime CreateDate { get; set; }    
    }
}
