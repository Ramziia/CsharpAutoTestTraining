using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactModificationTests : TestBase
    {
        [Test]
        public void ContactModifyTest()
        {
            app.Contact.Modify(new ContactData("ModFirstName", "ModLastName"),3);
        }
    }
}
