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
    public class MacBooksContainer
    {
        public IWebElement Root { get; set; }

        public MacBooksContainer(IWebElement root)
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

    public class MacBooksPage : Page
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

        public static MacBooksPage NavigateTo(IWebDriver driver)
        {
            var macBooksPageInstance = YourAccountPage.NavigateTo(driver);

            var menuItems = macBooksPageInstance.GetProductCategoryMenu();
            Actions action = new Actions(driver);
            action.MoveToElement(menuItems[1]).Perform();
            menuItems[7].Click();

            return PageFactoryExtensions.InitPage<MacBooksPage>(driver);
        }

        public List<MacBooksContainer> GetProducts()
        {
            var roots = this.ProductsContainer.FindElements(By.ClassName("macbooks"));

            List<MacBooksContainer> products = new List<MacBooksContainer>();

            foreach (var rootElement in roots)
            {
                products.Add(new MacBooksContainer(rootElement));
            }

            return products;
        }
    }
}
