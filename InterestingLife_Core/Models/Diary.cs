using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using InterestingLife_Core.Models.Abstractions;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace InterestingLife_Core.Models
{
    public class Diary : Entity
    {
        public int Id { get; set; }
        public string OneMonthStatistic { get; set; }
        public DateTime DateTime { get; set; }

        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public IdentityUser User { get; set; }
    }
}
