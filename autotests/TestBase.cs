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
            app = ApplicationManager.GetInstance();
        }
    }
}