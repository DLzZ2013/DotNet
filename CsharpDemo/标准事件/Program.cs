using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 标准事件
{
    class Program
    {
        static void Main(string[] args)
        {
            var data = new DataArgs();
            data.Data = "封神榜";
            var publisher = new Publisher();
            var subscriber = new Subscriber(publisher);
            publisher.Publish(data);
            Console.ReadKey();

        }

    }

    class Publisher
    {
        public event EventHandler<DataArgs> Publication;

        public void Publish(DataArgs args)
        {
            for (int i = 0; i < 100; i++)
            {
                if (i == 12)
                {
                    Console.WriteLine("开始发布！");
                    Publication?.Invoke(this, args);
                }
            }
        }
    }

    class Subscriber
    {
        public Subscriber(Publisher publisher)
        {
            publisher.Publication += Read;
        }

        private void Read(object sender, DataArgs args)
        {
            Console.WriteLine("开始阅览:" + "《" + args.Data + "》");
        }
    }

    class DataArgs : EventArgs
    {
        public string Data;
    }
}
