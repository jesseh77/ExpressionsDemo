using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace ExpressionsLearning
{
    class SampleFunctions
    {
        public static void Run()
        {
            Func<int, bool> func = x => x == 3;
            Expression<Func<int, bool>> exp = x => x == 3;
        }
    }
}
