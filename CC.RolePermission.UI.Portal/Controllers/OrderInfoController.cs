using CC.RolePermission.IBLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CC.RolePermission.UI.Portal.Controllers
{
    public class OrderInfoController : BaseController
    {
        public IOrderInfoBll OrderInfoBll { get; set; }
        // GET: OrderInfo
        public ActionResult Index()
        {
            ViewData.Model = OrderInfoBll.GetEntities(u => true).ToList();
            return View();
        }
    }
}