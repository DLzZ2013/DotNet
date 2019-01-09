using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.ServiceModel.Channels;

namespace ServiceHost
{
    class Program
    {
        static void Main(string[] args)
        {
            //新建主机
            System.ServiceModel.ServiceHost host
                 = new System.ServiceModel.ServiceHost(typeof(WcfDemo.WcfTest),new Uri("http://localhost/Host"));
            host.Open();
            Console.WriteLine("服务启动~");
            Console.ReadKey();
            //using (var host =new HostDemo())
            //{
            //    host.Open();
            //    Console.ReadKey();
            //}
        }
    }

    public class HostDemo : IDisposable
    { 
        /// <summary>
        /// 宿主对象
        /// </summary>
        private System.ServiceModel.ServiceHost _host;
        public System.ServiceModel.ServiceHost Host => _host;

        public HostDemo()
        {
            CreateServiceHost();
        }
        /// <summary>
        /// 打开服务
        /// </summary>
        public void Open()
        {
            Console.WriteLine("启动服务对象!");
            _host.Open();
            Console.WriteLine("服务启动成功!");
        }
        /// <summary>
        /// 基地址
        /// </summary>
        public const string BaseAddress = "net.pipe://localhost";

        /// <summary>
        /// 可选地址
        /// </summary>
        public const string ServiceAddress = "Test";

        /// <summary>
        /// 服务契约实现类型
        /// </summary>
        public static readonly Type ServiceType = typeof(WcfDemo.WcfTest);
        /// <summary>
        /// 服务契约接口
        /// </summary>
        public static readonly Type ContractType = typeof(WcfDemo.IWcfInterface);
        /// <summary>
        /// 服务定义一个绑定
        /// </summary>
        public static readonly Binding Binding = new NetNamedPipeBinding();
        

        /// <summary>
        /// 构造服务对象
        /// </summary>
        protected void CreateServiceHost()
        {
            //创建服务对象 
            _host = new System.ServiceModel.ServiceHost(ServiceType, new Uri(BaseAddress));
            //添加终结点
            _host.AddServiceEndpoint(ContractType, Binding, ServiceAddress);
        }
        public void Dispose()
        {
            if (_host != null)
            {
                (_host as IDisposable).Dispose();
            }

        }
    }
}
