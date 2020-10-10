using CC.RolePermission.IDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CC.RolePermission.DALFactory;
using CC.RolePermission.EFDAL;

namespace CC.RolePermission.DALFactory
{
    public partial class DbSession:IDbSession
    {
        public int SaveChanges()
        {
            return DbContentFactory.GetCurrentDbContent().SaveChanges();
        }
    }
}
