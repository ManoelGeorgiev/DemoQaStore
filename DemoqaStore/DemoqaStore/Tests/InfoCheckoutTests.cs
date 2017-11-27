using DemoqaStore.Helpers;
using DemoqaStore.Pages;
using DemoqaStore.Tests.Abstract;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Interactions.Internal;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace DemoqaStore.Tests
{
    class InfoCheckoutTests : DesktopSeleniumTestFixturePrototype
    {
        public InfoCheckoutTests(Browsers browser) : base(browser)
        { }

        [Test]
        public void SubTotalAndItemCostTest()
        {
            //navingating to product category page and buying all the products on that page
            var testInstance = ProductCategoryPage.NavigateTo(base.Driver);
            var products = testInstance.GetProducts();
            for (var i = 0; i < products.Count(); i++)
            {
                products[i].AddToCartButton.Click();
                Thread.Sleep(2000);
            }
            Thread.Sleep(5000);

            //navigating to chechout page and getting the sub total price
            testInstance.CheckoutButton.Click();
            var checkOutPageInstance = PageFactoryExtensions.InitPage<CheckoutPage>(Driver);
            Thread.Sleep(4000);
            int subTotalPriceFromCheckoutPage = checkOutPageInstance.GetSubTotal();

            //navigating to Info page and comparing sub total price from Your Cart page with Item Cost from Info page
            checkOutPageInstance.ContiniueButton.Click();
            var checkoutInfoPageInstance = PageFactoryExtensions.InitPage<CheckoutInfoPage>(Driver);
            Thread.Sleep(4000);
            int itemCostFromInfoPage = checkoutInfoPageInstance.GetItemCost();

            Assert.AreEqual(subTotalPriceFromCheckoutPage, itemCostFromInfoPage);
        }

        [Test]
        public void ReviewAndPurchaseTotalPriceTest()
        {
            //navingating to product category page and buying all the products on that page
            var testInstance = ProductCategoryPage.NavigateTo(base.Driver);
            var products = testInstance.GetProducts();
            for (var i = 0; i < products.Count(); i++)
            {
                products[i].AddToCartButton.Click();
                Thread.Sleep(2000);
            }
            Thread.Sleep(5000);

            //navigating to chechout page
            testInstance.CheckoutButton.Click();
            var checkOutPageInstance = PageFactoryExtensions.InitPage<CheckoutPage>(Driver);
            Thread.Sleep(4000);
            
            //navigating to Info page and comparing the sum of Total Shipping + Item Cost + Tax with the Total Price
            checkOutPageInstance.ContiniueButton.Click();
            var checkoutInfoPageInstance = PageFactoryExtensions.InitPage<CheckoutInfoPage>(Driver);
            Thread.Sleep(4000);
            int itemCostFromInfoPage = checkoutInfoPageInstance.GetItemCost();
            int totalPrice = checkoutInfoPageInstance.GetTotalPrice();
            int totalShipping = checkoutInfoPageInstance.GetTotalShipping();
            int totalTax = checkoutInfoPageInstance.GetTotalTax();
            int totalSum = itemCostFromInfoPage + totalShipping + totalTax;

            Assert.AreEqual(totalSum, totalPrice);
        }

    }
}
