using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InterestingLife_Core.Abstractions;
using InterestingLife_Core.Data;
using InterestingLife_Core.Helpers;
using InterestingLife_Core.Models.Song;

namespace InterestingLife_Core.Services
{
    public class CategoryService : IService<Category,CreateCategoryModel>
    {
        private LifeDbContext _dbContext;

        public CategoryService(LifeDbContext context)
        {
            _dbContext = context;
        }
        public SimpleResponse Create(CreateCategoryModel song)
        {
            throw new NotImplementedException();
        }

       

        public SimpleResponse Delete(int id)
        {
            throw new NotImplementedException();
        }

        public SimpleResponse Update(int id, Category category)
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
