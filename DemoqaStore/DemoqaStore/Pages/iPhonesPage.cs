﻿using DemoqaStore.Helpers;
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
    public class IPhonesContainer
    {
        public IWebElement Root { get; set; }

        public IPhonesContainer(IWebElement root)
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

    public class iPhonesPage : Page
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

        public static iPhonesPage NavigateTo(IWebDriver driver)
        {
            var iPhonesPageInstance = YourAccountPage.NavigateTo(driver);

            var menuItems = iPhonesPageInstance.GetProductCategoryMenu();
            Actions action = new Actions(driver);
            action.MoveToElement(menuItems[1]).Perform();
            menuItems[5].Click();

            return PageFactoryExtensions.InitPage<iPhonesPage>(driver);
        }

        public List<IPhonesContainer> GetProducts()
        {
            var roots = this.ProductsContainer.FindElements(By.ClassName("iphones"));

            List<IPhonesContainer> products = new List<IPhonesContainer>();

            foreach (var rootElement in roots)
            {
                products.Add(new IPhonesContainer(rootElement));
            }

            return products;
        }
    }
}
