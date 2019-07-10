using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InterestingLife_Core.Abstractions;
using InterestingLife_Core.Models;

namespace InterestingLife_Core.Data
{
    public class DbInitialize
    {
        private readonly IAccount _account;
        public DbInitialize(IAccount account) => _account = account;
        public void InitializeAsync()
        {
            List<Permission> permissionsForAdminRole = new List<Permission>();
            var permission1 = _account.CreatePermission(new Permission { Description = "CRUD песен, комментариев", Name = "EditSongCategory" });
            var permission2 = _account.CreatePermission(new Permission { Description = "CRUD пользователей", Name = "EditUsers" });
            permissionsForAdminRole.Add(permission1.Data as Permission);
            permissionsForAdminRole.Add(permission2.Data as Permission);

           var admin =  _account.CreateRole(new Role { Name = "Admin", Permissions = permissionsForAdminRole });
            List<Role> rolesForAdmin = new List<Role>();
            rolesForAdmin.Add(admin.Data as Role);

            //_account.Registration(new AccountModel
            //{
            //    Login = "Admin",
            //    Role = rolesForAdmin,
            //    Password = "asdfASDF!@12",
            //});
        }
    }
}
