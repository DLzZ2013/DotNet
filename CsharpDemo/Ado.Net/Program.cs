using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ado.Net
{
    class Program
    {
        static void Main(string[] args)
        {
            //DataSetDemo.Test();
            //SqlDataAdapterDemo.Test();
            Test();
        }

        public static void Test()
        {
            // 1、连接字符串
            string str = ConfigurationManager.ConnectionStrings["LogServer"].ConnectionString;           
            //2、创建连接对象(自动dispose(),SqlConnection中dispose调用了con.Close())
            using (var connection = new SqlConnection(str))
            {

                //4、编写sql
                //string sql = "insert into dbo.Log values('Demo','','','','','','')";
                string sql = "select * from dbo.Log where TransId = @transid";
                //5、执行sql
                using (var sqlCommand = new SqlCommand(sql, connection))
                {
                    //6、开始执行
                    //3、打开连接(最晚打开，最早关闭)
                    //三个方法都可以执行sql
                    //习惯为：
                    var param = new SqlParameter("@transid", SqlDbType.Int)
                    {
                        //带参数的Sql语句或调用存储过程 防止Sql注入攻击
                        Value = 1
                    };
                    sqlCommand.Parameters.Add(param);
                    connection.Open();
                    //int lines = sqlCommand.ExecuteNonQuery();//insert、update、delete返回行数，其他为-1

                    var rd = sqlCommand.ExecuteScalar();//select返回单个结果或值
                                               //select多行多列结果(只读、只进)
                    using (SqlDataReader reader = sqlCommand.ExecuteReader())
                    {
                        //DataReader必须独占一个连接对象
                        if (reader.HasRows)
                        {
                            //如果有数据就只能一条一条取，取完一条，在数据库内存的数据就会销毁
                            //向后移动一条数据,有数据返回true，否则为false
                            while (reader.Read())
                            {
                                //获取当前reader指向的数据
                                for (int i = 0; i < reader.FieldCount; i++)
                                {
                                    //Console.Write(reader[i]+" | ");
                                    Console.WriteLine(reader["TransId"]);
                                    //Console.WriteLine(reader.GetValue(i));
                                    //Console.WriteLine(reader.GetOrdinal("TransId"));
                                    //reader.GetXXX()//使用强类型读取列中数据
                                    //若数据库中读取的数据为null，返回C#DBNULL类型，ToString后为空字符串
                                    //System.DBNULL
                                }

                                Console.WriteLine();
                            }
                        }

                    }


                }

            }

            Console.WriteLine("关闭连接,释放资源.");
            Console.ReadKey();
        }
    }
}
