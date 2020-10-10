using CC.RolePermission.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CC.RolePermission.UI.Portal.Controllers
{
    public class BaseController : Controller
    {
        public UserInfo LoginUser { get; set; }
        public bool IsCheck = true;
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (IsCheck)
            {
                if (filterContext.HttpContext.Session["loginUser"] == null)
                {
                    filterContext.HttpContext.Response.Redirect("/UserLogin/Index");
                }
                else
                {
                    LoginUser = filterContext.HttpContext.Session["loginUser"] as UserInfo;
                }
            }
        }

    }
}