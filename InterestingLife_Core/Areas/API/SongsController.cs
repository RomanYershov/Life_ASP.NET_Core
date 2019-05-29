using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InterestingLife_Core.Data;
using InterestingLife_Core.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InterestingLife_Core.Areas.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class SongsController : ControllerBase
    {
        private LifeDbContext _applicationDb;

        public SongsController(LifeDbContext context)
        {
            _applicationDb = context;
        }
        [HttpGet]
        [Route("/api/songs/categories")]
        public SimpleResponse Categories()
        {
            var categories = _applicationDb.Categories;
            if (categories == null)
            {
                return new SimpleResponse("Не найдено ни одной категории");
            }
            return new SimpleResponse(categories);
        }
        [HttpGet]
        [Route("/api/songs/getSongsByCategory/{id}")]
        public SimpleResponse Categories(int id)
        {
            var songs = _applicationDb.Categories.Include(x => x.Songs).SingleOrDefault(x => x.Id == id)?.Songs;
            return songs != null && songs.Count == 0 ? new SimpleResponse("Нет песен по выбранной категории") : new SimpleResponse(songs);
        }
        [HttpGet]
        [Route("/api/songs/getSongs")]
        public SimpleResponse Songs()
        {
            return new SimpleResponse(_applicationDb.Songs);
        }
        [HttpGet]
        [Route("/api/songs/getSongById/{id}")]
        public SimpleResponse Songs(int id)
        {
            var song = _applicationDb.Songs.SingleOrDefault(x => x.Id == id);
            return new SimpleResponse(song);
        }
        
    }
}