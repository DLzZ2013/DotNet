using System;
using System.IO;
using System.Text;
using System.Threading;

namespace 文件流
{
    class Program
    {
        static void Main(string[] args)
        {
            
            MD5Demo.Test();
        }

        public static void Test()
        {
            string sPath = @"C:\Users\Chens-PC\Desktop\Nginx.txt";
            //File类的ReadAllBytes()方法会将文本内容一次性读取到内存中，然后以byte数组返回（同时关闭文件）。
            byte[] bteData = File.ReadAllBytes(sPath);
            //File类的ReadAllLines()方法会将文本内容一次性逐行读取到内存中，然后以string数组返回（同时关闭文件），它的重载能指定读取时使用的编码。
            string[] strData = File.ReadAllLines(sPath);
            //File类的ReadAllText()方法会将文本内容一次性读取到内存中，然后以string字符串返回（同时关闭文件），它的重载能指定读取时使用的编码。
            string sData = File.ReadAllText(sPath);
            string str = "Lebron James 詹姆斯";
            var bytes = Encoding.UTF8.GetBytes(str);
            str = Encoding.UTF8.GetString(bytes);
            //Console.WriteLine(str);

            //流操作都是字节，不能直接操作字符串
            //1、创建文件流
            FileStream fsWriter = new FileStream("players.txt", FileMode.OpenOrCreate, FileAccess.Write);
            //2、执行读写操作
            string msg = "韦德 DW0000000000000000000";
            var dw = Encoding.UTF8.GetBytes(msg);
            //参数：1、字节数组 2、字节偏移量 3、字节数
            fsWriter.Write(dw, 0, dw.Length);
            //3、清空缓冲区、关闭文件流、释放资源
            fsWriter.Flush();//默认内存中有java的BufferOutputStream缓冲区需要flush()：冲刷、排挤、清除
            fsWriter.Close();//关闭文件流、释放内存资源
            fsWriter.Dispose();//释放windows os资源
            //用using时用的是try finally可以重写以上释放资源方法，实现IDisposable接口自动调用Dispose()

            using (var fsRead = new FileStream("player.txt", FileMode.OpenOrCreate, FileAccess.Read))
            {

                var bs = new byte[fsRead.Length];//适用于小文件          
                int n = fsRead.Read(bs, 0, bs.Length);
                var m = Encoding.UTF8.GetString(bs);

                Console.WriteLine(m);
            }

            var stream = File.Open("players.txt", FileMode.OpenOrCreate);
            stream = File.OpenRead("players.txt");
            stream = File.OpenWrite("players.txt");
            //文件加密.FileEncrypt(@"E:\BaiduNetdiskDownload\1.DotNet基础加强-video\08Net基础加强第八天-文件流 序列化\视频\9.大文件拷贝.avi",@"E:\BaiduNetdiskDownload\1.DotNet基础加强-video\08Net基础加强第八天-文件流 序列化\视频\BigCopy.avi");

            Console.ReadKey();
        }
        /// <summary>
        /// 大文件拷贝
        /// </summary>
        /// <param name="source"></param>
        /// <param name="target"></param>
        public static void BigFileCopy(string source, string target)
        {
            //需要两个文件流进行读写操作
            using (var fRead = new FileStream(source, FileMode.OpenOrCreate, FileAccess.Read))
            {
                using (var fWriter = new FileStream(target, FileMode.OpenOrCreate, FileAccess.Write))
                {
                    var bytes = new byte[1024 * 1024];
                    int num = fRead.Read(bytes, 0, bytes.Length);
                    while (num > 0)
                    {
                        fWriter.Write(bytes, 0, num);
                        Thread.Sleep(100);                      
                        num = fRead.Read(bytes, 0, bytes.Length);
                        Console.WriteLine(fWriter.Position * 100 / (double)fRead.Length + "%");
                    }
                }
            }

        }
    }
}

