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
        public SimpleResponse Create(SongModel model)
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

        public SimpleResponse Update(SongModel model)
        {
            try
            {
                var editingSong = _dbContext.Songs.Find(model.Id);
                if (editingSong.Name != model.Name)
                    editingSong.Name = model.Name;
                if (editingSong.Lyrics != model.Lirycs)
                    editingSong.Lyrics = model.Lirycs;

                var existingCategories = _dbContext.SongsToCategorieses.Where(x => x.Song.Id == model.Id).Include(x => x.Category);
                foreach (var existingCategory in existingCategories)
                {
                    if (model.Categories.All(x => x.Id != existingCategory.Category.Id))
                    {
                        _dbContext.SongsToCategorieses.Remove(existingCategory);
                    }
                }
                foreach (var choosingCategory in model.Categories)
                {
                    if (existingCategories.All(x => x.Category.Id != choosingCategory.Id))
                    {
                         var songToCategory = new SongsToCategories{ Category = _dbContext.Categories.Find(choosingCategory.Id), Song = _dbContext.Songs.Find(model.Id) };
                        _dbContext.SongsToCategorieses.Add(songToCategory);
                    }    
                }

              

                _dbContext.Songs.Update(editingSong);
                _dbContext.SaveChanges();
            }
            catch (Exception e)
            {
                return new SimpleResponse(e.InnerException.Message);
            }
            return new SimpleResponse(true);
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
            //var testSongsCAte = _dbContext.so


            var songsWithCategories = _dbContext.SongsToCategorieses.Include(x => x.Song).Include(x => x.Category).GroupBy(x => x.Song);
            var categories = _dbContext.Categories.Select(x => new CategoryEditModel { Category = x, HasChoosing = false}).ToList();
            List<SongsWithCategories> songsWithCategorieses = new List<SongsWithCategories>();
            try
            {
                foreach (var group in songsWithCategories)
                {
                    var obj = new SongsWithCategories(categories);
                    foreach (var item in group)
                    {
                        obj.Song = item.Song;
                        obj.SetChoosingCategory(item.Category);
                    }
                    songsWithCategorieses.Add(obj);
                }
            }
            catch (Exception e)
            {
                return new SimpleResponse( "no data");
            }
            return new SimpleResponse(songsWithCategorieses, "no data");
        }

        class SongsWithCategories
        {
            public Song Song { get; set; }
              
            public List<CategoryEditModel> Categories { get; set; }

            public SongsWithCategories(List<CategoryEditModel> categories)
            {
                Categories = new List<CategoryEditModel>();
                foreach (var categoryModel in categories)
                {
                    Categories.Add(new CategoryEditModel
                    {
                        Category = new Category{Id = categoryModel.Category.Id, Name = categoryModel.Category.Name},
                    });
                }
            }

            public void SetChoosingCategory(Category category)
            {
                foreach (var self in this.Categories)
                {
                    if (self.Category.Id == category.Id)
                    {
                        self.HasChoosing = true;
                    }
                }
            } 
        }

       
    }
}
