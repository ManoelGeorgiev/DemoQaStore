using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using DemoqaStore.Helpers;
using DemoqaStore.Pages.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace DemoqaStore.Pages
{
    public class ProductContainer
    {
        public IWebElement Root { get; set; }

        public ProductContainer(IWebElement root)
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


    class ProductCategoryPage : Page
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

        [FindsBy(How = How.ClassName, Using = "entry-content")]
        public IWebElement ProductsContainer { get; set; }

        [FindsBy(How = How.ClassName, Using = "count")]
        public IWebElement ProductCountTextBox { get; set; }


        public static ProductCategoryPage NavigateTo(IWebDriver driver)
        {
            var yourAccountPageInstance = YourAccountPage.NavigateTo(driver);
            yourAccountPageInstance.ProductCategoryMenuButton.Click();
            Thread.Sleep(3000);
            var productCategoryPageInstane = PageFactoryExtensions.InitPage<ProductCategoryPage>(driver);
            return productCategoryPageInstane;
        }

        public List<ProductContainer> GetProducts()
        {
            var roots = this.ProductsContainer.FindElements(By.ClassName("product-category"));

            List<ProductContainer> products = new List<ProductContainer>();

            foreach (var rootElement in roots)
            {
                products.Add(new ProductContainer(rootElement));
            }

            return products;
        }
    }
}
