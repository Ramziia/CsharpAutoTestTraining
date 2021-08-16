using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace WebAddressbookTests
{
    public class ApplicationManager
    {
        protected IWebDriver driver;
        protected string baseURL;
        protected LoginHelper loginHelper;
        protected NavigationHelper navigationHelper;
        protected GroupHelper groupHelper;
        protected ContactHelper contactHelper;
        protected FillFieldHelper fillfield;
        private static ThreadLocal<ApplicationManager> app = new ThreadLocal<ApplicationManager>();

        public IWebDriver Driver
        {
            get
            {
                return driver;
            }
        }
        public string BaseURL
        {
            get
            {
                return baseURL;
            }
        }
        private ApplicationManager()
        {
            baseURL = "http://localhost/addressbook";
            driver = new FirefoxDriver();
            loginHelper = new LoginHelper(this);
            navigationHelper = new NavigationHelper(this);
            groupHelper = new GroupHelper(this);
            contactHelper = new ContactHelper(this);
            fillfield = new FillFieldHelper(this);
        }
        public static ApplicationManager GetInstance()
        {
            if(! app.IsValueCreated)
            {
                ApplicationManager newInstance = new ApplicationManager();
                app.Value = newInstance;
                app.Value.Navigator.GoToHomePage();
            }
            return app.Value;
        }

        public FillFieldHelper FillField
        {
            get
            {
                return fillfield;
            }
        }
        public LoginHelper Auth
        {
            get
            {
                return loginHelper;
            }
        }
        public NavigationHelper Navigator
        {
            get
            {
                return navigationHelper;
            }
        }
        public GroupHelper Groups
        {
            get
            {
                return groupHelper;
            }
        }
        public ContactHelper Contact
        {
            get
            {
                return contactHelper;
            }
        }
        ~ApplicationManager()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
        }
    }
}
