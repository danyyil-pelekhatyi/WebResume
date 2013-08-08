using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Resume.Core.Models;

namespace Resume.Core.Interfaces
{
    public interface IUnitOfWork
    {
        IRepository<Activity> Activities { get; }
        IRepository<Feedback> Feedbacks { get; }
        IRepository<ActivityType> ActivityTypes { get; }
        void Commit();
    }
}
