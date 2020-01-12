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
    public class DiaryService : IDiaryService
    {
        private readonly ApplicationDbContext _dbContext;

        public DiaryService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Diary GetTableByDate(string date)
        {
            var table = _dbContext.Diaries.FirstOrDefault(x => x.DateTime == DateTime.Parse(date ?? $"{DateTime.Now.Year}-{DateTime.Now.Month}"));
            return table;
        }

        public void Save(int id, string str)
        {
            var diary = _dbContext.Diaries.Find(id);
            diary.OneMonthStatistic = str;
            _dbContext.Update(diary);
            _dbContext.SaveChanges();
        }

        public void Create(Diary diary)
        {
            _dbContext.Add(diary);
            _dbContext.SaveChanges();
        }
    }
}
