using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InterestingLife_Core.Models.Song;

namespace InterestingLife_Core.Abstractions
{
    interface ISongService : IService<Song, CreateSongModel> 
    {
        IEnumerable<Song> GetSongsByCategoryId(int categoryId);
    }
}
