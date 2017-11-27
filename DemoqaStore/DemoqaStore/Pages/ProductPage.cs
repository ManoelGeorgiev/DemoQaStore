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
    class ProductPage : Page
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

        [FindsBy(How = How.ClassName, Using = "wpsc_buy_button")]
        public IWebElement AddToCartButton { get; set; }

        [FindsBy(How = How.ClassName, Using = "prodtitle")]
        public IWebElement ProductTitle { get; set; }

        public List<IWebElement> GetProductCategoryMenu()
        {
            var listOfElements = this.ProductCategoryMenuButton.FindElements(By.XPath("//ul/li/a"));

            return listOfElements.ToList<IWebElement>();

        }

        public static ProductPage NavigateTo(IWebDriver driver)
        {
            var productPageInstance = PageFactoryExtensions.InitPage<ProductPage>(driver);
            return productPageInstance;

        }

    }
}
