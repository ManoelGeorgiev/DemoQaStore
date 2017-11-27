using DemoqaStore.Helpers;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoqaStore.Tests.Abstract
{
        public abstract class SeleniumTestFixturePrototype
        {
            private int testRunnedWithCurentDriverInstance;

            public SeleniumTestFixturePrototype(Browsers browser)
            {
                this.Browser = browser;
            }

            protected Browsers Browser { get; private set; }

            protected IWebDriver Driver { get; private set; }

            protected WebDriverWait Wait { get; private set; }

            [SetUp]
            public void StartDriver()
            {
                testRunnedWithCurentDriverInstance = 1;
                switch (this.Browser)
                {
                    case Browsers.Firefox:
                        //FirefoxProfile firefoxProfile = new FirefoxProfile(); // comment out if you do not need firebug while debugging
                        //firefoxProfile.AddExtension(Settings.Default.FirebugPath);// comment out if you do not need firebug while debugging
                        // Avoid startup screen // comment out if you do not need firebug while debugging
                        //firefoxProfile.SetPreference("extensions.firebug.currentVersion", Settings.Default.FirebugVersion); // Avoid startup screen
                        //this.Driver = new FirefoxDriver(firefoxProfile); // remove firefox profile if you do not need firebug for debugging
                        this.Driver = new FirefoxDriver();
                        this.Driver.Manage().Window.Maximize();
                        break;
                    case Browsers.IE:
                        // bear in mind that IE9 has a memory leak, if testing against IE9 set TestsToRunOnSingleWebDriverInstance to 1 to prevent false-negatives due to OutOfMemoryException
                        int forcedWait = Settings.Default.ForcedWait;
                        System.Threading.Thread.Sleep(forcedWait); // gives closing browser frame some time
                        InternetExplorerOptions ieOptions = new InternetExplorerOptions();
                        ieOptions.EnableNativeEvents = true;
                        ieOptions.IgnoreZoomLevel = true;
                        ieOptions.RequireWindowFocus = false;
                        ieOptions.IntroduceInstabilityByIgnoringProtectedModeSettings = true;
                        TimeSpan ieOperationTimeout = new TimeSpan(days: 0, hours: 0, minutes: 10, seconds: 0);
                        this.Driver = new InternetExplorerDriver(Environment.CurrentDirectory, ieOptions, ieOperationTimeout);
                        this.Driver.Manage().Window.Maximize();
                        break;
                    // add android driver requires a virtual android machine to be running that has the selenium web driver installed and running on the virtual device
                    //case Browsers.Android:
                    //    this.Driver = new AndroidDriver();
                    //    break;
                    case Browsers.Chrome:
                        this.Driver = new ChromeDriver();
                        this.Driver.Manage().Window.Maximize();
                        break;
                    //HTML driver requires some additional steps to start, before adding it to your test fixture make shure to implement your own version of StartHtmlStandaloneServer(); which should start the htmlDriver standalone server on the current machine
                    //case Browsers.HtmlDriver:
                    //    this.StartHtmlStandaloneServer();
                    //    System.Threading.Thread.Sleep(Settings.Default.GlobalForcedWait);
                    //    this.Driver = new RemoteWebDriver(DesiredCapabilities.HtmlUnitWithJavaScript());
                    //    break;
                    default:
                        throw new Exception(string.Format("No testfixture setup steps have been implemented for {0} browser", this.Browser));
                }

                int testWaitTime = Settings.Default.TimeoutThreshold;
                this.Wait = new WebDriverWait(this.Driver, TimeSpan.FromMilliseconds(testWaitTime));
            }

            [SetUp]
            public void SetUp()
            {
                // if testing IE9 the lower the value for testsToRunOnSingleWebDriverInstance the better.
                // bear in mind that IE9 has a memory leak and can easily get unstable when interacting with tables
                int testsToRunOnSingleWebDriverInstance = Settings.Default.TestsToRunOnSingleWebDriverInstance;
                if (testsToRunOnSingleWebDriverInstance == 0)
                {
                    testsToRunOnSingleWebDriverInstance = 256; // better than infinite ?
                }
                if (testsToRunOnSingleWebDriverInstance < 0)
                {
                    throw new ArgumentException(string.Format("Settings.Default.TestsToRunOnSingleWebDriverInstance can not be lower than 0 (0 = 256 tests), current value :{0}", testsToRunOnSingleWebDriverInstance));
                }

                if (testRunnedWithCurentDriverInstance > testsToRunOnSingleWebDriverInstance)
                {
                    try
                    {
                        StopDriver();
                        StartDriver();
                    }
                    catch
                    {
                        // ignore errors if driver is unable to close window
                    }
                }
                testRunnedWithCurentDriverInstance++;
            }

            [TearDown]
            public void StopDriver()
            {
                this.Driver.Quit();
            }
        }

 }

