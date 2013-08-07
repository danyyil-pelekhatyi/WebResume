using Resume.Core.Models;
using System.Data.Entity;

namespace Resume.Infrastructure.Models
{
    public class CvDb : DbContext
    {
        public CvDb() : base("DefaultConnection")
        {
        }

        public DbSet<Cv> CvParts { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
    }
}