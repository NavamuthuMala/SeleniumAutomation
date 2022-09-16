
using OpenQA.Selenium;

namespace DemoWebShop.StepDefinitions
{
    public class CheckoutPageElements
    {
        public static readonly By CheckoutAsGuest = By.CssSelector("input[value='Checkout as Guest']");

        public static readonly By CheckoutTitle = By.XPath("//div[@class = 'page-title'] //h1[contains(text(), 'Checkout')]");

        public static readonly By FirstName = By.CssSelector("input[name='BillingNewAddress.FirstName']");
        public static readonly By LastName = By.CssSelector("input[name='BillingNewAddress.LastName']");
        public static readonly By Email = By.CssSelector("input[name='BillingNewAddress.Email']");
        public static readonly By Country = By.CssSelector("select[name='BillingNewAddress.CountryId']");
        public static readonly By City = By.CssSelector("input[name='BillingNewAddress.City']");
        public static readonly By Address1 = By.CssSelector("input[name='BillingNewAddress.Address1']");
        public static readonly By ZipPostalCode = By.CssSelector("input[name='BillingNewAddress.ZipPostalCode']");
        public static readonly By PhoneNumber = By.CssSelector("input[name='BillingNewAddress.PhoneNumber']");

        public static readonly By ContinueBillingAddress = By.XPath("//li[@id='opc-billing' and @class = 'tab-section allow active'] //input[@value='Continue']");
        public static readonly By ContinueShippingAddress = By.XPath("//li[@id='opc-shipping' and @class = 'tab-section allow active'] //input[@value='Continue']");
        public static readonly By ContinueShippingMethod = By.XPath("//li[@id='opc-shipping_method' and @class = 'tab-section allow active'] //input[@value='Continue']");
        public static readonly By ContinuePaymentMethod = By.XPath("//li[@id='opc-payment_method' and @class = 'tab-section allow active'] //input[@value='Continue']");
        public static readonly By ContinuePaymentInformation = By.XPath("//li[@id='opc-payment_info' and @class = 'tab-section allow active'] //input[@value='Continue']");

        public static readonly By ConfirmOrder = By.XPath("//li[@id='opc-confirm_order' and @class = 'tab-section allow active'] //input[@value='Confirm']");

    }
}
