using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 数据库
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = new string[2, 2]
            {
                {"1", "2"},
                {"3", "4"}
            };
            var s= new StringBuilder();
            s.Append("   ");
            Console.WriteLine(""+s.ToString()+2);
            Console.ReadKey();

        }
    }
}
