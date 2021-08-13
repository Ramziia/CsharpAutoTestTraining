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
        //private IWebDriver driver;
        private FillFieldHelper fillFieldHelper;
        public LoginHelper(IWebDriver driver):base(driver)
        {
            fillFieldHelper = new FillFieldHelper(driver);
        }
        public void LogIn(AccountData accountdata)
        {
            fillFieldHelper.FillField("user", accountdata.Username);
            fillFieldHelper.FillField("pass", accountdata.Password);
            driver.FindElement(By.XPath("//input[@value='Login']")).Click();
        }
    }
}
