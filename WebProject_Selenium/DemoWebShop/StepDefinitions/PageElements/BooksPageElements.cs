using OpenQA.Selenium;

namespace DemoWebShop.StepDefinitions
{
    public class BooksPageElements
    {
        public static readonly By TitleBooks = By.XPath("//div[@class='page-title'] " +
            "//h1[contains(text(),'Books')]");
        public static readonly By AddToCart = By.CssSelector("div[class=product-grid] " +
            "div[class=details] div[class=buttons] input[value='Add to cart']");
        public static readonly By FirstItemName = By.CssSelector("div[class=product-grid] " +
            "div[class=details] h2[class=product-title]");
        public static readonly By FirstItemPrice = By.CssSelector("div[class=product-grid] " +
            "div[class=details] div[class=prices] span[class='price actual-price']");
        public static readonly By ProductAddedNotification = By.XPath("//div[@id='bar-notification' " +
            "and contains(@style, 'display: block')] //p[contains(text(),'The product has been added to your ')] " +
            "//a[@href = '/cart' and contains(text(),'shopping cart')]");
    }
}
