using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InterestingLife_Core.Helpers;
using InterestingLife_Core.Models.Song;

namespace InterestingLife_Core.Abstractions
{
    public interface IService<T1, T2>
    {
        SimpleResponse Create(T2 entity);
        SimpleResponse Delete(int id);
        SimpleResponse Update(int id, T1 entity);
        IEnumerable<T1> Get();
        SimpleResponse Get(int id);
    }
}
