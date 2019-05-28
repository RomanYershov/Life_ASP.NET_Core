using System;
using System.Collections.Generic;
using System.Text;
using InterestingLife_Core.Models;
using InterestingLife_Core.Models.Song;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace InterestingLife_Core.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Diary> Diaries { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Song> Songs { get; set; }  
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}
