using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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
        public SimpleResponse Create(CreateSongModel model)
        {
            try
            {
                var song = new Song
                {
                    Name = model.Name,
                    Lyrics = model.Lirycs
                };
                _dbContext.Songs.Add(song);
                _dbContext.SaveChanges();
                var songToCategory = new SongsToCategories
                {
                    Category = _dbContext.Categories.Find(model.CategoryId),
                    Song = song
                };
                _dbContext.SongsToCategorieses.Add(songToCategory);
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
