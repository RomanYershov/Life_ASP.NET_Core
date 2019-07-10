using System;
using System.Collections.Generic;
using System.Text;
using InterestingLife_Core.Models;
using InterestingLife_Core.Models.Song;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace InterestingLife_Core.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Diary> Diaries { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Song> Songs { get; set; }
        public DbSet<SongsToCategories> SongsToCategorieses { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //builder.Entity<User>()
            //    .HasOne(u => u.Role).WithOne();
            builder.Entity<User>().HasIndex(x => x.Login).IsUnique();
            builder.Entity<Role>().HasMany(x => x.Permissions).WithOne();
            builder.Entity<Diary>()
                .HasOne(x => x.User)
                .WithMany();
            builder.Entity<Song>()
                .HasMany(x => x.Categories).WithOne();
            builder.Entity<Category>().HasMany(x => x.Songs).WithOne();

            //builder.Entity<Permission>()
            //    .HasData(new Permission[]{new Permission{Description = "TEST",Name = "test"}, });
            //builder.Entity<Role>().HasData(new Role {Name = "Admin"});

        }

     

    }

 
    //public class LifeDbContext  : DbContext 
    //{
    //    public LifeDbContext(DbContextOptions<LifeDbContext> options) : base(options)
    //    {
    //    }
    //    public DbSet<Diary> Diaries { get; set; }
    //    public DbSet<Category> Categories { get; set; }
    //    public DbSet<Song> Songs { get; set; }
    //    public DbSet<SongsToCategories> SongsToCategorieses { get; set; }   
    //}
}
