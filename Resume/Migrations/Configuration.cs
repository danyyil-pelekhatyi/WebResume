using System.Runtime.InteropServices;
using Resume.Core.Models;

namespace Resume.Web.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Resume.Infrastructure.Models.CvDb>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }


        protected override void Seed(Resume.Infrastructure.Models.CvDb context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.

            if (context.ActivityTypes.FirstOrDefault(e => e.ActivityTypeName == "Other") == null ||
                context.ActivityTypes.FirstOrDefault(e => e.ActivityTypeName == "Work") == null ||
                context.ActivityTypes.FirstOrDefault(e => e.ActivityTypeName == "Education") == null)
            {
                context.ActivityTypes.AddOrUpdate(activityType => activityType.ActivityTypeName,
                    new ActivityType { ActivityTypeName = "Work" },
                    new ActivityType { ActivityTypeName = "Education" },
                    new ActivityType { ActivityTypeName = "Other" }
                    );
            }
            else
            {
                context.Activities.AddOrUpdate(activity => activity.ActivityName,
                    new Activity
                    {
                        ActivityName = "Birth",
                        Description = "I was born early in the morning.",
                        ActivityType = context.ActivityTypes.First(e => e.ActivityTypeName == "Other"),
                        Start = new DateTime(1992, 1, 25),
                        End = new DateTime(1992, 1, 25)
                    },
                    new Activity
                    {
                        ActivityName = "School",
                        Description = "I have been studying in Lviv school #35 for 8 years.",
                        ActivityType = context.ActivityTypes.First(e => e.ActivityTypeName == "Education"),
                        Start = new DateTime(1998, 9, 1),
                        End = new DateTime(2006, 5, 31)
                    },
                    new Activity
                    {
                        ActivityName = "College",
                        Description =
                            "I have studied in Lviv College of Information and Communication Technologies on faculty of Computer Science.",
                        ActivityType = context.ActivityTypes.First(e => e.ActivityTypeName == "Education"),
                        Start = new DateTime(2006, 9, 1),
                        End = new DateTime(2010, 5, 31)
                    },
                    new Activity
                    {
                        ActivityName = "University",
                        Description =
                            "I am gaining my second high education in National University \"Lviv Polytechnic\" on Applied Mathematics faculty.",
                        ActivityType = context.ActivityTypes.First(e => e.ActivityTypeName == "Education"),
                        Start = new DateTime(2011, 9, 1),
                        End = new DateTime(2015, 5, 31)
                    },
                    new Activity
                    {
                        ActivityName = "Karate trainings",
                        Description = "I achieved 4-th kyu and won bunch of karate technique challenges.",
                        ActivityType = context.ActivityTypes.First(e => e.ActivityTypeName == "Other"),
                        Start = new DateTime(2000, 1, 1),
                        End = new DateTime(2008, 1, 1)
                    }
                );
            }
        }
    }
}
