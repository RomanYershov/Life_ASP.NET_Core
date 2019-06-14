﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InterestingLife_Core.Abstractions;

namespace InterestingLife_Core.Models.Song
{
    public class CategoryEditModel : ViewModelBase
    {
        public Category Category { get; set; }
        public bool HasChoosing { get; set; }
    }
}