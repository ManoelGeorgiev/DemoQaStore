using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using DemoqaStore.Pages.Abstract;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace DemoqaStore.Pages
{
    class TransactionResults : Page
    {
        [FindsBy(How = How.ClassName, Using = "wpsc-purchase-log-transaction-results")]
        public IWebElement TransactionTableRoot { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".wpsc-purchase-log-transaction-results + p")]
        public IWebElement TotalPriceTextBox { get; set; }

        [FindsBy(How = How.ClassName, Using = "entry-title")]
        public IWebElement TransactionResultTextBox { get; set; }

        public int GetTotalShipping()
        {
            string rawTotalPriceText = this.TotalPriceTextBox.Text;
            Regex totalShippingPattern = new Regex(@"Total Shipping: $(<totalShipping>\d+)");
            Match totalShippingMatch = totalShippingPattern.Match(rawTotalPriceText);
            int totalShipping = int.Parse(totalShippingMatch.Groups["totalShipping"].Value);

            return totalShipping;
        }

        public int GetTotalPrice()
        {
            string rawTotalPriceText = this.TotalPriceTextBox.Text;
            Regex totalPricePattern = new Regex(@"$(<totalPrice>\d+){1}");
            Match totalPriceMatch = totalPricePattern.Match(rawTotalPriceText);
            int totalPrice = int.Parse(totalPriceMatch.Groups["totalPrice"].Value);

            return totalPrice;
        }

        public List<IWebElement> GetProductsName()
        {
            var productNames = this.TransactionTableRoot.FindElements(By.CssSelector(".wpsc-purchase-log-transaction-results > tbody > tr > td:first-of-type"));

            return productNames.ToList<IWebElement>();
        }

        public List<IWebElement> GetProductsPrice()
        {
            var listOfElements = this.TransactionTableRoot.FindElements(By.CssSelector(".wpsc-purchase-log-transaction-results > tbody > tr > td:first-of-type + td"));

            return listOfElements.ToList<IWebElement>();
        }

        public List<IWebElement> GetProductsQuantitie()
        {
            var listOfElements = this.TransactionTableRoot.FindElements(By.CssSelector(".wpsc-purchase-log-transaction-results > tbody > tr > td:first-of-type + td + td"));

            return listOfElements.ToList<IWebElement>();
        }

        public List<IWebElement> GetProductsItemTotal()
        {
            var listOfElements = this.TransactionTableRoot.FindElements(By.CssSelector(".wpsc-purchase-log-transaction-results > tbody > tr > td:first-of-type + td + td + td"));

            return listOfElements.ToList<IWebElement>();
        }
    }
}
