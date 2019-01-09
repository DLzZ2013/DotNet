using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IQueryableh和IQueryProvider
{
    class Program
    {
        static void Main(string[] args)
        {
            var query = from x in new FakeQuery<string>()
                        where x.StartsWith("abc")
                        select x.Length;
            foreach (var i in query)
            {
                
            }
        }
    }
}
