using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterestingLife_Core.Abstractions
{
    public  interface ISearching<T>
    {
        IEnumerable<T> Search(string text);
        IEnumerable<T> Search(DateTime createDate);
    }
}
