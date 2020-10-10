using CC.RolePermission.BLL;
using CC.RolePermission.IBLL;
using CC.RolePermission.UI.Portal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using XDZ.RolePermission.Common;

namespace CC.RolePermission.UI.Portal.Controllers
{
    public class UserLoginController : BaseController
    {
        public IUserInfoBll UserInfoBll { get; set; }
        public UserLoginController()
        {
            IsCheck = false;
        }

        // GET: UserLogin
        //[LoginCheckAttribute(IsCheck =false)]
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ShowCode()
        {
            ValidateCode validateCode = new ValidateCode();
            string strCode = validateCode.CreateValidateCode(4);
            Session["Vcode"] = strCode;
            byte[] imgBytes = validateCode.CreateValidateGraphic(strCode);
            return File(imgBytes, @"image/jpeg");
        }
        public ActionResult ProcessLogin()
        {
            string strCode = Request["vCode"];
            string sessionCode = Session["Vcode"] as string;
            Session["Vcode"] = null;
            if (string.IsNullOrEmpty(sessionCode))
            {
                return Content("验证码不能为空");
            }
            if (strCode != sessionCode)
            {
                return Content("验证码输入错误");
            }
            string name = Request["LoginCode"];
            string pwd = Request["LoginPwd"];
            short delNormal = (short)CC.RolePermission.Model.Enum.DelFlagEnum.Normal;
            var userInfo = UserInfoBll.GetEntities(u => u.UName == name && u.Pwd == pwd && u.DelFlag == delNormal).FirstOrDefault();
            if (userInfo == null)
            {
                return Content("用户名或者密码错误");
            }
            Session["loginUser"] = userInfo;
            return Content("ok");
        }
    }
}