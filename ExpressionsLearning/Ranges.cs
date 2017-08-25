using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace ExpressionsLearning
{
    class Ranges : IQueryable<int>
    {
        private IQueryable<int> _rangeQueryable;
        private RangeEnumerator _enumerator;
        private int _max;
        public Ranges(int max)
        {
            _max = max;
            _enumerator = new RangeEnumerator(_max);
            _rangeQueryable = Enumerable.Range(1, _max).AsQueryable();
        }

        public Type ElementType => typeof(int);
        public Expression Expression => _rangeQueryable.Expression;
        public IQueryProvider Provider => _rangeQueryable.Provider;
        public IEnumerator<int> GetEnumerator() => _enumerator;
        IEnumerator IEnumerable.GetEnumerator() => _enumerator;
    }

    class RangeEnumerator : IEnumerator<int>
    {
        private int _max;
        public RangeEnumerator(int max)
        {
            _max = max;
        }

        private int _current;
        public int Current
        {
            get
            {
                return _current;
            }
            set { _current = value; }
        }

        object IEnumerator.Current => Current;

        public void Dispose(){}

        public bool MoveNext()
        {
            Console.WriteLine(_current);
            Current += 1;
            return Current <= _max;            
        }

        public void Reset()
        {
            Current = 0;
        }
    }
}
