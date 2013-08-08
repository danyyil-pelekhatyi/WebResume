﻿using Resume.Core.Models;
using System.Data.Entity;
using Resume.Infrastructure.Repositories;

namespace Resume.Infrastructure.Models
{
    public class CvDb : DbContext
    {
        public CvDb()
            : base("DefaultConnection")
        {
        }

        public DbSet<ActivityType> ActivityTypes { get; set; }
        public DbSet<Activity> Activities { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }

    }
}