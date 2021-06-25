using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CalendarApp.Models;

namespace CalendarApp.Data
{
    public class DbInitialiser
    {
        public static void Initialise(CalendarAppContext context)
        {
            context.Database.EnsureCreated();

            // Look for any Activities.
            if (context.Activities.Any())
            {
                return;   // DB has been seeded
            }


            var Activities = new Activity[]
            {
                new Activity{ Title="Shopping", Details="eggs, pineaple, ham", TimeAt=new DateTime(2021,4, 1, 16,5,0)},
                new Activity{ Title="Shopping", Details="eggs, pineaple, ham", TimeAt=new DateTime(2021,4, 15, 16,5,0)}
            };

            foreach(Activity a in Activities)
            {
                context.Activities.Add(a);
            }


            var CurrentDays = new CurrentDay[365];
            DateTime StartThisYear = new DateTime(2021, 1, 1, 12, 0, 0);

            for (int i=0; i<CurrentDays.Length; i++)
            {
                CurrentDays[i] = new CurrentDay { ID = i+1, CurrentDate = StartThisYear.AddDays(i)};
            }

            CurrentDays[111].Flag = "Your Birthday!";

            foreach (CurrentDay c in CurrentDays)
            {
                context.CurrentDays.Add(c);
            }
            context.SaveChanges();
        }
    }
}
