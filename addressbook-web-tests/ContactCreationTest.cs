﻿using System;
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
            GoToHomePage();
            LogIn(new AccountData("admin", "secret"));
            GoToAddNewPage();
            ContactData _contact = new ContactData("qweFirstname", "qweLastname");

            FillContactForm(_contact);
            GoToHomePage();
            LogOut();
        }
    }
}