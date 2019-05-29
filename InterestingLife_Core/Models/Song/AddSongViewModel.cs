using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterestingLife_Core.Models.Song
{
    public class AddSongViewModel : Song
    {
        public IEnumerable<Category> Categories { get; set; }  
    }
}
