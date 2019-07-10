using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using InterestingLife_Core.Abstractions;
using InterestingLife_Core.Data;
using InterestingLife_Core.Helpers;
using InterestingLife_Core.Models.Song;

namespace InterestingLife_Core.Services
{
    public class CategoryService : IService<Category,CategoryModel>
    {
        private ApplicationDbContext _dbContext;

        public CategoryService(ApplicationDbContext context)
        {
            _dbContext = context;
        }
        public SimpleResponse Create(CategoryModel model)
        {
            if (model != null)
            {
                if (_dbContext.Categories.Any(x => x.Name.Contains(model.Name)))
                    return new SimpleResponse($"Категория \"{model.Name}\" уже существует");
                try
                {
                    _dbContext.Categories.Add(new Category {Name = model.Name});
                    _dbContext.SaveChanges();
                }
                catch (Exception e)
                {
                   return new SimpleResponse(e.InnerException.Message);
                }
            }
            return new SimpleResponse();
        }

       

        public SimpleResponse Delete(int id)
        {
            throw new NotImplementedException();
        }

        public SimpleResponse Delete(Category category)
        {
            if (category != null)
            {
                try
                {
                    var songsToCategories = _dbContext.SongsToCategorieses.Where(x => x.Category.Id == category.Id);
                    _dbContext.SongsToCategorieses.RemoveRange(songsToCategories);


                    _dbContext.Remove(category);
                    _dbContext.SaveChanges();
                }
                catch (Exception e)
                {
                   return new SimpleResponse(e.InnerException.Message);
                }
            }
           return new SimpleResponse();
        }

        public SimpleResponse Update(CategoryModel model)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Category> Get()
        {
            return _dbContext.Categories;
        }

        public SimpleResponse Get(int id)
        {
            var category = _dbContext.Categories.Find(id);
            return new SimpleResponse(category);
        }
    }
}
