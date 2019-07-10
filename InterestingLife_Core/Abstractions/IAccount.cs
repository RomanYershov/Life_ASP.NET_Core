using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InterestingLife_Core.Helpers;
using InterestingLife_Core.Models;

namespace InterestingLife_Core.Abstractions
{
    public interface IAccount
    {
        bool IsAuthorized(AccountModel accountModel);
        AccountInfoModel GetAccountInfo(AccountModel accountModel);
        AccountModel Registration(AccountModel accountModel);
        SimpleResponse CreateRole(Role roleModel);
        SimpleResponse GetRoles();
        SimpleResponse CreatePermission(Permission newPermission);
        SimpleResponse GetPermissions();

    }
}
