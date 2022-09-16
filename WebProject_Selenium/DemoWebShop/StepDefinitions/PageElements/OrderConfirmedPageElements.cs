
using OpenQA.Selenium;

namespace DemoWebShop.StepDefinitions
{
    public class OrderConfirmedPageElements
    {
        public static readonly By ThankYouTitle = By.XPath("//div[@class = 'page-title'] //h1[contains(text(), 'Thank you')]");

        public static readonly By OrderSuccessfulMessage = By.XPath("//div[@class='section order-completed'] " +
            "//strong[contains(text(),'Your order has been successfully processed!')]");

        public static readonly By OrderDetailsLink = By.XPath("//div[@class='section order-completed']" +
            " //a[contains(text(),'Click here for order details.')]");
    }
}
