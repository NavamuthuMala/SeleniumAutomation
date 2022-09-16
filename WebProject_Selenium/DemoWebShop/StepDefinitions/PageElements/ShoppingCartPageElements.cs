using OpenQA.Selenium;

namespace DemoWebShop.StepDefinitions
{
    public class ShoppingCartPageElements
    {
        public static readonly By FirstItemNameInCart = By.CssSelector("div[class=order-summary-content] " +
            "tr[class=cart-item-row] td[class=product] a");

        public static readonly By FirstItemUnitPriceInCart = By.CssSelector("div[class=order-summary-content] " +
            "tr[class=cart-item-row] td[class='unit-price nobr'] span[class=product-unit-price]");

        public static readonly By TotalAmount = By.CssSelector("div[class=cart-footer] div[class=totals] " +
            "tr td[class=cart-total-right] span[class='product-price order-total'] ");

        public static readonly By TermsService = By.CssSelector("div[class=terms-of-service] input[id=termsofservice]");

        public static readonly By Checkout = By.CssSelector("button[id=checkout]");
    }
}
