using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace LinqMethods
{
    public class Class1
    {
        public IEnumerable<string> GetFruits(IEnumerable<(bool, string)> input)
        {
            return input.Where(i => i.Item1).Select(i =>i.Item2).ToArray();
        }
 
        public Expression<Func<IEnumerable<(bool, string)>, IEnumerable<string>>> GetFruits2()
        {
            Expression<Func<IEnumerable<(bool, string)>, IEnumerable<string>>> del = k => k.Where(i => i.Item1).Select(i => i.Item2).ToArray();

            return del;
        }
    }
}
