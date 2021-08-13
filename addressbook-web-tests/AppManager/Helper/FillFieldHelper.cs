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
    public class FillFieldHelper : HelperBase
    {
        public FillFieldHelper(IWebDriver driver):base(driver) {}
        public void FillField(string name_of_element, string value)
        {
            driver.FindElement(By.Name(name_of_element)).Click();
            driver.FindElement(By.Name(name_of_element)).Clear();
            driver.FindElement(By.Name(name_of_element)).SendKeys(value);
        }
        public void FillFieldSelect(string name, string value)
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
        public void FillFieldByName(ElementName elementname, string value)
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
