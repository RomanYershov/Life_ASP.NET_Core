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

        public Diary GetTableByDate(string date, string userId)
        {
            var table = _dbContext.Diaries.FirstOrDefault(x => x.DateTime == DateTime.Parse(date ?? $"{DateTime.Now.Year}-{DateTime.Now.Month}") && x.UserId == userId);
            return table;
        }

        public void Save(int id, string str)
        {
            var diary = _dbContext.Diaries.Find(id);
            diary.OneMonthStatistic = str;
            _dbContext.Update(diary);
            _dbContext.SaveChanges();
        }

        public int Save(int id, string str, string date, string userId)
        {
            var dateTime = DateTime.Parse(date);
            var diary = _dbContext.Diaries.FirstOrDefault(x => x.Id == id && x.DateTime == dateTime);
            if (diary == null)
            {
               
                var newDiary = new Diary { OneMonthStatistic = str, DateTime = dateTime, UserId = userId };
                _dbContext.Diaries.Add(newDiary);
                _dbContext.SaveChanges();
                return newDiary.Id;
            }
            else
            {
                if (!diary.OneMonthStatistic.Contains(str))
                {
                    diary.OneMonthStatistic = str;
                    _dbContext.Update(diary);
                    _dbContext.SaveChanges();
                }
                return diary.Id;
            }
        }


        public void Create(Diary diary)
        {
            _dbContext.Add(diary);
            _dbContext.SaveChanges();
        }
    }
}
