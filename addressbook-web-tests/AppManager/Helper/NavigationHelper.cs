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
            if(driver.Url!=manager.BaseURL)
                manager.Driver.Navigate().GoToUrl(manager.BaseURL);
            return this;
        }
        public NavigationHelper GoToGroupPage()
        {
            if (driver.Url == manager.BaseURL + "/group.php"  && IsElementPresent(By.Name("new")))
                return this;
            driver.FindElement(By.LinkText("groups")).Click();
            return this;
        }
        public NavigationHelper GoToAddNewPage()
        {
            if (driver.Url == manager.BaseURL + "/edit.php" && IsElementPresent(By.Name("submit")))
                return this;
            driver.FindElement(By.LinkText("add new")).Click();
            return this;
        }
    }
}
