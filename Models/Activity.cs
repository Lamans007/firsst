using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalendarApp.Models
{
    public class Activity
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Details { get; set; }
        public DateTime TimeAt { get; set; }
    }
}
