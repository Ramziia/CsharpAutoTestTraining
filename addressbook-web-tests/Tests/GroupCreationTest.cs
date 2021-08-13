using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace WebAddressbookTests
{ 
    [TestFixture]
    public class GroupCreationTest : TestBase
    {
        [Test]
        public void TheUntitledTestCaseTest()
        {
            app.Navigator.GoToHomePage();
            app.Auth.LogIn(new AccountData("admin","secret"));
            app.Navigator.GoToGroupPage();
            app.Groups.InitGroupCreation();
            app.Groups.FillGroupCreation(new GroupData("qweName", "qweHeader", "qweFooter"));
            app.Groups.SubmitGroupPage();
            app.Navigator.GoToGroupPage();
            app.Navigator.LogOut();
        }
    }
}


