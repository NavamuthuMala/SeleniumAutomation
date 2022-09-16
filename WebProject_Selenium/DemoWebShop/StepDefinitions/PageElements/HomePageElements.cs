using OpenQA.Selenium;

namespace DemoWebShop.StepDefinitions
{
    public class HomePageElements
    {
        public static readonly By DemoWebShopImage = By.CssSelector("div[class=header-logo] a img[alt= 'Tricentis Demo Web Shop']");
        public static readonly By LoginLink = By.CssSelector("div[class=header-links] a[href= '/login']");
        public static readonly By ShoppingCartLink = By.CssSelector("div[class=header-links] a[href= '/cart']");
        public static readonly By LoginForm = By.CssSelector("div[class=returning-wrapper] form[action = '/login']");

        public static readonly By EnterEmail = By.Id("input[id=Email]");

        public static readonly By MenuBooks = By.CssSelector("ul[class = top-menu] a[href = '/books']");
    }
}
