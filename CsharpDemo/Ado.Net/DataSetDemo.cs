using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ado.Net
{
    class DataSetDemo
    {
        public static void Test()
        {
            //创建内存数据库，临时数据库
            DataSet ds = new DataSet("swpu");
            //创建表
            DataTable dt = new DataTable("software engineering");
            //创建列
            DataColumn dc = new DataColumn("class", typeof(int));
            //设置自动编号
            dc.AutoIncrement = true;
            dc.AutoIncrementSeed = 0;//初始增长
            dc.AutoIncrementStep = 1;//增长步长

            dt.Columns.Add(dc);
            dt.Columns.Add("num", typeof(int));

         
            //创建行(根据表结构)
            DataRow dr = dt.NewRow();
            dr["num"] = 40;

            dt.Rows.Add(dr);
            ds.Tables.Add(dt);

            for (int i = 0; i < ds.Tables.Count; i++)
            {
                Console.WriteLine(ds.Tables[i].TableName);
              
                for (int j = 0; j < ds.Tables[i].Rows.Count; j++)
                {
                    var dcl = ds.Tables[i].Rows[j];

                    for (int k = 0; k < ds.Tables[i].Columns.Count; k++)
                    {
                        Console.WriteLine(dcl[k]);
                    }
                }
            }

            Console.ReadKey();
        }
    }
}
