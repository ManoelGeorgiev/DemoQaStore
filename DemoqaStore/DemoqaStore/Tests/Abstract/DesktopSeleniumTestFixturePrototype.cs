using DemoqaStore.Helpers;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoqaStore.Tests.Abstract
{
    //[TestFixture(Browsers.Chrome)]
    [TestFixture(Browsers.Firefox)]

    class DesktopSeleniumTestFixturePrototype : SeleniumTestFixturePrototype
    {
        public DesktopSeleniumTestFixturePrototype(Browsers browser)
            : base(browser)
        {

        }
    }
}
