using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bm2s.Poco.Common.User;
using static Bm2sWinBO.Utils.Utils;

namespace Bm2sWinBO.Utils
{
  public static class AuthorizationUtils
  {
    private static Dictionary<int, List<Module>> _modulesAuthorizations;

    public static bool HaveAuthorization(Authorizations authorization, Modules module)
    {
      return AuthorizationUtils.HaveAuthorization(UserUtils.CurrentUser, authorization, module);
    }

    public static bool HaveAuthorization(int userId, Authorizations authorization, Modules module)
    {
      Bm2s.Connectivity.Common.User.User user = new Bm2s.Connectivity.Common.User.User();
      user.Request.Ids.Add(userId);
      user.Get();
      return AuthorizationUtils.HaveAuthorization(user.Response.Users.FirstOrDefault(), authorization, module);
    }

    public static bool HaveAuthorization(User user, Authorizations authorization, Modules module)
    {
      return user != null && (user.IsAdministrator || AuthorizationUtils.ModulesAuthorization(user.Id).Any(item => item.Code.ToLower() == (authorization.ToString() + module.ToString()).ToLower()));
    }

    public static List<Module> ModulesAuthorization()
    {
      return ModulesAuthorization(UserUtils.CurrentUser.Id);
    }

    public static List<Module> ModulesAuthorization(int userId)
    {
      if(_modulesAuthorizations == null)
      {
        _modulesAuthorizations = new Dictionary<int, List<Module>>();
      }

      List<Module> modulesAuthorization = _modulesAuthorizations.FirstOrDefault(item => item.Key == userId).Value;
      if (modulesAuthorization == null)
      {
        modulesAuthorization = new List<Module>();
        Bm2s.Connectivity.Common.User.UserGroup userGroup = new Bm2s.Connectivity.Common.User.UserGroup();
        userGroup.Request.UserId = userId;
        userGroup.Get();

        Bm2s.Connectivity.Common.User.GroupModule groupModule = new Bm2s.Connectivity.Common.User.GroupModule();
        foreach (UserGroup itemUserGroup in userGroup.Response.UserGroups)
        {
          groupModule.Request.GroupId = itemUserGroup.Id;
          groupModule.Get();
          foreach (GroupModule itemGroupModule in groupModule.Response.GroupModules.Where(itemModule => itemModule.Granted))
          {
            modulesAuthorization.Add(itemGroupModule.Module);
          }
        }

        Bm2s.Connectivity.Common.User.UserModule userModule = new Bm2s.Connectivity.Common.User.UserModule();
        userModule.Request.UserId = userId;
        userModule.Get();

        foreach (UserModule itemUserModule in userModule.Response.UserModules.Where(itemModule => !itemModule.Granted))
        {
          modulesAuthorization.Remove(itemUserModule.Module);
        }

        foreach (UserModule itemUserModule in userModule.Response.UserModules.Where(itemModule => itemModule.Granted))
        {
          modulesAuthorization.Add(itemUserModule.Module);
        }

        _modulesAuthorizations.Add(userId, modulesAuthorization);
      }

      return modulesAuthorization;
    }
  }

  public enum Authorizations
  {
    Create,
    Delete,
    Edit,
    View,
  }
}
