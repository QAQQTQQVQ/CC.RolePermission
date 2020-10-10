using CC.RolePermission.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CC.RolePermission.UI.Portal.Models
{
    public class MyExceptionFilterAttribute:HandleErrorAttribute
    {
        public override void OnException(ExceptionContext filterContext)
        {
            base.OnException(filterContext);
            LogHelper.WriteLog(filterContext.Exception.ToString());
        }
    }
}