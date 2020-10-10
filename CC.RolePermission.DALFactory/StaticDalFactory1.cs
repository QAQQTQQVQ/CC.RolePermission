 

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using CC.RolePermission.EFDAL;
using CC.RolePermission.IDAL;

namespace CC.RolePermission.DALFactory
{
    public partial class StaticDalFactory
    {
	 

  public static IActionInfoDal GetActionInfoDal()
        {
            return Assembly.Load(assembleyName).CreateInstance(assembleyName + ".ActionInfoDal") as IActionInfoDal;
        }
	 

  public static IOrderInfoDal GetOrderInfoDal()
        {
            return Assembly.Load(assembleyName).CreateInstance(assembleyName + ".OrderInfoDal") as IOrderInfoDal;
        }
	 

  public static IR_UserInfo_ActionInfoDal GetR_UserInfo_ActionInfoDal()
        {
            return Assembly.Load(assembleyName).CreateInstance(assembleyName + ".R_UserInfo_ActionInfoDal") as IR_UserInfo_ActionInfoDal;
        }
	 

  public static IRoleInfoDal GetRoleInfoDal()
        {
            return Assembly.Load(assembleyName).CreateInstance(assembleyName + ".RoleInfoDal") as IRoleInfoDal;
        }
	 

  public static IUserInfoDal GetUserInfoDal()
        {
            return Assembly.Load(assembleyName).CreateInstance(assembleyName + ".UserInfoDal") as IUserInfoDal;
        }
	 

  public static IUserInfoExtDal GetUserInfoExtDal()
        {
            return Assembly.Load(assembleyName).CreateInstance(assembleyName + ".UserInfoExtDal") as IUserInfoExtDal;
        }
	}
}