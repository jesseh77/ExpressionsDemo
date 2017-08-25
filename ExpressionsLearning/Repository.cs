using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;

namespace ExpressionsLearning
{
    class Repository<T> where T: IArchive
    {
        private IQueryable<T> store = new List<T>().AsQueryable();
        public List<T> Find(Expression<Func<T, bool>> query)
        {
            var ex =
                Expression.Lambda<Func<T, bool>>(
                    Expression.AndAlso(query.Body, Expression.IsFalse(
                        Expression.Property(query.Parameters.Single(), "IsArchived")
                        )));
            
            return store.Where(ex).ToList();
        }
    }

    interface IArchive
    {
        bool IsArchived { get; set; }
    }
}
