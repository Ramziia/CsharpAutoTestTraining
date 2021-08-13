using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
//using OpenQA.Selenium;
//using OpenQA.Selenium.Firefox;
//using OpenQA.Selenium.Support.UI;

namespace WebAddressbookTests
{ 
    [TestFixture]
    public class GroupCreationTest : TestBase
    {
        [Test]
        public void TheUntitledTestCaseTest()
        {
            GoToHomePage();
            LogIn(new AccountData("admin","secret"));
            GoToGroupPage();
            InitGroupCreation();
            FillGroupCreation(new GroupData("qweName", "qweHeader", "qweFooter"));
            SubmitGroupPage();
            GoToGroupPage();
            LogOut();
        }
    }
}


