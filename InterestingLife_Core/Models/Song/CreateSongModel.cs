using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InterestingLife_Core.Abstractions;

namespace InterestingLife_Core.Models.Song
{
    public class CreateSongModel : ViewModelBase
    {
        public string Name { get; set; }
        public string Lirycs { get; set; }  
        public int  CategoryId { get; set; } 
    }
}
