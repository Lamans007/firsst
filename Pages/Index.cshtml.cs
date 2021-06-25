using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CalendarApp.Models;
using CalendarApp.Data;
using Microsoft.EntityFrameworkCore;


namespace CalendarApp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly CalendarAppContext _context;
        private readonly CalendarAppContext _context2;
        private readonly CalendarAppContext _context3;


        public IndexModel(ILogger<IndexModel> logger, CalendarAppContext context, CalendarAppContext context2, CalendarAppContext context3)
        {
            _logger = logger;
            _context = context;
            _context2 = context2;
            _context3 = context3;
        }

        public List<Activity> Activities { get; set; }
        public List<CurrentDay> CurrentDays { get; set; }

        [BindProperty]
        public Activity Activity { get; set; }
        
        public List<string> Months { get; set; }

        public async Task OnGetAsync(int? nxt)
        {
            int month = DateTime.Now.Month;
            if (nxt.HasValue)
            {
                month = nxt.Value+1;
            }

            var currentDays = from c in _context.CurrentDays
                              where c.CurrentDate.Month == month
                              select c;

            var activities = from a in _context2.Activities
                             where a.TimeAt.Month == month
                             select a;


            Months = new List<string>();
            DateTime forMonths = new DateTime(2021, 1, 1, 1, 1, 1);
            for (int i=1; i<13; i++)
            {
                Months.Add(forMonths.Date.ToString("MMMM"));
                forMonths = forMonths.AddMonths(1);
            }

            CurrentDays = await currentDays.ToListAsync();
            Activities = await activities.ToListAsync();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context3.Activities.Add(Activity);
                await _context3.SaveChangesAsync();

                return RedirectToPage("/Index");
                


        }
    }
}

