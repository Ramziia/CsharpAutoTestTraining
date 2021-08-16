using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace WebAddressbookTests
{ 
    [TestFixture]
    public class GroupCreationTests : TestBase
    {
        [Test]
        public void GroupCreatTest()
        {
            app.Groups.Create(new GroupData("qweName", "qweHeader", "qweFooter"));
        }
        [Test]
        public void GroupCreatTestEmpty()
        {
            app.Groups.Create(new GroupData("", "", ""));
        }
    }
}


