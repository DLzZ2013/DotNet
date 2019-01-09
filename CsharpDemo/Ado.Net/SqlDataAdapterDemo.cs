using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Ado.Net
{
    class SqlDataAdapterDemo
    {
        public static void Test()
        {
            string conectionStr =
                "Data Source = 132.232.29.57,1433; INITIAL CATALOG = LogServer;user id = sa;password = Qqxd_7105693";
            var table = new DataTable();
            var sql = "select * from dbo.Log";
            using (var adapter = new SqlDataAdapter(sql, conectionStr))
            {
                adapter.Fill(table);
            }
            Console.WriteLine(table.TableName);

            for (int j = 0; j < table.Rows.Count; j++)
            {
                var dcl = table.Rows[j];

                for (int k = 0; k < table.Columns.Count; k++)
                {
                    Console.Write(dcl[k] + " | ");
                }

                Console.WriteLine();
            }

            Console.ReadKey();
        }
    }
}

