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
    public class GroupHelper
    {
        private IWebDriver driver;
        private FillFieldHelper fillFieldHelper;

        public GroupHelper(IWebDriver driver)
        {
            this.driver = driver;
            this.fillFieldHelper = new FillFieldHelper(driver);
        }
        public void SubmitGroupPage()
        {
            driver.FindElement(By.Name("submit")).Click();
        }
        public void FillGroupCreation(GroupData groupdata)
        {
            fillFieldHelper.FillField("group_name", groupdata.Name);
            fillFieldHelper.FillField("group_header", groupdata.Header);
            fillFieldHelper.FillField("group_footer", groupdata.Footer);
        }
        public void InitGroupCreation()
        {
            driver.FindElement(By.Name("new")).Click();
        }
        public void RemoveGroup()
        {
            driver.FindElement(By.Name("delete")).Click();
        }
        public void SelectGroup(int index)
        {
            driver.FindElement(By.XPath("//div[@id='content']/form/span[" + index + "]/input")).Click();
        }
    }
}
