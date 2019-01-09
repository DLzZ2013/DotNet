using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace IQueryableh和IQueryProvider
{
    class FakeQueryProvider : IQueryProvider
    {
        public IQueryable CreateQuery(Expression expression)
        {
            Type queryType = typeof(FakeQuery<>).MakeGenericType(expression.Type);
            object[] constructorArgs = new object[] { this, expression };
            return (IQueryable)Activator.CreateInstance(queryType, constructorArgs);
        }

        public IQueryable<T> CreateQuery<T>(Expression expression)
        {
            Console.WriteLine();
            return new FakeQuery<T>(this, expression);
        }

        public object Execute(Expression expression)
        {
            return null;
        }

        public TResult Execute<TResult>(Expression expression)
        {
            return default(TResult);
        }
    }
}
