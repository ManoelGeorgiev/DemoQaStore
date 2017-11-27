using DemoqaStore.Helpers;
using DemoqaStore.Pages.Abstract;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoqaStore.Pages
{
    public class AccessoriesContainer
    {
        public IWebElement Root { get; set; }

        public AccessoriesContainer(IWebElement root)
        {
            this.Root = root;
        }

        public IWebElement PriceTextBox
        {
            get
            {
                return this.Root.FindElement(By.ClassName("currentprice"));
            }
        }

        public IWebElement ProductTitleTextBox
        {
            get
            {
                return this.Root.FindElement(By.ClassName("wpsc_product_title"));
            }
        }

        public IWebElement AddToCartButton
        {
            get
            {
                return this.Root.FindElement(By.ClassName("wpsc_buy_button"));
            }
        }
    }

    public class AccessoriesPage : Page
    {
        [FindsBy(How = How.LinkText, Using = "Home")]
        public IWebElement HomeMenuButton { get; set; }

        [FindsBy(How = How.LinkText, Using = "Product Category")]
        public IWebElement ProductCategoryMenuButton { get; set; }

        [FindsBy(How = How.LinkText, Using = "All Product")]
        public IWebElement AllProductMenuButton { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#account a")]
        public IWebElement MyAccountButton { get; set; }

        [FindsBy(How = How.ClassName, Using = "entry-content")]
        public IWebElement ProductsContainer { get; set; }

        [FindsBy(How = How.ClassName, Using = "count")]
        public IWebElement ProductCountTextBox { get; set; }

        [FindsBy(How = How.ClassName, Using = "cart_icon")]
        public IWebElement CheckoutButton { get; set; }

        public List<IWebElement> GetProductCategoryMenu()
        {
            var listOfElements = this.ProductCategoryMenuButton.FindElements(By.XPath("//ul/li/a"));

            return listOfElements.ToList<IWebElement>();

        }

        public static AccessoriesPage NavigateTo(IWebDriver driver)
        {
            var accessoriesPageInstance = YourAccountPage.NavigateTo(driver);
            
            var menuItems = accessoriesPageInstance.GetProductCategoryMenu();
            Actions action = new Actions(driver);
            action.MoveToElement(menuItems[1]).Perform();
            menuItems[2].Click();

            return PageFactoryExtensions.InitPage<AccessoriesPage>(driver);
        }

        public List<AccessoriesContainer> GetProducts()
        {
            var roots = this.ProductsContainer.FindElements(By.ClassName("accessories"));

            List<AccessoriesContainer> products = new List<AccessoriesContainer>();

            foreach (var rootElement in roots)
            {
                products.Add(new AccessoriesContainer(rootElement));
            }

            return products;
        }
    }
}
