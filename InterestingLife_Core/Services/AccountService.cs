using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InterestingLife_Core.Abstractions;
using InterestingLife_Core.Data;
using InterestingLife_Core.Helpers;
using InterestingLife_Core.Models;

namespace InterestingLife_Core.Services
{
    public class AccountService : IAccount
    {
        private readonly ApplicationDbContext _dbContext;

        public AccountService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public bool IsAuthorized(AccountModel accountModel)
        {
            var user = _dbContext.Users.FirstOrDefault(x => x.Login == accountModel.Login);
            if (user == null) return false;
            var salt = user.Salt;
            var hash = HashingMethods.GenerateSha256Hash(accountModel.Password, salt);
            var result = hash == user.PasswordHash;
            return result;
        }

        public AccountInfoModel GetAccountInfo(AccountModel accountModel)
        {
            var user = _dbContext.Users.SingleOrDefault(x => x.Login == accountModel.Login);
            if (user == null) return null;
            return new AccountInfoModel
            {
                Id = user.Id,
                Role = user.Role.Name
            };
        }

        public AccountModel Registration(AccountModel accountModel)
        {
            var salt = HashingMethods.CreateSalt();
            var hash = HashingMethods.GenerateSha256Hash(accountModel.Password, salt);
            User newUser = new User
            {
                Login = accountModel.Login,
                Email = accountModel.Email,
                PasswordHash = hash,
                Salt = salt,
                Role = accountModel.Role,
                ReferalLink = "testReferalLink_123345"
            };
            _dbContext.Users.Add(newUser);
            _dbContext.SaveChanges();
           return  accountModel;
        }

        public SimpleResponse CreateRole(Role roleModel)
        {
            try
            {
                _dbContext.Roles.Add(roleModel);
                _dbContext.SaveChanges();
            }
            catch (Exception e)
            {
               return new SimpleResponse( e.InnerException.Message + "\n" + e.InnerException.StackTrace);
            }
            return new SimpleResponse(roleModel);
        }

        public SimpleResponse GetRoles()
        {
            throw new NotImplementedException();
        }

        public SimpleResponse CreatePermission(Permission newPermission)
        {
            try
            {
                _dbContext.Permissions.Add(newPermission);
            }
            catch (Exception e)
            {
                return new SimpleResponse(e.InnerException.Message + "\n" + e.InnerException.StackTrace);
            }
            return new SimpleResponse(newPermission);
        }

        public SimpleResponse GetPermissions()
        {
            throw new NotImplementedException();
        }
    }
}
