using Microsoft.EntityFrameworkCore;
using CalendarApp.Models;

namespace CalendarApp.Data
{
    public class CalendarAppContext : DbContext
    {
        public CalendarAppContext(DbContextOptions<CalendarAppContext> options) : base(options)
        {
        }
            public DbSet<Activity> Activities { get; set; }
            public DbSet<CurrentDay> CurrentDays { get; set; }

            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                modelBuilder.Entity<Activity>().ToTable("Activity");
                modelBuilder.Entity<CurrentDay>().ToTable("CurrentDay");
            }
    }
}
