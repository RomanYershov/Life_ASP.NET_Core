using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InterestingLife_Core.Models.Abstractions;

namespace InterestingLife_Core.Models.Song
{
    public class Category : Entity
    {
        public string Name { get; set; }    
        //public List<Song> Songs { get; set; }

        //public Category()
        //{
        //    Songs = new List<Song>();
        //}
    }
}
