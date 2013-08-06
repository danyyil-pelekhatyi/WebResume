using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Resume.Models
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