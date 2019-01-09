using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace 文件流
{
    public class 文件加密
    {
        public static void FileEncrypt(string source,string target)
        {
            //解密和加密可重用
            using (var fRead = new FileStream(source, FileMode.OpenOrCreate, FileAccess.Read))
            {
                using (var fWriter = new FileStream(target, FileMode.OpenOrCreate, FileAccess.Write))
                {
                    var bytes = new byte[1024 * 1024];
                    int num ;
                    while ((num = fRead.Read(bytes, 0, bytes.Length)) > 0)
                    {                       
                        Thread.Sleep(100);                       
                        for (int i = 0; i < num; i++)
                        {
                            bytes[i] = (byte) (byte.MaxValue - bytes[i]);
                        }
                        fWriter.Write(bytes, 0, num);
                        Console.WriteLine(fWriter.Position * 100 / (double)fRead.Length + "%");
                    }
                }
            }
        }
    }
}
