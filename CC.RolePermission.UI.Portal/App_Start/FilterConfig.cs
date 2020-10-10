using System.Web;
using System.Web.Mvc;
using CC.RolePermission.UI.Portal.Models;

namespace CC.RolePermission.UI.Portal
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            //filters.Add(new HandleErrorAttribute());
            filters.Add(new MyExceptionFilterAttribute());
            //filters.Add(new LoginCheckAttribute() { IsCheck = true }) ;
        }
    }
}
