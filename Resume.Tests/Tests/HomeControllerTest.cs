using System.Web.Mvc;
using System.Web.Util;
using Resume.Infrastructure.EntityFramework;
using Resume.Web.Controllers;
using NUnit.Framework;
using System.Transactions;

namespace Resume.Tests.Tests
{
    [SetUpFixture]
    public class SetUpFixture
    {
        private TransactionScope _transaction;

        [SetUp]
        public void SetUp()
        {
            _transaction = new TransactionScope();
        }

        [TearDown]
        public void TearDown()
        {
            _transaction.Complete();
        }
    }

    [TestFixture]
    public class HomeControllerTest
    {
        private readonly HomeController _controller;

        public HomeControllerTest()
        {
            _controller = new HomeController(new SimpleUnitOfWork());
        }

        [Test]
        public void GetActivities()
        {
            var result = (JsonResult) _controller.GetActivities();
            Assert.IsTrue(result != null);
        }

        [Test]
        public void Feedback()
        {
            var result = (ViewResult)_controller.Feedback();
            Assert.IsTrue(result.Model != null);
        }

        [Test]
        public void Index()
        {
            Assert.IsTrue(_controller.Index() is ViewResult);
        }

        [Test]
        public void Skills()
        {
            Assert.IsTrue(_controller.Skills() is ViewResult);
        }

        [Test]
        public void Cv()
        {
            Assert.IsTrue(_controller.Cv() is ViewResult);
        }

        [Test]
        public void Chat()
        {
            Assert.IsTrue(_controller.Chat() is ViewResult);
        }

        [Test]
        public void About()
        {
            Assert.IsTrue(_controller.About() is ViewResult);
        }

        [Test]
        public void Contact()
        {
            Assert.IsTrue(_controller.Contact() is ViewResult);
        }
    }
}
