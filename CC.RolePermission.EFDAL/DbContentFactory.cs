using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using CC.RolePermission.Model;

namespace CC.RolePermission.EFDAL
{
    public class DbContentFactory
    {
        public static DbContext GetCurrentDbContent()
        {
            DbContext db= CallContext.GetData("DbContext") as DbContext;//从线程池查找
            if (db == null)
            {
                db = new DataModelContainer();
                CallContext.SetData("DbContext", db);
            }
            return db;
        }
    }
}
