using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace WebAddressbookTests
{ 
    [TestFixture]
    public class GroupCreationTest
    {
        private IWebDriver driver;
        private StringBuilder verificationErrors;
        private string baseURL;
        private bool acceptNextAlert = true;

        [SetUp]
        public void SetupTest()
        {
            driver = new FirefoxDriver();
            baseURL = "http://localhost/addressbook/";
            verificationErrors = new StringBuilder();
        }

        [TearDown]
        public void TeardownTest()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
            Assert.AreEqual("", verificationErrors.ToString());
        }


        [Test]
        public void TheUntitledTestCaseTest()
        {
            OpenHomePage();
            LogIn(new AccountData("admin","secret"));
            GoToGroupPage();
            InitGroupCreation();
            FillGroupCreation(new GroupData("qweName", "qweHeader", "qweFooter"));
            SubmitGroupPage();
            BackToGroupPage();
            LogOut();
        }

        private void LogOut()
        {
            driver.FindElement(By.LinkText("Logout")).Click();
        }

        private void BackToGroupPage()
        {
            driver.FindElement(By.LinkText("groups")).Click();
        }

        private void SubmitGroupPage()
        {
            driver.FindElement(By.Name("submit")).Click();
        }
        private void FillGroupCreation(GroupData groupdata)
        {
            FillField("group_name", groupdata.Name);
            FillField("group_header", groupdata.Header);
            FillField("group_footer", groupdata.Footer);
        }

        private void FillField(string name_of_element, string value)
        {
            driver.FindElement(By.Name(name_of_element)).Click();
            driver.FindElement(By.Name(name_of_element)).Clear();
            driver.FindElement(By.Name(name_of_element)).SendKeys(value);
        }
        private void InitGroupCreation()
        {
            driver.FindElement(By.Name("new")).Click();
        }

        private void GoToGroupPage()
        {
            driver.FindElement(By.LinkText("groups")).Click();
        }

        private void LogIn(AccountData accountdata)
        {
            FillField("user", accountdata.Username);
            FillField("pass", accountdata.Password);
            driver.FindElement(By.XPath("//input[@value='Login']")).Click();
        }

        private void OpenHomePage()
        {
            driver.Navigate().GoToUrl(baseURL);
        }

        private bool IsElementPresent(By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        private bool IsAlertPresent()
        {
            try
            {
                driver.SwitchTo().Alert();
                return true;
            }
            catch (NoAlertPresentException)
            {
                return false;
            }
        }

        private string CloseAlertAndGetItsText()
        {
            try
            {
                IAlert alert = driver.SwitchTo().Alert();
                string alertText = alert.Text;
                if (acceptNextAlert)
                {
                    alert.Accept();
                }
                else
                {
                    alert.Dismiss();
                }
                return alertText;
            }
            finally
            {
                acceptNextAlert = true;
            }
        }
    }
}


