using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System.Threading;

namespace WebAddressbookTests
{
    public class ContactHelper : HelperBase
    {
        public ContactHelper(ApplicationManager manager):base(manager)
        {}
        public ContactHelper Modify(ContactData contactDataDiff, int index)
        {
            if(! IsContactExist(index))
            {
                Create(new ContactData("q", "w"));
                manager.Navigator.GoToHomePage();
                index = 2;
            }
            EditContact(index);
            FillContactForm(contactDataDiff);
            SubmiteGroupUpdate();
            manager.Navigator.GoToHomePage();
            return this;
        }

        private bool IsContactExist(int index)
        {
            return IsElementPresent(By.XPath("//table[@id='maintable']/tbody/tr[" + index + "]/td/input"));
        }

        public ContactHelper Remove(int index)
        {
            if (!IsContactExist(index))
            {
                Create(new ContactData("q", "w"));
                manager.Navigator.GoToHomePage();
                index = 2;
            }
            SelectContact(index);
            SubmiteGroupDeletion();
            CloseDialogWindowSureDelete();
            manager.Navigator.GoToHomePage();
            return this;
        }
        public ContactHelper Create(ContactData contactdata)
        {
            manager.Navigator.GoToAddNewPage();
            FillContactForm(contactdata);
            manager.Navigator
                .GoToHomePage();
            return this;
        }
        public ContactHelper SubmiteGroupDeletion()
        {
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
            return this;
        }
        public ContactHelper SubmiteGroupUpdate()
        {
            driver.FindElement(By.Name("update")).Click();
            return this;
        }
        private void CloseDialogWindowSureDelete()
        {
            driver.SwitchTo().Alert().Accept(); 
        }
        private void EditContact(int index_table)
        {
            Thread.Sleep(4000);
            driver.FindElement(By.XPath("//table[@id='maintable']/tbody/tr[" + index_table + "]/td[8]/a/img")).Click();
        }
        private void SelectContact(int index_table)
        {
            driver.FindElement(By.XPath("//table[@id='maintable']/tbody/tr["+ index_table + "]/td/input")).Click();
        }
        public void FillContactForm(ContactData _contact)
        {
            manager.FillField.FillFieldByName(ElementName.Firstname, _contact.Firstname);
            manager.FillField.FillFieldByName(ElementName.Lastname, _contact.Lastname);
            manager.FillField.FillFieldByName(ElementName.Middlename, _contact.Middlename);
            manager.FillField.FillFieldByName(ElementName.Nickname, _contact.Nickname);
            manager.FillField.FillFieldByName(ElementName.Title, _contact.Title);
            manager.FillField.FillFieldByName(ElementName.Company, _contact.Company);
            manager.FillField.FillFieldByName(ElementName.Address, _contact.Address);
            manager.FillField.FillFieldByName(ElementName.Home, _contact.Home);
            manager.FillField.FillFieldByName(ElementName.Fax, _contact.Fax);
            manager.FillField.FillFieldByName(ElementName.Mobile, _contact.Mobile);
            manager.FillField.FillFieldByName(ElementName.Work, _contact.Work);
            manager.FillField.FillFieldByName(ElementName.Bday, _contact.Bday);
            manager.FillField.FillFieldByName(ElementName.Bmonth, _contact.Bmonth);
            manager.FillField.FillFieldByName(ElementName.Byear, _contact.Byear);
            manager.FillField.FillFieldByName(ElementName.Aday, _contact.Aday);
            manager.FillField.FillFieldByName(ElementName.Amonth, _contact.Amonth);
            manager.FillField.FillFieldByName(ElementName.Ayear, _contact.Ayear);

            manager.FillField.FillFieldByName(ElementName.Address2, _contact.Address2);
            manager.FillField.FillFieldByName(ElementName.Phone2, _contact.Phone2);
            manager.FillField.FillFieldByName(ElementName.Notes, _contact.Notes);

            manager.FillField.FillFieldByName(ElementName.Email, _contact.Email);
            manager.FillField.FillFieldByName(ElementName.Email2, _contact.Email2);
            manager.FillField.FillFieldByName(ElementName.Email3, _contact.Email3);
        }
    }
}
