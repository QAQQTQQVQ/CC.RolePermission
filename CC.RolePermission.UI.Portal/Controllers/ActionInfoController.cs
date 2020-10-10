using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CC.RolePermission.IBLL;

namespace CC.RolePermission.UI.Portal.Controllers
{
    public class ActionInfoController : Controller
    {
        public IActionInfoBll ActionInfoBll { get; set; }
        // GET: ActionInfo
        public ActionResult Index()
        {
            throw new Exception("抛出错误！");
            //ActionInfoBll.GetEntities(u => true).AsEnumerable();
            //return View();
        }
    }
}