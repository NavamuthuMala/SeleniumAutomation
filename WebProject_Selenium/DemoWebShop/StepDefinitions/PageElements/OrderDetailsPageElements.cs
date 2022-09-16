

using OpenQA.Selenium;

namespace DemoWebShop.StepDefinitions
{
    public class OrderDetailsPageElements
    {
        public static readonly By OrderInfoLink = By.XPath("//div[@class = 'page-title'] //h1[contains(text(), 'Order information')]");
    }
}
