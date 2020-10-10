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
    public  partial  class StaticDalFactory
    {
        static string assembleyName = System.Configuration.ConfigurationManager.AppSettings["DalAssemblyName"];
    }
}
