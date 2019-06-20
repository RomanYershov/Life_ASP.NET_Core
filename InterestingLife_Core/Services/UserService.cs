using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Threading.Tasks;
using InterestingLife_Core.Abstractions;
using InterestingLife_Core.Data;
using InterestingLife_Core.Helpers;
using InterestingLife_Core.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace InterestingLife_Core.Services
{
    public class UserService : IService<User, ViewModelBase>
    {
        private readonly ApplicationDbContext _dbContext;


        public UserService(ApplicationDbContext context) => _dbContext = context;


        public SimpleResponse Create(ViewModelBase entity)
        {
            _dbContext.Users.Add(new IdentityUser { });
            throw new NotImplementedException();
        }

        public SimpleResponse Delete(int id)
        {
            throw new NotImplementedException();
        }

        public SimpleResponse Delete(string id)
        {
            try
            {
                var identityUser = _dbContext.Users.Find(id);
                _dbContext.Users.Remove(identityUser);
                _dbContext.SaveChanges();
            }
            catch (Exception e)
            {
                return new SimpleResponse(e.InnerException.Message);
            }
            return new SimpleResponse();
        }
        public SimpleResponse Delete(User entity)
        {
            try
            {
                var identityUser = _dbContext.Users.Find(entity.Id);
                _dbContext.Users.Remove(identityUser);
                _dbContext.SaveChanges();
            }
            catch (Exception e)
            {
               return new SimpleResponse(e.InnerException.Message);
            }
           return new SimpleResponse();
        }

        public SimpleResponse Update(ViewModelBase entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> Get()
        {
            return _dbContext.Users.Select(x => new User {Id = x.Id, Name = x.UserName, Email = x.Email, PaswordHash = x.PasswordHash});
        }

        public SimpleResponse Get(int id)
        {
            throw new NotImplementedException();
        }
    }
}
