using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ado.Net
{
    class EFDemo
    {
        public static void Test()
        {
            using (var db = new LogServerEntities())
            {
                var dbData = db.Log.Add(new Net.Log()
                {
                    ExDetail = "",
                    ExpType = "",
                    Host = "",
                    LogLevel = "",
                    LogTime = DateTime.Now.ToString(),
                    Message = "",
                    MethodName = "",
                });
            }
        }
    }
}
