using System.Data.Entity.Infrastructure;
using Resume.Core.Interfaces;
using Resume.Core.Models;
using System.Configuration;
using System.Data.Objects;
using Resume.Infrastructure.Models;
using Resume.Infrastructure.Repositories;

namespace Resume.Infrastructure.UnitOfWork
{
    public class SimpleUnitOfWork : IUnitOfWork
    {
        private readonly ObjectContext _context;
        private IRepository<Activity> _activities;
        private IRepository<Feedback> _feedbacks;
        private IRepository<ActivityType> _activityTypes;
        public SimpleUnitOfWork()
        {
            var context = new CvDb();
            var adapter = (IObjectContextAdapter)context;
            _context = adapter.ObjectContext;
            _context.ContextOptions.LazyLoadingEnabled = true;
        }
        public IRepository<Activity> Activities
        {
            get
            {
                _activities = _activities ?? new Repository<Activity>(_context);
                return _activities;
            }
        }

        public IRepository<Feedback> Feedbacks
        {
            get
            {
                _feedbacks = _feedbacks ?? new Repository<Feedback>(_context);
                return _feedbacks;
            }
        }

        public IRepository<ActivityType> ActivityTypes
        {
            get
            {
                _activityTypes = _activityTypes ?? new Repository<ActivityType>(_context);
                return _activityTypes;
            }
        }

        public void Commit()
        {
            _context.SaveChanges();
        }
    }
}
