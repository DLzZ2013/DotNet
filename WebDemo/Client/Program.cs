using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;
using WcfDemo;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var client = new ClientProxy())
            {
                Console.WriteLine(client.Test("DLz"));                
            }

            Console.ReadKey();
        }
    }   
    class ClientProxy : ClientBase<IWcfInterface>, IWcfInterface
    {
        /// <summary>
        /// 硬编码定义绑定
        /// </summary>
        public static readonly Binding ClientBinding = new BasicHttpBinding();
        /// <summary>
        /// 硬编码定义终结点
        /// </summary>
        public static readonly EndpointAddress ClientEndpointAddress = new EndpointAddress("http://localhost/Host");
        public ClientProxy(): base(ClientBinding, ClientEndpointAddress)
        {
        }
        public string Test(string msg)
        {
            return Channel.Test(msg);
        }

        public DateTime GetDate()
        {
            throw new NotImplementedException();
        }
    }
}
