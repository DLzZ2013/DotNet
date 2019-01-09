using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace WcfDemo
{
    /// <summary>
    /// 服务契约
    /// </summary>
    [ServiceContract]
    public  interface IWcfInterface
    {        
        /// <summary>
        /// 服务操作
        /// </summary>
        [OperationContract]
        string Test(string msg);

        [OperationContract]
        DateTime GetDate();

    }
}
