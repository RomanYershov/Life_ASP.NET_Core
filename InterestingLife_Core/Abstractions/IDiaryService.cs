﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InterestingLife_Core.Models;

namespace InterestingLife_Core.Abstractions
{
    public interface IDiaryService
    {
        Diary GetTableByDate(string date);
        Diary GetTableByDate(string date, string userId);
        void Save(int id, string str);
        int Save(int id, string str, string date, string userId);
        void Create(Diary diary);
    }
}