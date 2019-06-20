using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InterestingLife_Core.Abstractions;
using InterestingLife_Core.Data;
using InterestingLife_Core.Helpers;
using InterestingLife_Core.Models;

namespace InterestingLife_Core.Services
{
    public class DiaryService : IService<Diary, ViewModelBase>
    {
        private readonly ApplicationDbContext _dbContext;

        public DiaryService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public SimpleResponse Create(ViewModelBase entity)
        {
            throw new NotImplementedException();
        }

        public SimpleResponse Delete(int id)
        {
            throw new NotImplementedException();
        }

        public SimpleResponse Delete(Diary entity)
        {
            throw new NotImplementedException();
        }

        public SimpleResponse Update(ViewModelBase entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Diary> Get()
        {
            throw new NotImplementedException();
        }

        public SimpleResponse Get(int id)
        {
            throw new NotImplementedException();
        }
    }
}
