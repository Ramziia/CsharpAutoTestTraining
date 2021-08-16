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
    public class LoginHelper : HelperBase
    {
        public LoginHelper(ApplicationManager manager):base(manager) {}
        public void LogIn(AccountData accountdata)
        {
            manager.FillField.FillField("user", accountdata.Username);
            manager.FillField.FillField("pass", accountdata.Password);
            driver.FindElement(By.XPath("//input[@value='Login']")).Click();
        }
    }
}
