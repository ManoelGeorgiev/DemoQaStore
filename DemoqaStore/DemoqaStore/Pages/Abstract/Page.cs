using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoqaStore.Pages.Abstract
{
    
        public abstract class Page
        {
        public static object GeneralSettings { get; private set; }
        IWebDriver Driver { get; set; }

            public static WebDriverWait GlobalWait(IWebDriver driver)
            {
                return new WebDriverWait(driver, TimeSpan.FromSeconds(Settings.Default.ForcedWait));
            }
        }
    
}
