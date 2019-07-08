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
        //public DbSet<User> Users { get; set; }
        //public DbSet<Role> Roles { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }

    public interface IDbContext
    {
         DbContext Context { get; set; }
    }
    public class LifeDbContext  : DbContext 
    {
        public LifeDbContext(DbContextOptions<LifeDbContext> options) : base(options)
        {
        }
        public DbSet<Diary> Diaries { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Song> Songs { get; set; }
        public DbSet<SongsToCategories> SongsToCategorieses { get; set; }   
    }
}
