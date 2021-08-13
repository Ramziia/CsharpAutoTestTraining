using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class TestBase
    {
        private StringBuilder verificationErrors;
        protected string baseURL;
        protected ApplicationManager app;
        [SetUp]
        public void SetupTest()
        {
            app = new ApplicationManager();
            baseURL = "http://localhost/addressbook/";
            verificationErrors = new StringBuilder();
        }

        [TearDown]
        public void TeardownTest()
        {
            app.Stop();
        }
    }
}
