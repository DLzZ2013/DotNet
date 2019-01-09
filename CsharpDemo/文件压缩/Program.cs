using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 文件压缩
{
    class Program
    {
        /// <summary>
        /// 压缩
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            using (var fr = File.OpenRead(@"E:\BaiduNetdiskDownload\2.数据库开发及ADO.NET-video\1.数据库简介 SQLServer环境配置 数据库基础知识\视频\1.数据库介绍.avi"))
            {
                using (var fw = File.OpenWrite(@"E:\BaiduNetdiskDownload\2.数据库开发及ADO.NET-video\1.数据库简介 SQLServer环境配置 数据库基础知识\视频\压缩.avi"))
                {
                    using (var zip = new GZipStream(fw, CompressionMode.Compress))
                    {
                        var bytes = new byte[fr.Length];

                        int num = fr.Read(bytes, 0, bytes.Length);
                        zip.Write(bytes, 0, num);
                        Console.WriteLine("压缩成功");
                    }

                }
            }
            UnCompress();
            Console.ReadKey();
        }
        /// <summary>
        /// 解压缩
        /// </summary>
        public static void UnCompress()
        {
            using (var fr = File.OpenRead(@"E:\BaiduNetdiskDownload\2.数据库开发及ADO.NET-video\1.数据库简介 SQLServer环境配置 数据库基础知识\视频\压缩.avi"))
            {
                using (var zip = new GZipStream(fr, CompressionMode.Decompress))
                {
                    using (var fw = File.OpenWrite(@"E:\BaiduNetdiskDownload\2.数据库开发及ADO.NET-video\1.数据库简介 SQLServer环境配置 数据库基础知识\视频\222.avi"))
                    {
                        var length = 0;
                        var fLenth = fr.Length;
                        var bytes = new byte[1024 * 5];
                        int num;
                        while ((num = zip.Read(bytes, 0, bytes.Length)) > 0)
                        {
                            length += num;
                            fw.Write(bytes, 0, num);
                        }

                    }
                }
            }
            Console.WriteLine("解压缩成功");
            Console.ReadKey();
        }


    }
}
