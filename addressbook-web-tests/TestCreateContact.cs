using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace addressbook_web_tests
{
    [TestFixture]
    public class CreateGroup
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
        public void TheCreateGroupTest()
        {
            driver.Navigate().GoToUrl(baseURL);
            driver.FindElement(By.Name("user")).Clear();
            driver.FindElement(By.Name("user")).SendKeys("admin");
            driver.FindElement(By.Id("content")).Click();
            driver.FindElement(By.Name("pass")).Click();
            driver.FindElement(By.Name("pass")).Clear();
            driver.FindElement(By.Name("pass")).SendKeys("secret");
            driver.FindElement(By.CssSelector("input[type=\"submit\"]")).Click();
            driver.FindElement(By.LinkText("add new")).Click();
            driver.FindElement(By.Name("firstname")).Click();
            driver.FindElement(By.Name("firstname")).Clear();
            driver.FindElement(By.Name("firstname")).SendKeys("Ivan");
            driver.FindElement(By.Name("middlename")).Click();
            driver.FindElement(By.Name("middlename")).Clear();
            driver.FindElement(By.Name("middlename")).SendKeys("Iva");
            driver.FindElement(By.Name("lastname")).Click();
            driver.FindElement(By.Name("lastname")).Clear();
            driver.FindElement(By.Name("lastname")).SendKeys("Ivanov");
            driver.FindElement(By.Name("nickname")).Click();
            driver.FindElement(By.Name("nickname")).Clear();
            driver.FindElement(By.Name("nickname")).SendKeys("qwe");
            driver.FindElement(By.Name("title")).Click();
            driver.FindElement(By.Name("title")).Clear();
            driver.FindElement(By.Name("title")).SendKeys("qweTitle");
            driver.FindElement(By.Name("company")).Click();
            driver.FindElement(By.Name("company")).Clear();
            driver.FindElement(By.Name("company")).SendKeys("qweCompany");
            driver.FindElement(By.Name("address")).Click();
            driver.FindElement(By.Name("address")).Clear();
            driver.FindElement(By.Name("address")).SendKeys("qweAddress");
            driver.FindElement(By.Name("home")).Click();
            driver.FindElement(By.Name("home")).Clear();
            driver.FindElement(By.Name("home")).SendKeys("qweHome");
            driver.FindElement(By.Name("mobile")).Click();
            driver.FindElement(By.Name("mobile")).Clear();
            driver.FindElement(By.Name("mobile")).SendKeys("898745632145");
            driver.FindElement(By.Name("work")).Click();
            driver.FindElement(By.Name("work")).Clear();
            driver.FindElement(By.Name("work")).SendKeys("qweWork");
            driver.FindElement(By.Name("fax")).Click();
            driver.FindElement(By.Name("fax")).Clear();
            driver.FindElement(By.Name("fax")).SendKeys("qweFax");
            driver.FindElement(By.Name("email")).Click();
            driver.FindElement(By.Name("email")).Clear();
            driver.FindElement(By.Name("email")).SendKeys("qweE-mail@mail.com");
            driver.FindElement(By.Name("email2")).Click();
            driver.FindElement(By.Name("email2")).Clear();
            driver.FindElement(By.Name("email2")).SendKeys("qwe");
            driver.FindElement(By.Name("email")).Click();
            driver.FindElement(By.Name("email2")).Click();
            driver.FindElement(By.Name("email3")).Click();
            driver.FindElement(By.Name("email3")).Clear();
            driver.FindElement(By.Name("email3")).SendKeys("qwe");
            driver.FindElement(By.Name("homepage")).Click();
            driver.FindElement(By.Name("homepage")).Clear();
            driver.FindElement(By.Name("homepage")).SendKeys("qwe");
            driver.FindElement(By.Name("bday")).Click();
            new SelectElement(driver.FindElement(By.Name("bday"))).SelectByText("14");
            driver.FindElement(By.CssSelector("option[value=\"14\"]")).Click();
            driver.FindElement(By.Name("bmonth")).Click();
            new SelectElement(driver.FindElement(By.Name("bmonth"))).SelectByText("August");
            driver.FindElement(By.CssSelector("option[value=\"August\"]")).Click();
            driver.FindElement(By.Name("byear")).Click();
            driver.FindElement(By.Name("byear")).Clear();
            driver.FindElement(By.Name("byear")).SendKeys("1999");
            driver.FindElement(By.Name("aday")).Click();
            new SelectElement(driver.FindElement(By.Name("aday"))).SelectByText("13");
            driver.FindElement(By.XPath("//div[@id='content']/form/select[3]/option[15]")).Click();
            driver.FindElement(By.Name("amonth")).Click();
            new SelectElement(driver.FindElement(By.Name("amonth"))).SelectByText("October");
            driver.FindElement(By.CssSelector("select[name=\"amonth\"] &gt; option[value=\"October\"]")).Click();
            driver.FindElement(By.Name("ayear")).Click();
            driver.FindElement(By.Name("ayear")).Clear();
            driver.FindElement(By.Name("ayear")).SendKeys("1998");
            driver.FindElement(By.Name("theform")).Click();
            driver.FindElement(By.Name("new_group")).Click();
            new SelectElement(driver.FindElement(By.Name("new_group"))).SelectByText("a");
            driver.FindElement(By.CssSelector("select[name=\"new_group\"] &gt; option[value=\"4\"]")).Click();
            driver.FindElement(By.Name("address2")).Click();
            driver.FindElement(By.Name("address2")).Clear();
            driver.FindElement(By.Name("address2")).SendKeys("qweAddressSecondary");
            driver.FindElement(By.Name("notes")).Click();
            driver.FindElement(By.Name("notes")).Clear();
            driver.FindElement(By.Name("notes")).SendKeys("qweAddressSecondary");
            driver.FindElement(By.XPath("//div[@id='content']/form/input[21]")).Click();
            driver.FindElement(By.LinkText("home")).Click();
            driver.FindElement(By.LinkText("Logout")).Click();
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

