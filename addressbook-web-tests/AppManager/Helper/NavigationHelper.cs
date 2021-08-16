using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace WebAddressbookTests
{
    public class NavigationHelper : HelperBase
    {
        public NavigationHelper(ApplicationManager manager) : base(manager) {}
        public NavigationHelper GoToHomePage()
        {
            manager.Driver.Navigate().GoToUrl(manager.BaseURL);
            return this;
        }
        public NavigationHelper GoToGroupPage()
        {
            driver.FindElement(By.LinkText("groups")).Click();
            return this;
        }
        public NavigationHelper GoToAddNewPage()
        {
            driver.FindElement(By.LinkText("add new")).Click();
            return this;
        }
        public NavigationHelper LogOut()
        {
            driver.FindElement(By.LinkText("Logout")).Click();
            return this;
        }
    }
}
