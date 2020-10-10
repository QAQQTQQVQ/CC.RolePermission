﻿ 

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CC.RolePermission.Model;
using CC.RolePermission.IDAL;
namespace CC.RolePermission.EFDAL
{

    public partial class ActionInfoDal : BaseDal<ActionInfo>, IActionInfoDal
    {

    }

    public partial class OrderInfoDal:BaseDal<OrderInfo>,IOrderInfoDal
    {
    }

    public partial class R_UserInfo_ActionInfoDal : BaseDal<R_UserInfo_ActionInfo>, IR_UserInfo_ActionInfoDal
    {

    }

    public partial class RoleInfoDal : BaseDal<RoleInfo>, IRoleInfoDal
    {

    }

    public partial class UserInfoDal:BaseDal<UserInfo>,IUserInfoDal
    {
    }

    public partial class UserInfoExtDal : BaseDal<UserInfoExt>, IUserInfoExtDal
    {
 
    }

}