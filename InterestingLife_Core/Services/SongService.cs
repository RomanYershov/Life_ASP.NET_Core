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
                    Lyrics = model.Lirycs,
                    CreateDate = DateTime.Now
                };
                _dbContext.Songs.Add(song);
                _dbContext.SaveChanges();

                foreach (var category in model.Categories)
                {
                    var songToCategory = new SongsToCategories
                    {
                        Category = _dbContext.Categories.SingleOrDefault(x => x.Id == category.Id),
                        Song = song
                    };
                    _dbContext.SongsToCategorieses.Add(songToCategory);
                }
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                return new SimpleResponse(errorText:ex.InnerException.Message);
            }
            return new SimpleResponse();
        }



        public SimpleResponse Delete(int id)
        {
            try
            {
                var songToCategories = _dbContext.SongsToCategorieses.Where(x => x.Song.Id == id);

                foreach (var songToCategory in songToCategories)
                {
                    _dbContext.SongsToCategorieses.Remove(songToCategory);
                }
                _dbContext.Songs.Remove(_dbContext.Songs.Find(id));
                _dbContext.SaveChanges();
            }
            catch (Exception e)
            {
                return new SimpleResponse(errorText: e.InnerException.Message);
            }
            return new SimpleResponse();
        }

        public SimpleResponse Delete(Song entity)
        {
            try
            {
                var songToCategories = _dbContext.SongsToCategorieses.Where(x => x.Song.Id == entity.Id);

                foreach (var songToCategory in songToCategories)
                {
                    _dbContext.SongsToCategorieses.Remove(songToCategory);
                }
                _dbContext.Songs.Remove(entity);
                _dbContext.SaveChanges();
            }
            catch (Exception e)
            {
                return new SimpleResponse(errorText:e.InnerException.Message);
            }
            return new SimpleResponse();
        }

        public SimpleResponse Update(int id, Song song)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Song> Get()
        {
            return _dbContext.Songs.OrderBy(x => x.CreateDate);
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

        public SimpleResponse GetSongsWithCategories()
        {
            var songsWithCategories = _dbContext.SongsToCategorieses.Include(x => x.Song).Include(x => x.Category).GroupBy(x => x.Song);
            List<SongsWithCategories> songsWithCategorieses = new List<SongsWithCategories>();
            foreach (var group in songsWithCategories)
            {
                var obj = new SongsWithCategories();
                foreach (var item in group)
                {
                    obj.Song = item.Song;
                    obj.Categories.Add(item.Category);
                }
                songsWithCategorieses.Add(obj);
            }

            return new SimpleResponse(songsWithCategorieses);
        }

        class SongsWithCategories
        {
            public Song Song { get; set; }
            public List<Category> Categories { get; set; }

            public SongsWithCategories()
            {
                Categories = new List<Category>();
            }
        }
    }
}
