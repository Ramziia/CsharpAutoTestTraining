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
    public class ContactCreationTest : TestBase
    {
        [Test]
        public void TheCreateContactTest()
        {
            app.Navigator.GoToHomePage();
            app.Auth.LogIn(new AccountData("admin", "secret"));
            app.Navigator.GoToAddNewPage();
            ContactData _contact = new ContactData("qweFirstname", "qweLastname");

            app.Contact.FillContactForm(_contact);
            app.Navigator.GoToHomePage();
            app.Navigator.LogOut();
        }
    }
}
