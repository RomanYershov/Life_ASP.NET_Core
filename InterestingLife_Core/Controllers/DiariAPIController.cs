using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InterestingLife_Core.Abstractions;
using InterestingLife_Core.Data;
using InterestingLife_Core.Helpers;
using InterestingLife_Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace InterestingLife_Core.Controllers
{
    // [Route("api/[controller]")]
    [ApiController]
    public class DiariAPIController : ControllerBase
    {
        private readonly IDiaryService _service;

        public DiariAPIController(IDiaryService service) => _service = service;

        [HttpGet]
        [Route("api/diary/get/{date}")]
        public IActionResult GetTableByDate(string date)
        {
            //var hasher = new PasswordHasher<string>();
            //var res = hasher.HashPassword("1da049e2-60ce-4a4e-a11d-2deb9e31e910", "Roman_2662");
            var result = _service.GetTableByDate(date);
            if (result?.OneMonthStatistic != null)
            {
                return new JsonResult(new SimpleResponse(result));
            }
            return new JsonResult(new SimpleResponse("not data"));
        }
        [HttpPost]
        [Route("api/diary/save")]
        public IActionResult SaveData(Diary diary)
        {
            try
            {
                if (diary.Id == 0)
                {
                    _service.Create(diary);
                }
                else
                {
                    _service.Save(diary.Id, diary.OneMonthStatistic);
                }
            }
            catch (Exception e)
            {
                return new JsonResult(new SimpleResponse(e.Message));
            }
            return new JsonResult(new SimpleResponse(diary));
        }
    }
}