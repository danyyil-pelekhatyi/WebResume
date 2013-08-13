using System;
using System.Linq;
using Resume.Core.Interfaces;
using Resume.Infrastructure.Repositories;
using NUnit.Framework;

namespace Resume.Tests.Tests
{
    [TestFixture]
    public class RepositoryTest
    {
        public class MyClass
        {
            public int Val { get; set; }
        }

        private MyClass createMyClass()
        {
            return new MyClass { Val = 33};
        }

        private IRepository<MyClass> _repository = new Repository<MyClass>();

        [Test]
        public void AddFindUpdateDeleteTest()
        {
            MyClass item = createMyClass();
            _repository.Add(item);
            item.Val *= 2;

        }
    }
}