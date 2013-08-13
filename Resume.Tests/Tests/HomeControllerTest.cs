using System.Web.Mvc;
using Resume.Infrastructure.EntityFramework;
using Resume.Web.Controllers;
using NUnit.Framework;

namespace Resume.Tests.Tests
{
    [TestFixture]
    public class HomeControllerTest
    {
        private readonly HomeController _controller;

        public HomeControllerTest()
        {
            _controller = new HomeController(new SimpleUnitOfWork());
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
        public void GetActivities()
        {

        }

        [Test]
        public void Chat()
        {
            Assert.IsTrue(_controller.Chat() is ViewResult);
        }

        [Test]
        public void Feedback()
        {

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
