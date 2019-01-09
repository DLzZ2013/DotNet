using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 文件流
{
    public class StreamWriter和StreamReader
    {
        public static string Read()
        {
            using (var sr = new StreamReader(@"E:\myFlie\C#\CsharpDemo\启动测试\Properties\res\player.txt", Encoding.Default))
            {
                //StreamReader按行读取文件
                //直到文本末尾
                string sbr = "";
                string line = null;
                while ((line = sr.ReadLine()) != null)
                {
                    sbr += line;
                }
                return sbr;
            }
        }

        public static string Writer()
        {
            using (var sw = new StreamWriter(@"E:\myFlie\C#\CsharpDemo\启动测试\Properties\res\player.txt",true,Encoding.Default))
            {
                var str = "LbjDWkbK詹姆斯";
                sw.WriteLine(str);
                return "ok";
            }

        }
    }
}
