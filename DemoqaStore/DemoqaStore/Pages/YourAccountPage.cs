using DemoqaStore.Helpers;
using DemoqaStore.Pages.Abstract;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DemoqaStore.Pages
{





    public class MenuContainer
    {
        public IWebElement Root { get; set; }

        public MenuContainer(IWebElement root)
        {
            this.Root = root;
        }

        public IWebElement Accessories
        {
            get
            {
                return this.Root.FindElement(By.LinkText("Accessories"));
            }
        }

    }








    class YourAccountPage : Page
    {
        [FindsBy(How = How.LinkText, Using = ("Home"))]
        public IWebElement HomeMenuButton { get; set; }

        [FindsBy(How = How.LinkText, Using = ("Product Category"))]
        public IWebElement ProductCategoryMenuButton { get; set; }
        
        [FindsBy(How = How.LinkText, Using = ("All Product"))]
        public IWebElement AllProductsMenuButton { get; set; }

        [FindsBy(How = How.ClassName, Using = ("cart_icon"))]
        public IWebElement CheckoutButton { get; set; }

        [FindsBy(How = How.ClassName, Using = ("account_icon"))]
        public IWebElement MyAccountButton { get; set; }

        [FindsBy(How = How.ClassName, Using = "display-name")]
        public IWebElement UserNameTextBox { get; set; }


        [FindsBy(How = How.Id, Using = "main-nav")]
        public IWebElement MenuElement { get; set; }


        public List<IWebElement> GetProductCategoryMenu()
        {
            var listOfElements = this.ProductCategoryMenuButton.FindElements(By.XPath("//ul/li/a"));

            return listOfElements.ToList<IWebElement>();

        }


        public static YourAccountPage NavigateTo(IWebDriver driver)
        {
            var loginPageInstance = LoginPage.NavigateTo(driver);
            loginPageInstance.ValidLogIn();
            Thread.Sleep(3000);
            var yourAccountPageInstance = PageFactoryExtensions.InitPage<YourAccountPage>(driver);
            return yourAccountPageInstance;
        }







        public List<MenuContainer> GetMenu()
        {
            var roots = this.MenuElement.FindElements(By.ClassName("menu-item"));

            List<MenuContainer> products = new List<MenuContainer>();

            foreach (var rootElement in roots)
            {
                products.Add(new MenuContainer(rootElement));
            }

            return products;
        }





    }
    
}
