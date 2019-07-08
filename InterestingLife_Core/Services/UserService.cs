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
    public class UserService : IService<User, UserModel>
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly UserManager<IdentityUser> _userManager;


        public UserService(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _dbContext = context;
            _userManager = userManager;
        }


        public SimpleResponse Create(UserModel model)
        {
            User user = null;
            if (model != null)
            {
                try
                {
                     user = new User
                    {
                        UserName = model.Name,
                        Email = model.Email
                    };
                    user.PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(user, model.Password);
                    //_userManager.CreateAsync(user);
                    
                    var rrr = new IdentityRole();
                   

                    //_dbContext.Roles.AddRange(user.Roles);

                    _dbContext.Users.Add(user);
                    _dbContext.SaveChanges();
                }
                catch (Exception e)
                {
                    return new SimpleResponse(e.Message + "\n" + e.StackTrace);
                }
            }
          
            return new SimpleResponse(new
            {
                UserName = user.UserName,
                Email = user.Email,
            });
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

        public SimpleResponse Update(UserModel entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> Get()
        {
            return _dbContext.Users.Select(x => new User { Id = x.Id, UserName = x.UserName, Email = x.Email, PasswordHash = x.PasswordHash });
        }

        public SimpleResponse Get(int id)
        {
            throw new NotImplementedException();
        }
    }
}
