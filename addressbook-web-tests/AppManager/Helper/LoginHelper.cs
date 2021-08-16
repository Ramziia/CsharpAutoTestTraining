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
            if(IsLoggedIn())
            {
                if(IsLoggedIn(accountdata))
                {
                    return;
                }
                manager.Auth.LogOut();
            }
            manager.FillField.FillField("user", accountdata.Username);
            manager.FillField.FillField("pass", accountdata.Password);
            driver.FindElement(By.XPath("//input[@value='Login']")).Click();
        }
        public bool IsLoggedIn()
        {
            return IsElementPresent(By.Name("logout"));
        }
        public bool IsLoggedIn(AccountData account)
        {
            return IsLoggedIn() 
                && driver.FindElement(By.Name("logout")).FindElement(By.TagName("b")).Text 
                == "(" + account.Username + ")";
        }
        public LoginHelper LogOut()
        {
            if(this.IsLoggedIn())
                driver.FindElement(By.LinkText("Logout")).Click();
            return this;
        }
    }
}
