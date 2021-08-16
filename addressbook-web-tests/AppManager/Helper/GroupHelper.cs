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
    public class GroupHelper:HelperBase
    {

        public GroupHelper(ApplicationManager manager):base(manager)
        {
        }
        public GroupHelper SubmitGroupPage()
        {
            driver.FindElement(By.Name("submit")).Click();
            return this;
        }

        public GroupHelper Modify(int index, GroupData groupData)
        {
            manager.Navigator.GoToGroupPage();
            if (! IsGroupExist(index))
            {
                Create(new GroupData("name"));
                index = 2;
                manager.Navigator.GoToGroupPage();
            }
            SelectGroup(index);
            InitGroupModification();
            FillGroupModification(groupData);
            SubmiteGroupModification();
            manager.Navigator.GoToGroupPage();
            return this;
        }
        public GroupHelper Remove(int index)
        {
            manager.Navigator.GoToGroupPage();
            if (! IsGroupExist(index))
            {
                Create(new GroupData("name"));
                index = 2;
                manager.Navigator.GoToGroupPage();
            }
            SelectGroup(index);
            RemoveGroup();
            manager.Navigator.GoToGroupPage();
            return this;
        }
        private bool IsGroupExist(int index)
        {
            return IsElementPresent(By.XPath("//div[@id='content']/form/span[" + index + "]/input"));
        }
        public GroupHelper Create(GroupData groupData)
        {
            manager.Navigator.GoToGroupPage();
            InitGroupCreation();
            FillGroupCreation(groupData);
            SubmitGroupPage();
            manager.Navigator
                .GoToGroupPage();
            return this;
        }
        public GroupHelper SubmiteGroupModification()
        {
            driver.FindElement(By.Name("update")).Click();
            return this;
        }

        public GroupHelper FillGroupModification(GroupData groupdata)
        {
            FillGroup(groupdata);
            return this;
        }

        public GroupHelper InitGroupModification()
        {
            driver.FindElement(By.Name("edit")).Click();
            return this;
        }
        public GroupHelper FillGroup(GroupData groupdata)
        {
            manager.FillField.FillField(By.Name("group_name"), groupdata.Name);
            manager.FillField.FillField(By.Name("group_header"), groupdata.Header);
            manager.FillField.FillField(By.Name("group_footer"), groupdata.Footer);
            return this;
        }
        public GroupHelper FillGroupCreation(GroupData groupdata)
        {
            FillGroup(groupdata);
            return this;
        }
        public GroupHelper InitGroupCreation()
        {
            driver.FindElement(By.Name("new")).Click();
            return this;
        }
        public GroupHelper RemoveGroup()
        {
            driver.FindElement(By.Name("delete")).Click();
            return this;
        }
        public GroupHelper SelectGroup(int index)
        {
            driver.FindElement(By.XPath("//div[@id='content']/form/span[" + index + "]/input")).Click();
            return this;
        }

    }
}
