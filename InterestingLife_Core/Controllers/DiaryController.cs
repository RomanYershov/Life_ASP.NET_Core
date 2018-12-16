using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InterestingLife_Core.Data;
using InterestingLife_Core.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace InterestingLife_Core.Controllers
{
    [Authorize]
    public class DiaryController : Controller
    {
        private ApplicationDbContext _applicationDb;

        public DiaryController(ApplicationDbContext context)
        {
            _applicationDb = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult GetTableByDate(string date)
        { 
            var userId =  _applicationDb.Users.FirstOrDefault(x => x.UserName == User.Identity.Name)?.Id;
            var tableStringValue = _applicationDb.Diaries.FirstOrDefault(x => x.DateTime == DateTime.Parse(date) 
                                                                              && x.UserId == userId);
            if (tableStringValue != null) return Json(tableStringValue);
            return Json("not data");
        }

        [HttpPost]
        public IActionResult Test(string str)
        {
            _applicationDb.Diaries.Add(new Diary
            {
                OneMonthStatistic = str
            });
            _applicationDb.SaveChanges();
            return Json("test is success!!!");
        }

        [HttpPost]
        public IActionResult Save(int id, string str, string date)
        {
            var dateTime = DateTime.Parse(date);
            var diary = _applicationDb.Diaries.FirstOrDefault(x => x.Id == id && x.DateTime == dateTime);
            if (diary == null)
            {
                var userId = _applicationDb.Users.FirstOrDefault(x => x.UserName == User.Identity.Name)?.Id;
                var newDiary = new Diary{OneMonthStatistic = str, DateTime = dateTime, UserId = userId };
                _applicationDb.Diaries.Add(newDiary);
                _applicationDb.SaveChanges();
                return Json(newDiary.Id);
            }
            else
            {
                diary.OneMonthStatistic = str;
                _applicationDb.Update(diary);
                _applicationDb.SaveChanges();
                return Json(diary.Id);
            }
           
        }
    }
}