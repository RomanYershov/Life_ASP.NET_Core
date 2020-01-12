using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InterestingLife_Core.Models;

namespace InterestingLife_Core.Abstractions
{
    public interface IDiaryService
    {
        Diary GetTableByDate(string date);
        void Save(int id, string str);
        void Create(Diary diary);
    }
}
