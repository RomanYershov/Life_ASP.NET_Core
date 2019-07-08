using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InterestingLife_Core.Helpers;
using InterestingLife_Core.Models.Abstractions;
using InterestingLife_Core.Models.Song;

namespace InterestingLife_Core.Abstractions
{
    public interface IService<T1, T2>   where  T2   : ViewModelBase 
    {
        SimpleResponse Create(T2 entity);
        SimpleResponse Delete(int id);
        SimpleResponse Delete(T1 entity);
        SimpleResponse Update(T2 entity);
        IEnumerable<T1> Get();
        SimpleResponse Get(int id);
    }
}
