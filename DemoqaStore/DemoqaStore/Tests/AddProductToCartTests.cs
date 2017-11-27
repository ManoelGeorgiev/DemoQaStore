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
using System.Threading;
using System.Threading.Tasks;

namespace DemoqaStore.Tests
{
    class AddProductToCartTests : DesktopSeleniumTestFixturePrototype
    {
        public AddProductToCartTests(Browsers browser) : base(browser)
        { }

      


        [Test]
        public void BuyingProductsFromProductCategoryTest()
        {
            //adding to cart products from Product Category Page
            var testInstance = ProductCategoryPage.NavigateTo(base.Driver);
            var products = testInstance.GetProducts();
            for (var i = 0; i < products.Count(); i++)
            {
                products[i].AddToCartButton.Click();
                Thread.Sleep(2000);
            }
            Thread.Sleep(5000);

            //comparing the number of added products with the number in products in cart
            var countAsAString = testInstance.ProductCountTextBox.Text;
            var countAsAnInteger = Convert.ToInt32(countAsAString);
            Assert.AreEqual(products.Count(), countAsAnInteger);

            //navigating to Checkout Your cart page
            testInstance.CheckoutButton.Click();
            var checkOutPageInstance = PageFactoryExtensions.InitPage<CheckoutPage>(Driver);
            Thread.Sleep(4000);

            //navigating to Checkout Info page
            checkOutPageInstance.ContiniueButton.Click();
            var checkoutInfoPageInstance = PageFactoryExtensions.InitPage<CheckoutInfoPage>(Driver);
            Thread.Sleep(4000);

            //navigating to Checkout Final page and testing if we are there
            checkoutInfoPageInstance.PurchaseButton.Click();
            var checkoutFinalPageInstance = PageFactoryExtensions.InitPage<TransactionResults>(Driver);
            Thread.Sleep(4000);
            string transactionResultText = checkoutFinalPageInstance.TransactionResultTextBox.Text;
            Assert.AreEqual("Transaction Results", transactionResultText);



        }

        [Test]
        public void BuyingProductsFromAccessoriesPageTest()
        {
            //adding to cart products from Accessories Page
            var testInstance = AccessoriesPage.NavigateTo(base.Driver);
            var products = testInstance.GetProducts();
            for (var i = 0; i < products.Count(); i++)
            {
                products[i].AddToCartButton.Click();
                Thread.Sleep(2000);
            }
            Thread.Sleep(5000);

            //comparing the number of added products with the number in products in cart
            var countAsAString = testInstance.ProductCountTextBox.Text;
            var countAsAnInteger = Convert.ToInt32(countAsAString);
            Assert.AreEqual(products.Count(), countAsAnInteger);

            //navigating to Checkout Your cart page
            testInstance.CheckoutButton.Click();
            var checkOutPageInstance = PageFactoryExtensions.InitPage<CheckoutPage>(Driver);
            Thread.Sleep(4000);

            //navigating to Checkout Info page
            checkOutPageInstance.ContiniueButton.Click();
            var checkoutInfoPageInstance = PageFactoryExtensions.InitPage<CheckoutInfoPage>(Driver);
            Thread.Sleep(4000);

            //navigating to Checkout Final page and testing if we are there
            checkoutInfoPageInstance.PurchaseButton.Click();
            var checkoutFinalPageInstance = PageFactoryExtensions.InitPage<TransactionResults>(Driver);
            Thread.Sleep(4000);
            string transactionResultText = checkoutFinalPageInstance.TransactionResultTextBox.Text;
            Assert.AreEqual("Transaction Results", transactionResultText);
        }

        [Test]
        public void BuyingProductsFromiMacsPageTest()
        {
            //adding to cart products from iMacs Page
            var testInstance = iMacsPage.NavigateTo(base.Driver);
            var products = testInstance.GetProducts();
            for (var i = 0; i < products.Count(); i++)
            {
                products[i].AddToCartButton.Click();
                Thread.Sleep(2000);
            }
            Thread.Sleep(5000);

            //comparing the number of added products with the number in products in cart
            var countAsAString = testInstance.ProductCountTextBox.Text;
            var countAsAnInteger = Convert.ToInt32(countAsAString);
            Assert.AreEqual(products.Count(), countAsAnInteger);

            //navigating to Checkout Your cart page
            testInstance.CheckoutButton.Click();
            var checkOutPageInstance = PageFactoryExtensions.InitPage<CheckoutPage>(Driver);
            Thread.Sleep(4000);

            //navigating to Checkout Info page
            checkOutPageInstance.ContiniueButton.Click();
            var checkoutInfoPageInstance = PageFactoryExtensions.InitPage<CheckoutInfoPage>(Driver);
            Thread.Sleep(4000);

            //navigating to Checkout Final page and testing if we are there
            checkoutInfoPageInstance.PurchaseButton.Click();
            var checkoutFinalPageInstance = PageFactoryExtensions.InitPage<TransactionResults>(Driver);
            Thread.Sleep(4000);
            string transactionResultText = checkoutFinalPageInstance.TransactionResultTextBox.Text;
            Assert.AreEqual("Transaction Results", transactionResultText);
        }

        [Test]
        public void BuyingProductsFromiPadsPageTest()
        {
            //adding to cart products from iPads Page
            var testInstance = iPadsPage.NavigateTo(base.Driver);
            var products = testInstance.GetProducts();
            for (var i = 0; i < products.Count(); i++)
            {
                products[i].AddToCartButton.Click();
                Thread.Sleep(2000);
            }
            Thread.Sleep(5000);

            //comparing the number of added products with the number in products in cart
            var countAsAString = testInstance.ProductCountTextBox.Text;
            var countAsAnInteger = Convert.ToInt32(countAsAString);
            Assert.AreEqual(products.Count(), countAsAnInteger);

            //navigating to Checkout Your cart page
            testInstance.CheckoutButton.Click();
            var checkOutPageInstance = PageFactoryExtensions.InitPage<CheckoutPage>(Driver);
            Thread.Sleep(4000);

            //navigating to Checkout Info page
            checkOutPageInstance.ContiniueButton.Click();
            var checkoutInfoPageInstance = PageFactoryExtensions.InitPage<CheckoutInfoPage>(Driver);
            Thread.Sleep(4000);

            //navigating to Checkout Final page and testing if we are there
            checkoutInfoPageInstance.PurchaseButton.Click();
            var checkoutFinalPageInstance = PageFactoryExtensions.InitPage<TransactionResults>(Driver);
            Thread.Sleep(4000);
            string transactionResultText = checkoutFinalPageInstance.TransactionResultTextBox.Text;
            Assert.AreEqual("Transaction Results", transactionResultText);
        }

        [Test]
        public void BuyingProductsFromiPhonesPageTest()
        {
            //adding to cart products from iPhones Page
            var testInstance = iPhonesPage.NavigateTo(base.Driver);
            var products = testInstance.GetProducts();
            for (var i = 0; i < products.Count(); i++)
            {
                products[i].AddToCartButton.Click();
                Thread.Sleep(2000);
            }
            Thread.Sleep(5000);

            //comparing the number of added products with the number in products in cart
            var countAsAString = testInstance.ProductCountTextBox.Text;
            var countAsAnInteger = Convert.ToInt32(countAsAString);
            Assert.AreEqual(products.Count(), countAsAnInteger);

            //navigating to Checkout Your cart page
            testInstance.CheckoutButton.Click();
            var checkOutPageInstance = PageFactoryExtensions.InitPage<CheckoutPage>(Driver);
            Thread.Sleep(4000);

            //navigating to Checkout Info page
            checkOutPageInstance.ContiniueButton.Click();
            var checkoutInfoPageInstance = PageFactoryExtensions.InitPage<CheckoutInfoPage>(Driver);
            Thread.Sleep(4000);

            //navigating to Checkout Final page and testing if we are there
            checkoutInfoPageInstance.PurchaseButton.Click();
            var checkoutFinalPageInstance = PageFactoryExtensions.InitPage<TransactionResults>(Driver);
            Thread.Sleep(4000);
            string transactionResultText = checkoutFinalPageInstance.TransactionResultTextBox.Text;
            Assert.AreEqual("Transaction Results", transactionResultText);
        }

        [Test]
        public void BuyingProductsFromiPodsPageTest()
        {
            //adding to cart products from iPods Page
            var testInstance = iPodsPage.NavigateTo(base.Driver);
            var products = testInstance.GetProducts();
            for (var i = 0; i < products.Count(); i++)
            {
                products[i].AddToCartButton.Click();
                Thread.Sleep(2000);
            }
            Thread.Sleep(5000);

            //comparing the number of added products with the number in products in cart
            var countAsAString = testInstance.ProductCountTextBox.Text;
            var countAsAnInteger = Convert.ToInt32(countAsAString);
            Assert.AreEqual(products.Count(), countAsAnInteger);

            //navigating to Checkout Your cart page
            testInstance.CheckoutButton.Click();
            var checkOutPageInstance = PageFactoryExtensions.InitPage<CheckoutPage>(Driver);
            Thread.Sleep(4000);

            //navigating to Checkout Info page
            checkOutPageInstance.ContiniueButton.Click();
            var checkoutInfoPageInstance = PageFactoryExtensions.InitPage<CheckoutInfoPage>(Driver);
            Thread.Sleep(4000);

            //navigating to Checkout Final page and testing if we are there
            checkoutInfoPageInstance.PurchaseButton.Click();
            var checkoutFinalPageInstance = PageFactoryExtensions.InitPage<TransactionResults>(Driver);
            Thread.Sleep(4000);
            string transactionResultText = checkoutFinalPageInstance.TransactionResultTextBox.Text;
            Assert.AreEqual("Transaction Results", transactionResultText);
        }

        [Test]
        public void BuyingProductsFromMacBooksPageTest()
        {
            //adding to cart products from Mac Books Page
            var testInstance = MacBooksPage.NavigateTo(base.Driver);
            var products = testInstance.GetProducts();
            for (var i = 0; i < products.Count(); i++)
            {
                products[i].AddToCartButton.Click();
                Thread.Sleep(2000);
            }
            Thread.Sleep(5000);

            //comparing the number of added products with the number in products in cart
            var countAsAString = testInstance.ProductCountTextBox.Text;
            var countAsAnInteger = Convert.ToInt32(countAsAString);
            Assert.AreEqual(products.Count(), countAsAnInteger);

            //navigating to Checkout Your cart page
            testInstance.CheckoutButton.Click();
            var checkOutPageInstance = PageFactoryExtensions.InitPage<CheckoutPage>(Driver);
            Thread.Sleep(4000);

            //navigating to Checkout Info page
            checkOutPageInstance.ContiniueButton.Click();
            var checkoutInfoPageInstance = PageFactoryExtensions.InitPage<CheckoutInfoPage>(Driver);
            Thread.Sleep(4000);

            //navigating to Checkout Final page and testing if we are there
            checkoutInfoPageInstance.PurchaseButton.Click();
            var checkoutFinalPageInstance = PageFactoryExtensions.InitPage<TransactionResults>(Driver);
            Thread.Sleep(4000);
            string transactionResultText = checkoutFinalPageInstance.TransactionResultTextBox.Text;
            Assert.AreEqual("Transaction Results", transactionResultText);
        }
    }
}
