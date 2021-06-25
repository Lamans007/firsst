using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CalendarApp.Data;
using CalendarApp.Models;

namespace CalendarApp.Pages.Shared
{
    public class ReaActivityModel : PageModel
    {
        private readonly CalendarApp.Data.CalendarAppContext _context;

        public ReaActivityModel(CalendarApp.Data.CalendarAppContext context)
        {
            _context = context;
        }

        public IList<Activity> Activity { get;set; }

        public async Task OnGetAsync()
        {
            Activity = await _context.Activities.ToListAsync();
        }
    }
}
