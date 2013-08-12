using Resume.Core.Models;
using System.Data.Entity;
using Resume.Infrastructure.Repositories;

namespace Resume.Infrastructure.ResumeDb
{
    public class ResumeDb : DbContext
    {
        public ResumeDb()
            : base("DefaultConnection")
        {
        }

        public DbSet<ActivityType> ActivityTypes { get; set; }
        public DbSet<Activity> Activities { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }

    }
}