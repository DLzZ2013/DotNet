using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace IQueryableh和IQueryProvider
{
    class FakeQuery<T>:IQueryable<T>
    {
        internal FakeQuery(IQueryProvider provider, Expression expression)
        {
            Provider = provider;
            Expression = expression;
            ElementType = typeof(T);
        }

        internal FakeQuery() : this(new FakeQueryProvider(), null)
        {
            Expression = System.Linq.Expressions.Expression.Constant(this);
        }
        public IEnumerator<T> GetEnumerator()
        {
           return Enumerable.Empty<T>().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public override  string ToString()
        {
            return "FakeQuery";
        }
        public Expression Expression { get; }
        public Type ElementType { get; }
        public IQueryProvider Provider { get; }
    }
}
