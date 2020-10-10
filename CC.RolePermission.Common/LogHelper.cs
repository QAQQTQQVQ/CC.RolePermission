using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CC.RolePermission.Common
{
    public class LogHelper
    {
        public static List<ILogWrite> LogWriteList = new List<ILogWrite>();
        public delegate void WriteLogDel(string str);
        public static WriteLogDel WriteLogDelFunc;
        public static Queue<string> ExceptionStringQueue = new Queue<string>();
        public static void WriteLog(string exceptionText)
        {
            lock (ExceptionStringQueue)
            {
                ExceptionStringQueue.Enqueue(exceptionText);
            }
        }

        public static void WriteToFile(string txt)
        {

        }
        public static void WriteToMongoDB(string txt)
        {

        }
        static LogHelper()
        {
            LogWriteList.Add(new Log4NetWriter());
            ThreadPool.QueueUserWorkItem(O =>
                    {
                        while (true)
                        {
                            if (ExceptionStringQueue.Count > 0)
                            {

                                lock (ExceptionStringQueue)
                                {
                                    string str = ExceptionStringQueue.Dequeue();
                                    foreach (var logWriter in LogWriteList)
                                    {
                                        logWriter.WriteLonInfo(str);
                                    }

                                };
                            }
                            else
                            {
                                Thread.Sleep(30);
                            }
                        }
                    });

        }
    }
}

