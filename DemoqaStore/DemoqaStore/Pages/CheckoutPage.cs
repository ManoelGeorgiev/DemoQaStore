using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using DemoqaStore.Pages.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using DemoqaStore.Helpers;

namespace DemoqaStore.Pages
{
    class CheckoutPage : Page
    {
        [FindsBy(How = How.ClassName, Using = "checkout_cart")]
        public IWebElement CheckOutCartRoot { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".step2 > span:nth-child(1)")]
        public IWebElement ContiniueButton { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".yourtotal > span:nth-child(1)")]
        public IWebElement SubTotalTextBox { get; set; }

        [FindsBy(How = How.ClassName, Using = "count")]
        public IWebElement ProductCountTextBox { get; set; }


        public int GetSubTotal()
        {
            string rawSubTotal = this.SubTotalTextBox.Text;
            string subTotalAsString = Regex.Match(rawSubTotal, @"\d+").Value;
            int subTotalAsInt = Convert.ToInt32(subTotalAsString);

            return subTotalAsInt;
        }


        public List<IWebElement> GetProductNames()
        {
            var productNames = this.CheckOutCartRoot.FindElements(By.CssSelector(".wpsc_product_name a"));

            return productNames.ToList<IWebElement>();
        }

        public List<IWebElement> GetQuantityTextBoxes()
        {
            var quantityTextBoxes = this.CheckOutCartRoot.FindElements(By.Name("quantity"));

            return quantityTextBoxes.ToList<IWebElement>();
        }

        public List<IWebElement> GetUpdateButtons()
        {
            var updateButtons = this.CheckOutCartRoot.FindElements(By.CssSelector("td:nth-child(3) > form > input:last-child"));

            return updateButtons.ToList<IWebElement>();
        }

        public List<IWebElement> GetPriceTextBoxes()
        {
            var priceTextBoxes = this.CheckOutCartRoot.FindElements(By.CssSelector("td:nth-child(4) > span:nth-child(1)"));

            return priceTextBoxes.ToList<IWebElement>();
        }

        public List<IWebElement> GetTotalTextBoxes()
        {
            var totalTextBoxes = this.CheckOutCartRoot.FindElements(By.CssSelector(".wpsc_product_price > span > span"));

            return totalTextBoxes.ToList<IWebElement>();
        }

        public List<IWebElement> GetRemoveButtons()
        {
            var removeButtons = this.CheckOutCartRoot.FindElements(By.CssSelector("td:nth-child(6) > form > input:last-child"));

            return removeButtons.ToList<IWebElement>();
        }

        public static CheckoutPage NavigateTo(IWebDriver driver)
        {
            var chechoutPageInstance = PageFactoryExtensions.InitPage<CheckoutPage>(driver);
            return chechoutPageInstance;

        }

    }
}
