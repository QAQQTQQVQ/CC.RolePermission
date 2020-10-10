 

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CC.RolePermission.Model;

namespace CC.RolePermission.IBLL
{
	 
    public partial interface IActionInfoBll:IBaseBll<ActionInfo>
    {
    }
	 
    public partial interface IOrderInfoBll:IBaseBll<OrderInfo>
    {
    }
	 
    public partial interface IR_UserInfo_ActionInfoBll:IBaseBll<R_UserInfo_ActionInfo>
    {
    }
	 
    public partial interface IRoleInfoBll:IBaseBll<RoleInfo>
    {
    }
	 
    public partial interface IUserInfoBll:IBaseBll<UserInfo>
    {
    }
	 
    public partial interface IUserInfoExtBll:IBaseBll<UserInfoExt>
    {
    }
	
}