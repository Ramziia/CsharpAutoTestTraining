using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    public class LoginTests:TestBase
    {
        [Test]
        public void LoginWithValidCredentials()
        {
            //prepare
            app.Auth.LogOut();

            //action
            AccountData account = new AccountData("admin", "secret");
            app.Auth.LogIn(account);

            //verification
            Assert.IsTrue(app.Auth.IsLoggedIn(account));
        }
        [Test]
        public void LoginWithInvalidCredentials()
        {
            //prepare
            app.Auth.LogOut();

            //action
            AccountData account = new AccountData("admin", "sec");
            app.Auth.LogIn(account);

            //verification
            Assert.IsFalse(app.Auth.IsLoggedIn(account));
        }
    }
}
