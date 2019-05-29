using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InterestingLife_Core.Abstractions;
using InterestingLife_Core.Data;
using InterestingLife_Core.Helpers;
using InterestingLife_Core.Models.Song;
using InterestingLife_Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace InterestingLife_Core.Controllers
{
    public class AdminController : Controller
    {
        private readonly IService<Song, CreateSongModel> _songService;
        private readonly IService<Category, CreateCategoryModel> _categoryService;

        public AdminController(IService<Song, CreateSongModel> songService, IService<Category, CreateCategoryModel> categoryService)
        {
            _songService = songService;
            _categoryService = categoryService;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AddSong()
        {
            var result = _categoryService.Get();
            return View(new AddSongViewModel(){Categories = result.ToList()});
        }

        public SimpleResponse CreateSong(CreateSongModel model)
        {
           var result = _songService.Create(model);
            return result;
        }
    }
}