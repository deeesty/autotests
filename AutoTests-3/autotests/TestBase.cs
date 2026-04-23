using NUnit.Framework;
using AutoTests.Managers;

namespace AutoTests
{
    [TestFixture]
    public class TestBase
    {
        protected ApplicationManager app;

        [SetUp]
        public void SetupTest()
        {
            app = new ApplicationManager();
        }

        [TearDown]
        public void TeardownTest()
        {
            app?.Stop();
        }
    }
}