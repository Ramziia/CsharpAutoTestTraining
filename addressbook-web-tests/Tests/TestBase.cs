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
        protected ApplicationManager app;
        [SetUp]
        public void SetupTest()
        {
            app = new ApplicationManager();
            app.Navigator.GoToHomePage();
            app.Auth.LogIn(new AccountData("admin", "secret"));
            verificationErrors = new StringBuilder();
        }

        [TearDown]
        public void TeardownTest()
        {
            app.Stop();
        }
    }
}
