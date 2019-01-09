using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace WcfDemo
{
    public class WcfTest:IWcfInterface
    {
        public string Test(string msg)
        {           
            return "这是一个WCF测试Demo:"+msg;
        }

        public DateTime GetDate()
        {
            return DateTime.Now;
        }
    }
}
