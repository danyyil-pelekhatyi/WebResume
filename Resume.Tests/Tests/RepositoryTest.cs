using System;
using System.Collections.Generic;
using System.Data.Objects;
using System.Linq;
using System.Linq.Expressions;
using Resume.Core.Interfaces;
using Resume.Core.Models;
using Resume.Infrastructure.EntityFramework;
using Resume.Infrastructure.Repositories;
using NUnit.Framework;

namespace Resume.Tests.Tests
{
    [TestFixture]
    public class RepositoryTest
    {
        private static IUnitOfWork _unitOfWork = new SimpleUnitOfWork();
        private static IRepository<Activity> _repository = _unitOfWork.Activities;
        private static IRepository<ActivityType> _atRepository = _unitOfWork.ActivityTypes;

        private Activity getActivity()
        {
            return new Activity
            {
                ActivityName = "Test",
                Description = "Test description",
                ActivityType =
                    _atRepository.Find(at => at.ActivityTypeName == "Other").First(),
                End = DateTime.Now,
                Start = DateTime.Now
            };
        }

        [Test]
        public void AddTest()
        {
            var item = getActivity();
            _repository.Add(item);
            _unitOfWork.Commit();
            Assert.IsTrue(_repository.Find(e => (e.Description == item.Description && e.ActivityName == item.ActivityName)).FirstOrDefault() != null);
        }

        [Test]
        public void UpdateTest()
        {
            var item = getActivity();
            item.ActivityName = "Super unique activity";
            _repository.Add(item);
            _unitOfWork.Commit();
            item.Description = "New test description";
            _repository.Update(item);
            _unitOfWork.Commit();
            Assert.IsTrue(_repository.Find(e => (e.Description == item.Description && e.ActivityName == item.ActivityName)).FirstOrDefault() != null);
        }

        [Test]
        public void Delete()
        {
            var item = getActivity();
            _repository.Add(item);
            _unitOfWork.Commit();
            _repository.Delete(item);
            _unitOfWork.Commit();
            Assert.IsTrue(
                _repository.Find(e => (e.Description == item.Description && e.ActivityName == item.ActivityName))
                    .FirstOrDefault() != null);
        }
    }
}