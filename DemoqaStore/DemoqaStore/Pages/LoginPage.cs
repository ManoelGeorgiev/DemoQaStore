using DemoqaStore.Helpers;
using DemoqaStore.Pages.Abstract;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoqaStore.Pages
{
    public class LoginPage : Page
    {
        [FindsBy(How = How.LinkText, Using = "Home")]
        public IWebElement HomeMenuButton { get; set; }

        [FindsBy(How = How.LinkText, Using = "Product Category")]
        public IWebElement ProductCategoryMenuPage { get; set; }

        [FindsBy(How = How.LinkText, Using = "All Product")]
        public IWebElement AllProductMenuButton { get; set; }

        [FindsBy(How = How.Id, Using = "log")]
        public IWebElement UserNameTextBox { get; set; }

        [FindsBy(How = How.Id, Using = "pwd")]
        public IWebElement PasswordTextBox { get; set; }

        [FindsBy(How = How.Id, Using = "login")]
        public IWebElement LoginButton { get; set; }

        public static string Path { get { return "/products-page/your-account/"; } }

        public static LoginPage NavigateTo(IWebDriver driver)
        {
            string baseURL = Settings.Default.BaseURL;
            driver.Navigate().GoToUrl(baseURL);

            if (driver.Manage().Cookies.AllCookies.Any())
            {
                driver.Manage().Cookies.DeleteAllCookies();
                driver.Navigate().GoToUrl(baseURL);
            }

            driver.Navigate().GoToUrl(baseURL + Path);

            var loginPageInstance = PageFactoryExtensions.InitPage<LoginPage>(driver);

            //Page.GlobalWait(driver).Until(d => driver.FindElements(By.Id("lfootercc")).Any());

            return loginPageInstance;
        }

        public void ValidLogIn()
        {
            this.UserNameTextBox.SendKeys(Settings.Default.UserName);
            this.PasswordTextBox.SendKeys(Settings.Default.Password);
            this.LoginButton.Click();

            // added because of firefox rushing
            System.Threading.Thread.Sleep(3000);
        }

        public void LogIn(string username, string password)
        {
            this.UserNameTextBox.SendKeys(username);
            this.PasswordTextBox.SendKeys(password);
        }
    }
}
