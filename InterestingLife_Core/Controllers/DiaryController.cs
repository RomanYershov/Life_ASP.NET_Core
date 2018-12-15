using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InterestingLife_Core.Data;
using InterestingLife_Core.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace InterestingLife_Core.Controllers
{
    public class DiaryController : Controller
    {
        //private LifeDbContext _dbContext;
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
            var tableStringValue = _applicationDb.Diaries.FirstOrDefault(x => x.DateTime == DateTime.Parse(date));
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
    }
}