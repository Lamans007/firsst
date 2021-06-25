using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalendarApp.Models
{
    public class CurrentDay
    {
        public int ID { get; set; }
        public string? Flag { get; set; }
        public DateTime CurrentDate { get; set; }
    }
}
