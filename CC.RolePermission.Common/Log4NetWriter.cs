using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CC.RolePermission.Common
{
    public class Log4NetWriter : ILogWrite
    {
        public void WriteLonInfo(string txt)
        {
            ILog logWriter = log4net.LogManager.GetLogger("cc");
            logWriter.Error(txt);
        }
    }
}
