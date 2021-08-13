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
    public class TestBase
    {
        protected IWebDriver driver;
        private StringBuilder verificationErrors;
        protected string baseURL;

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

        protected void GoToHomePage()
        {
            driver.Navigate().GoToUrl(baseURL);
        }
        protected void LogIn(AccountData accountdata)
        {
            FillField("user", accountdata.Username);
            FillField("pass", accountdata.Password);
            driver.FindElement(By.XPath("//input[@value='Login']")).Click();
        }
        protected void FillField(string name_of_element, string value)
        {
            driver.FindElement(By.Name(name_of_element)).Click();
            driver.FindElement(By.Name(name_of_element)).Clear();
            driver.FindElement(By.Name(name_of_element)).SendKeys(value);
        }
        protected void GoToGroupPage()
        {
            driver.FindElement(By.LinkText("groups")).Click();
        }
        protected void LogOut()
        {
            driver.FindElement(By.LinkText("Logout")).Click();
        }
        protected void SubmitGroupPage()
        {
            driver.FindElement(By.Name("submit")).Click();
        }
        protected void FillGroupCreation(GroupData groupdata)
        {
            FillField("group_name", groupdata.Name);
            FillField("group_header", groupdata.Header);
            FillField("group_footer", groupdata.Footer);
        }
        protected void InitGroupCreation()
        {
            driver.FindElement(By.Name("new")).Click();
        }
        protected void RemoveGroup()
        {
            driver.FindElement(By.Name("delete")).Click();
        }
        protected void SelectGroup(int index)
        {
            driver.FindElement(By.XPath("//div[@id='content']/form/span[" + index + "]/input")).Click();
        }
        protected void FillContactForm(ContactData _contact)
        {
            FillFieldByName(ElementName.Firstname, _contact.Firstname);
            FillFieldByName(ElementName.Lastname, _contact.Lastname);
            FillFieldByName(ElementName.Middlename, _contact.Middlename);
            FillFieldByName(ElementName.Nickname, _contact.Nickname);
            FillFieldByName(ElementName.Title, _contact.Title);
            FillFieldByName(ElementName.Company, _contact.Company);
            FillFieldByName(ElementName.Address, _contact.Address);
            FillFieldByName(ElementName.Home, _contact.Home);
            FillFieldByName(ElementName.Fax, _contact.Fax);
            FillFieldByName(ElementName.Mobile, _contact.Mobile);
            FillFieldByName(ElementName.Work, _contact.Work);
            FillFieldByName(ElementName.Bday, _contact.Bday);
            FillFieldByName(ElementName.Bmonth, _contact.Bmonth);
            FillFieldByName(ElementName.Byear, _contact.Byear);
            FillFieldByName(ElementName.Aday, _contact.Aday);
            FillFieldByName(ElementName.Amonth, _contact.Amonth);
            FillFieldByName(ElementName.Ayear, _contact.Ayear);

            FillFieldByName(ElementName.Address2, _contact.Address2);
            FillFieldByName(ElementName.Phone2, _contact.Phone2);
            FillFieldByName(ElementName.Notes, _contact.Notes);

            FillFieldByName(ElementName.Email, _contact.Email);
            FillFieldByName(ElementName.Email2, _contact.Email2);
            FillFieldByName(ElementName.Email3, _contact.Email3);
        }
        private void FillFieldSelect(string name, string value)
        {
            driver.FindElement(By.Name(name)).Click();
            new SelectElement(driver.FindElement(By.Name(name))).SelectByText(value);
        }
        private void FillFieldTextBox(string name, string value)
        {
            driver.FindElement(By.Name(name)).Click();
            driver.FindElement(By.Name(name)).Clear();
            driver.FindElement(By.Name(name)).SendKeys(value);
        }
        protected void GoToAddNewPage()
        {
            driver.FindElement(By.LinkText("add new")).Click();
        }
        private void FillFieldByName(ElementName elementname, string value)
        {
            switch (elementname)
            {
                case ElementName.Firstname:
                    FillFieldTextBox("firstname", value);
                    break;
                case ElementName.Lastname:
                    FillFieldTextBox("lastname", value);
                    break;
                case ElementName.Middlename:
                    FillFieldTextBox("middlename", value);
                    break;
                case ElementName.Nickname:
                    FillFieldTextBox("nickname", value);
                    break;
                case ElementName.Title:
                    FillFieldTextBox("title", value);
                    break;
                case ElementName.Company:
                    FillFieldTextBox("company", value);
                    break;
                case ElementName.Address:
                    FillFieldTextBox("address", value);
                    break;
                case ElementName.Home:
                    FillFieldTextBox("home", value);
                    break;
                case ElementName.Work:
                    FillFieldTextBox("work", value);
                    break;
                case ElementName.Mobile:
                    FillFieldTextBox("mobile", value);
                    break;
                case ElementName.Fax:
                    FillFieldTextBox("fax", value);
                    break;
                case ElementName.Bday:
                    FillFieldSelect("bday", value);
                    break;
                case ElementName.Bmonth:
                    FillFieldSelect("bmonth", value);
                    break;
                case ElementName.Byear:
                    FillFieldTextBox("byear", value);
                    break;
                case ElementName.Aday:
                    FillFieldSelect("aday", value);
                    break;
                case ElementName.Amonth:
                    FillFieldSelect("amonth", value);
                    break;
                case ElementName.Ayear:
                    FillFieldTextBox("ayear", value);
                    break;
                case ElementName.Address2:
                    FillFieldTextBox("address2", value);
                    break;
                case ElementName.Phone2:
                    FillFieldTextBox("phone2", value);
                    break;
                case ElementName.Notes:
                    FillFieldTextBox("notes", value);
                    break;
                case ElementName.Email:
                    FillFieldTextBox("email", value);
                    break;
                case ElementName.Email2:
                    FillFieldTextBox("email2", value);
                    break;
                case ElementName.Email3:
                    FillFieldTextBox("email3", value);
                    break;
            }
        }
    }
}
