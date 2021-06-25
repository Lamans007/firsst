using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CalendarApp.Models;
using CalendarApp.Data;
using Microsoft.EntityFrameworkCore;


namespace CalendarApp.Pages
{
    public class EditModel : PageModel
    {
        private readonly CalendarAppContext _context;
        private readonly CalendarAppContext _context2;

        public EditModel(CalendarAppContext context, CalendarAppContext context2)
        {
            _context = context;
            _context2 = context2;
        }
        public List<Activity> Activities { get; set; } 
        public CurrentDay DayToEdit { get; set; } 

        public async Task OnGetAsync(int id)
        {


            DayToEdit = await _context.CurrentDays.FindAsync(id);

            var activities = from a in _context2.Activities
                             where a.TimeAt.Month == DayToEdit.CurrentDate.Month
                             select a;

            
            Activities = await activities.ToListAsync();
            
        }
    }
}

