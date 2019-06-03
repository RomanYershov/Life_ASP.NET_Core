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
        public List<Category> Categories { get; set; }

        public CreateSongModel() => Categories = new List<Category>();
    }
}
