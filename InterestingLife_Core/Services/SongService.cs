using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InterestingLife_Core.Abstractions;
using InterestingLife_Core.Data;
using InterestingLife_Core.Helpers;
using InterestingLife_Core.Models.Song;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace InterestingLife_Core.Services
{
    public class SongService : ISongService
    {
        public LifeDbContext _dbContext;

        public SongService(LifeDbContext context)
        {
            _dbContext = context;
        }
        public SimpleResponse Create(CreateSongModel song)
        {
            try
            {
                _dbContext.Songs.Add(song.Song);
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
               return new SimpleResponse(ex);
            }
            return new SimpleResponse();
        }

       

        public SimpleResponse Delete(int id)
        {
            try
            {
                var song = _dbContext.Songs.SingleOrDefault(x => x.Id == id);
                _dbContext.Remove(song);
                _dbContext.SaveChanges();
            }
            catch (Exception e)
            {
                return new SimpleResponse(e);
            }
            return new SimpleResponse();
        }

        public SimpleResponse Update(int id, Song song)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Song> Get()
        {
            return _dbContext.Songs;
        }

        public SimpleResponse Get(int id)
        {
            var song = _dbContext.Songs.Find(id);
            return new SimpleResponse(song);
        }

        public IEnumerable<Song> GetSongsByCategoryId(int categoryId)
        {
            var songs = _dbContext.SongsToCategorieses.Where(x => x.Category.Id == categoryId).Select(x => x.Song);
            return songs;
        }
    }
}
