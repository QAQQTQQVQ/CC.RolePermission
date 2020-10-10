using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CC.RolePermission.IBLL;
using CC.RolePermission.BLL;
using CC.RolePermission.Model;

namespace CC.RolePermission.UI.Portal.Controllers
{
    public class UserInfoController : BaseController
    {
        //IUserInfoBll userInfoBll = new UserInfoBll();
        public IUserInfoBll UserInfoBll { get; set; }

        // GET: UserInfo
        public ActionResult Index()
        {
            ViewData.Model = UserInfoBll.GetEntities(u => true);
            return View();
        }
        public ActionResult Create()
        {
            return View();
        }
        public ActionResult Add(UserInfo userInfo)
        {
            userInfo.UName = Request["UName"];
            userInfo.ModifyOn = DateTime.Now;
            userInfo.SubTime = DateTime.Now;
            userInfo.DelFlag = (short)CC.RolePermission.Model.Enum.DelFlagEnum.Normal;
            UserInfoBll.Add(userInfo);
            return Content("ok");
        }
        [HttpPost]
        public ActionResult Create(UserInfo userInfo)
        {
            if (ModelState.IsValid == true)
            {
                UserInfoBll.Add(userInfo);
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult Delete(string ids)
        {
            if (string.IsNullOrEmpty(ids))
            {
                return Content("请选中要删除的数据");
            }
            string[] strIds = ids.Split(',');
            List<int> idList = new List<int>();
            foreach (var strId in strIds)
            {
                idList.Add(int.Parse(strId));
            }
            //UserInfoBll.DeleteList(idList);
            UserInfoBll.DeleteListByLogical(idList);
            return Content("ok");
        }
        //public ActionResult Delete(int id)
        //{
        //    ViewData.Model = UserInfoBll.GetEntities(u => u.Id == id).FirstOrDefault();
        //    return View();
        //}

        //public ActionResult Delete(UserInfo userInfo)
        //{
        //    UserInfoBll.Delete(userInfo);
        //    return RedirectToAction("Index");
        //}
        //public ActionResult Edit(int id)
        //{
        //    ViewData.Model = UserInfoBll.GetEntities(u => u.Id == id).FirstOrDefault();
        //    return View("Update");
        //}
        //[HttpPost]
        //public ActionResult Edit(UserInfo userInfo)
        //{
        //    UserInfoBll.Update(userInfo);
        //    return RedirectToAction("Index");
        //}
        public ActionResult Details(int id)
        {
            ViewData.Model = UserInfoBll.GetEntities(u => u.Id == id).FirstOrDefault();
            return View();
        }
        public ActionResult GetAllUserInfos()
        {
            int PageSize = int.Parse(Request["row"] ?? "10");
            int PageIndex = int.Parse(Request["page"] ?? "10");
            int total = 0;
            short delFlagNormal = (short)CC.RolePermission.Model.Enum.DelFlagEnum.Normal;
            var pageData = UserInfoBll.GetPageEntities(PageSize, PageIndex, out total, u => u.DelFlag == delFlagNormal, u => u.Id, true).Select(u => new { ID = u.Id, u.ModifyOn, u.Pwd, u.Remark, u.ShowName, u.SubTime, u.UName });
            var data = new { total = total, rows = pageData.ToList() };
            return Json(data, JsonRequestBehavior.AllowGet);

        }
        public ActionResult Edit(int id)
        {
            return View();
        }
        [HttpPost]
        public ActionResult Edit(UserInfo userInfo)
        {
            UserInfoBll.Update(userInfo);
            return Content("ok");
        }
    }
}