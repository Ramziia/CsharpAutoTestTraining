//using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupRemoveTests : TestBase
    {
        [Test]
        public void GroupRemoveTest()
        {
            app.Navigator.GoToHomePage();
            app.Auth.LogIn(new AccountData("admin", "secret"));
            app.Navigator.GoToGroupPage();
            app.Groups.SelectGroup(1);
            app.Groups.RemoveGroup();
            app.Navigator.GoToGroupPage();
        }
    }
}

