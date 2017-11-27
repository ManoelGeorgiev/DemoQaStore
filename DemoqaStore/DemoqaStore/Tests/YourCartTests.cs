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
    class YourCartTests : DesktopSeleniumTestFixturePrototype
    {

        public YourCartTests(Browsers browser) : base(browser)
        { }




        [Test]
        public void ProductInformationTest()
        {
            //navigating to product category page and buying an item
            var testInstance = ProductCategoryPage.NavigateTo(base.Driver);
            var products = testInstance.GetProducts();
            products[0].AddToCartButton.Click();
            Thread.Sleep(5000);

            //navigating to checkout page
            testInstance.CheckoutButton.Click();
            var checkOutPageInstance = PageFactoryExtensions.InitPage<CheckoutPage>(Driver);
            Thread.Sleep(4000);

            //getting product title and clicking on it
            var productTitleCheckout = checkOutPageInstance.GetProductNames();
            string productTitleTextChechout = productTitleCheckout[0].Text;
            productTitleCheckout[0].Click();

            //navigating to product page and comparing its title to the title of the product that we got in the checkout
            var productPageInstance = PageFactoryExtensions.InitPage<ProductPage>(Driver);
            Thread.Sleep(2000);
            var productTitle = productPageInstance.ProductTitle;
            string productTitleText = productTitle.Text;
            Assert.AreEqual(productTitleTextChechout, productTitleText);
        }


        [Test]
        public void QuantityUpdateTest()
        {
            //navigating to product category page and buying an item
            var testInstance = ProductCategoryPage.NavigateTo(base.Driver);
            var products = testInstance.GetProducts();

            products[0].AddToCartButton.Click();

            Thread.Sleep(5000);
            //navigating to checkout page
            testInstance.CheckoutButton.Click();
            var checkOutPageInstance = PageFactoryExtensions.InitPage<CheckoutPage>(Driver);
            Thread.Sleep(4000);

            //getting chechout quantity text box and update button
            var productQuantityTextbox = checkOutPageInstance.GetQuantityTextBoxes();
            var productUpdateButton = checkOutPageInstance.GetUpdateButtons();

            //changing quantity to 2
            productQuantityTextbox[0].Clear();
            productQuantityTextbox[0].SendKeys("2");
            Thread.Sleep(2000);

            //updating quantity
            productUpdateButton[0].Click();
            var checkOutPageInstanceTwo = PageFactoryExtensions.InitPage<CheckoutPage>(Driver);
            Thread.Sleep(2000);

            //getting quantity again and comparing it to the quantity we set
            var productQuantityTextboxTwo = checkOutPageInstanceTwo.GetQuantityTextBoxes();
            string quantityOfProducts = productQuantityTextboxTwo[0].Value();
            Assert.AreEqual("2", quantityOfProducts);
        }

        [Test]
        public void RemovingProductsFromChechoutTest()
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

            //navigating to chechout page and removeing all products
            testInstance.CheckoutButton.Click();

            for (var i = 0; i < products.Count(); i++)
            {
                var checkOutPageInstance = PageFactoryExtensions.InitPage<CheckoutPage>(Driver);
                Thread.Sleep(4000);
                var productsRemoval = checkOutPageInstance.GetRemoveButtons();
                productsRemoval[0].Click();
            }
            Thread.Sleep(4000);

            //testing if the cart is empty
            var checkOutPageInstanceTwo = PageFactoryExtensions.InitPage<CheckoutPage>(Driver);
            var countAsAString = checkOutPageInstanceTwo.ProductCountTextBox.Text;
            Assert.AreEqual("0", countAsAString);
        }

        [Test]
        public void SubTotalPriceTest()
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

            //getting total price calculation of all items in checkout
            var totalPrice = checkOutPageInstance.GetTotalTextBoxes();
            int totalPriceOfProducts = 0;

            for (int i = 0; i < totalPrice.Count(); i++)
            {
                string rawPrice = totalPrice[i].Text;
                string priceAsString = Regex.Match(rawPrice, @"\d+").Value;
                int priceAsInt = Convert.ToInt32(priceAsString);

                totalPriceOfProducts += priceAsInt;

            }

            //getting sub total price and comparing it to the combine total price of all products in the cart
            int subTotalPriceFromCheckoutPage = checkOutPageInstance.GetSubTotal();

            Assert.AreEqual(totalPriceOfProducts, subTotalPriceFromCheckoutPage);

          
        }
    }
}
