using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InterestingLife_Core.Abstractions;
using InterestingLife_Core.Data;
using InterestingLife_Core.Helpers;
using InterestingLife_Core.Models.Song;
using InterestingLife_Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InterestingLife_Core.Areas.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class SongsController : ControllerBase
    {
        private IService<Category, CategoryModel> _categoryService;
        private IService<Song, SongModel> _songService;
         

        public SongsController(IService<Category, CategoryModel> categoryService, IService<Song, SongModel> songService)
        {
            _categoryService = categoryService;
            _songService = songService;
        }
        [HttpGet]
        [Route("/api/songs/categories")]
        public SimpleResponse Categories()
        {
            var categories = _categoryService.Get();
            return new SimpleResponse(categories);
        }
        [HttpGet]
        [Route("/api/songs/getSongsByCategory/{id}")]
        public SimpleResponse GetSongsByCategory(int id)
        {
            var songs = ((ISongService) _songService).GetSongsByCategoryId(id);
            return new SimpleResponse(songs); //songs != null && !songs.Any() ? new SimpleResponse("Нет песен по выбранной категории") : new SimpleResponse(songs);
        }
        [HttpGet]
        [Route("/api/songs/getSongs")]
        public SimpleResponse Songs()
        {
            return new SimpleResponse(_songService.Get());
        }
        [HttpGet]
        [Route("/api/songs/getSongById/{id}")]
        public SimpleResponse Songs(int id)
        {
            return _songService.Get(id);
        }
        
    }
}