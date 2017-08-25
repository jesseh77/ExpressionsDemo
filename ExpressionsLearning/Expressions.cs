using System;
using System.Linq.Expressions;
using System.Linq;
using System.Collections.Generic;

namespace ExpressionsLearning
{
    class Expressions
    {
        public static void Run()
        {
            IQueryable<int> ranges = new Ranges(10);
            
            Func<int, bool> func = x => x % 5 == 0;

            Expression<Func<int, bool>> expression = x => x % 5 == 0;
            
            var paramExpression = Expression.Parameter(typeof(int));
            var lambda = Expression.Lambda<Func<int, bool>>(
                Expression.Equal(
                    Expression.Modulo(paramExpression, Expression.Constant(5)),
                    Expression.Constant(0)),
                paramExpression);


            var fives = ranges.Where(func);

            foreach (var number in fives)
            {
                Console.WriteLine(number);
            }

            Console.ReadKey();
        }
    }
}
