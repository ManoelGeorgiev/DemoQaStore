using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using DemoqaStore.Pages.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DemoqaStore.Pages
{
    class CheckoutInfoPage : Page
    {
        [FindsBy(How = How.Id, Using = "current_country")]
        public IWebElement ShippingPriceCountrySelectRoot { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#uniform-current_country + input.shipping_region")]
        public IWebElement ShippingStateTextBox { get; set; }

        [FindsBy(How = How.Name, Using = "wpsc_submit_zipcode")]
        public IWebElement CalculateButton { get; set; }

        [FindsBy(How = How.Id, Using = "wpsc_checkout_form_9")]
        public IWebElement EmailTextBox { get; set; }

        [FindsBy(How = How.Id, Using = "wpsc_checkout_form_2")]
        public IWebElement CustomerInformationFirstNameTextBox { get; set; }

        [FindsBy(How = How.ClassName, Using = "wpsc_checkout_form_3")]
        public IWebElement CustomerInformationLastNameTextBox { get; set; }

        [FindsBy(How = How.Id, Using = "wpsc_checkout_form_4")]
        public IWebElement CustomerInformationAdressTextBox { get; set; }

        [FindsBy(How = How.Id, Using = "wpsc_checkout_form_5")]
        public IWebElement CustomerInformationCityTextBox { get; set; }

        [FindsBy(How = How.Id, Using = "wpsc_checkout_form_6")]
        public IWebElement CustomerInformationStateTextBox { get; set; }

        [FindsBy(How = How.Id, Using = "wpsc_checkout_form_7")]
        public IWebElement CustomerInformationCountrySelectRoot { get; set; }

        [FindsBy(How = How.Id, Using = "wpsc_checkout_form_8")]
        public IWebElement CustomerInformationPostalCodeTextBox { get; set; }

        [FindsBy(How = How.Id, Using = "wpsc_checkout_form_18")]
        public IWebElement PhoneTextBox { get; set; }

        [FindsBy(How = How.Id, Using = "shippingSameBilling")]
        public IWebElement SameAsBillingAdressCheckBox { get; set; }

        [FindsBy(How = How.Id, Using = "wpsc_checkout_form_11")]
        public IWebElement ShippingAdressFirstName { get; set; }

        [FindsBy(How = How.Id, Using = "wpsc_checkout_form_12")]
        public IWebElement ShippingAdressLastName { get; set; }

        [FindsBy(How = How.Id, Using = "wpsc_checkout_form_13")]
        public IWebElement ShippingAdressAddress { get; set; }

        [FindsBy(How = How.Id, Using = "wpsc_checkout_form_14")]
        public IWebElement ShippingAddressCity { get; set; }

        [FindsBy(How = How.Id, Using = "wpsc_checkout_form_15")]
        public IWebElement ShippingAddressState { get; set; }

        [FindsBy(How = How.Id, Using = "wpsc_checkout_form_16")]
        public IWebElement ShippingAddressCountrySelectRoot { get; set; }

        [FindsBy(How = How.Id, Using = "wpsc_checkout_form_17")]
        public IWebElement ShippingAddressPostalCode { get; set; }

        [FindsBy(How = How.CssSelector, Using = "tr.total_price:nth-child(2) > td:nth-child(2) > span:nth-child(1) > span:nth-child(1)")]
        public IWebElement TotalShippingPriceTextBox { get; set; }

        [FindsBy(How = How.CssSelector, Using = "tr.total_price:nth-child(3) > td:nth-child(2) > span:nth-child(1) > span:nth-child(1)")]
        public IWebElement ItemCostTextBox { get; set; }

        [FindsBy(How = How.CssSelector, Using = "tr.total_price:nth-child(4) > td:nth-child(2) > span:nth-child(1) > span:nth-child(1)")]
        public IWebElement TaxTextBox { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#checkout_total > span:nth-child(1)")]
        public IWebElement TotalPriceTextBox { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".step1 > span:nth-child(1)")]
        public IWebElement GoBackButton { get; set; }

        [FindsBy(How = How.ClassName, Using = "make_purchase")]
        public IWebElement PurchaseButton { get; set; }

        public int GetItemCost()
        {
            string rawItemCost = this.ItemCostTextBox.Text;
            string itemCostAsString = Regex.Match(rawItemCost, @"\d+").Value;
            int itemCostAsInt = Convert.ToInt32(itemCostAsString);

            return itemCostAsInt;
        }

        public int GetTotalPrice()
        {
            string rawTotalPrice = this.TotalPriceTextBox.Text;
            string rawPriceAsString = Regex.Match(rawTotalPrice, @"\d+").Value;
            int rawPriceAsInt = Convert.ToInt32(rawPriceAsString);

            return rawPriceAsInt;
        }

        public int GetTotalShipping()
        {
            string rawTotalPrice = this.TotalShippingPriceTextBox.Text;
            string rawPriceAsString = Regex.Match(rawTotalPrice, @"\d+").Value;
            int rawPriceAsInt = Convert.ToInt32(rawPriceAsString);

            return rawPriceAsInt;
        }

        public int GetTotalTax()
        {
            string rawTotalPrice = this.TaxTextBox.Text;
            string rawPriceAsString = Regex.Match(rawTotalPrice, @"\d+").Value;
            int rawPriceAsInt = Convert.ToInt32(rawPriceAsString);

            return rawPriceAsInt;
        }


    }
}
