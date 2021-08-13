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
    public class ContactHelper : HelperBase
    {
        private FillFieldHelper fillFieldHelper;
        public ContactHelper(IWebDriver driver):base(driver)
        {
            this.fillFieldHelper = new FillFieldHelper(driver);
        }

        public void FillContactForm(ContactData _contact)
        {
            fillFieldHelper.FillFieldByName(ElementName.Firstname, _contact.Firstname);
            fillFieldHelper.FillFieldByName(ElementName.Lastname, _contact.Lastname);
            fillFieldHelper.FillFieldByName(ElementName.Middlename, _contact.Middlename);
            fillFieldHelper.FillFieldByName(ElementName.Nickname, _contact.Nickname);
            fillFieldHelper.FillFieldByName(ElementName.Title, _contact.Title);
            fillFieldHelper.FillFieldByName(ElementName.Company, _contact.Company);
            fillFieldHelper.FillFieldByName(ElementName.Address, _contact.Address);
            fillFieldHelper.FillFieldByName(ElementName.Home, _contact.Home);
            fillFieldHelper.FillFieldByName(ElementName.Fax, _contact.Fax);
            fillFieldHelper.FillFieldByName(ElementName.Mobile, _contact.Mobile);
            fillFieldHelper.FillFieldByName(ElementName.Work, _contact.Work);
            fillFieldHelper.FillFieldByName(ElementName.Bday, _contact.Bday);
            fillFieldHelper.FillFieldByName(ElementName.Bmonth, _contact.Bmonth);
            fillFieldHelper.FillFieldByName(ElementName.Byear, _contact.Byear);
            fillFieldHelper.FillFieldByName(ElementName.Aday, _contact.Aday);
            fillFieldHelper.FillFieldByName(ElementName.Amonth, _contact.Amonth);
            fillFieldHelper.FillFieldByName(ElementName.Ayear, _contact.Ayear);

            fillFieldHelper.FillFieldByName(ElementName.Address2, _contact.Address2);
            fillFieldHelper.FillFieldByName(ElementName.Phone2, _contact.Phone2);
            fillFieldHelper.FillFieldByName(ElementName.Notes, _contact.Notes);

            fillFieldHelper.FillFieldByName(ElementName.Email, _contact.Email);
            fillFieldHelper.FillFieldByName(ElementName.Email2, _contact.Email2);
            fillFieldHelper.FillFieldByName(ElementName.Email3, _contact.Email3);
        }
    }
}
