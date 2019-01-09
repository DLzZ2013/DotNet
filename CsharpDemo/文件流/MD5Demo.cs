using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace 文件流
{
    class MD5Demo
    {
        public static void Test()
        {           
            using (var md5 = MD5.Create())
            {
                using (var s = new StreamReader("C:\\Users\\shuiwei\\Pictures\\Dlzpic\\thread_11551674775020_20181015140544_s_2080715_w_280_h_160_9955.gif",Encoding.UTF8)) 
                {
                    var sbr = new StringBuilder();
                    while (string.IsNullOrEmpty(s.ReadLine()))
                    {
                        sbr.Append(s.ReadLine());
                    }

                    var bytes = Encoding.Default.GetBytes(sbr.ToString());
                    var bs = md5.ComputeHash(bytes);
                    sbr.Clear();
                    for (int i = 0; i < bs.Length; i++)
                    {
                        sbr.Append(bs[i].ToString("x2"));
                    }
                    Console.WriteLine(sbr.ToString());
                    Console.ReadKey();
                }
                
            }
        }
        public static void Test1()
        {
            using (var md5 = MD5.Create())
            {
                using (var s = File.Open("C:\\Users\\shuiwei\\Pictures\\Dlzpic\\thread_11551674775020_20181015140544_s_2080715_w_280_h_160_9955.gif", FileMode.OpenOrCreate,FileAccess.Read))
                {
                    var sbr = new StringBuilder();
                                       
                    var bs = md5.ComputeHash(s);
                    sbr.Clear();
                    for (int i = 0; i < bs.Length; i++)
                    {
                        sbr.Append(bs[i].ToString("x2"));
                    }
                    Console.WriteLine(sbr.ToString());
                    Console.ReadKey();
                }

            }
        }
    }
}
