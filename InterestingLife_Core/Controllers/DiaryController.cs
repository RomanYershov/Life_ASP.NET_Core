using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Threading.Tasks;
using InterestingLife_Core.Abstractions;
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
        private IDiaryService _diaryService;
        public DiaryController(IDiaryService diaryService, ApplicationDbContext contex)
        {
            _diaryService = diaryService;
            _applicationDb = contex;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult GetTableByDate(string date)
        {
            var userId = _applicationDb.Users.FirstOrDefault(x => x.UserName == User.Identity.Name)?.Id;
            var diary = _diaryService.GetTableByDate(date, userId);
            if (diary?.OneMonthStatistic != null) return Json(diary);
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
            var userId = _applicationDb.Users.FirstOrDefault(x => x.UserName == User.Identity.Name)?.Id;
            var diaryId = _diaryService.Save(id, str, date, userId);
            return Json(diaryId);


        }
    }
}