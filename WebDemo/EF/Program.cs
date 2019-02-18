using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.SqlServer;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new LogServerEntities())
            {
                db.Database.Log = Console.WriteLine;
                var list  = new List<long >()
                {
                    1,2,3,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2
                };
                IQueryable<Log> log = db.Log.Where(p => list.Contains(p.TransId));
                var items = log.Where(c => c.TransId == 1);
                Console.WriteLine(items.ToList());
                var date = db.Log.Where(c => SqlFunctions.DateDiff("hour",c.CreateTime,DateTime.Now)>1);
                Console.WriteLine(date);
                //ExecuteNonQuery
                //db.Database.ExecuteSqlCommand()
                //db.Database.SqlQuery<>()


            }

            Console.ReadKey();
        }
    }
}
