using DemoWebShop.SeleniumHelpers;
using DemoWebShop.Constants;
using TechTalk.SpecFlow;
using NUnit.Framework;
using System;

namespace DemoWebShop.StepDefinitions
{
    [Binding]
    public class HighRiskTestsSteps
    {
        private readonly Helpers _seleniumHelpers;

        private string _nameOfItemAdded;
        private double _amountOfItemAdded;
        private double _quantityOfItemAdded;

        public HighRiskTestsSteps(Helpers seleniumHelpers)
        {
            _seleniumHelpers = seleniumHelpers;
        }

        [Given(@"I have loaded the demo web shop")]
        public void GivenIHaveLoadedTheDemoWebShop()
        {
            _seleniumHelpers.SetupDriver(URLConstants.demoWebPageUrl);
            _seleniumHelpers.WaitForElementToDisplay(HomePageElements.DemoWebShopImage);
        }

        [Given(@"I have selected a category to view")]
        public void GivenIHaveSelectedACategoryToView()
        {
            _seleniumHelpers.ClickElement(HomePageElements.MenuBooks);
            _seleniumHelpers.WaitForElementToDisplay(BooksPageElements.TitleBooks);
        }
        
        [Given(@"I have an item added in the cart")]
        public void GivenIHaveAddedFewItemsToTheCart()
        {
            GivenIHaveLoadedTheDemoWebShop();
            GivenIHaveSelectedACategoryToView();
            WhenIPressAddToCartButtonForTheFirstItem();
            ThenIShouldSeeProductAddedToTheCartBanner();
            WhenIClickShoppingCartButton();
            ThenIShouldSeeTheItemAddedIsListedWithCorrectPriceAndQuantity();
        }
        
        [When(@"I press Add to cart button for the first item")]
        public void WhenIPressAddToCartButtonForTheFirstItem()
        {
            _nameOfItemAdded = _seleniumHelpers.GetElementText(BooksPageElements.FirstItemName);

            var itemPriceText = _seleniumHelpers.GetElementText(BooksPageElements.FirstItemPrice);
            _amountOfItemAdded = double.Parse(itemPriceText);
            _quantityOfItemAdded = 1;

            _seleniumHelpers.ClickElement(BooksPageElements.AddToCart);
        }
        
        [When(@"I click Shopping cart button")]
        public void WhenIClickShoppingCartButton()
        {
            _seleniumHelpers.ClickElement(HomePageElements.ShoppingCartLink);
        }
        
        [When(@"I Select Checkout button")]
        public void WhenISelectCheckoutButton()
        {
            _seleniumHelpers.ClickElement(ShoppingCartPageElements.Checkout);
        }
        
        [When(@"I select the default options for shipping and payment methods")]
        public void WhenISelectTheDefaultOptionsForShippingAndPaymentMethods()
        {
            _seleniumHelpers.EnterText(CheckoutPageElements.FirstName, "ABC Name");
            _seleniumHelpers.EnterText(CheckoutPageElements.LastName, "XYZ Name");
            _seleniumHelpers.EnterText(CheckoutPageElements.Email, "ABCXYZ@gmail.com");

            _seleniumHelpers.SelectOption(CheckoutPageElements.Country, "Australia");

            _seleniumHelpers.EnterText(CheckoutPageElements.City, "Melbourne");
            _seleniumHelpers.EnterText(CheckoutPageElements.Address1, "2, My address");
            _seleniumHelpers.EnterText(CheckoutPageElements.ZipPostalCode, "3805");
            _seleniumHelpers.EnterText(CheckoutPageElements.PhoneNumber, "3805 3805");

            _seleniumHelpers.ClickElement(CheckoutPageElements.ContinueBillingAddress);
            _seleniumHelpers.ClickElement(CheckoutPageElements.ContinueShippingAddress);
            _seleniumHelpers.ClickElement(CheckoutPageElements.ContinueShippingMethod);
            _seleniumHelpers.ClickElement(CheckoutPageElements.ContinuePaymentMethod);
            _seleniumHelpers.ClickElement(CheckoutPageElements.ContinuePaymentInformation);
            _seleniumHelpers.ClickElement(CheckoutPageElements.ConfirmOrder);
        }
        
        [Then(@"I should see product added to the cart banner")]
        public void ThenIShouldSeeProductAddedToTheCartBanner()
        {
            Assert.IsTrue(_seleniumHelpers.CheckElementDisplayed(BooksPageElements.ProductAddedNotification,5),
                "Failed to display Product added notification on top of the page.");
        }
        
        [Then(@"I should see the item added is listed with correct price and quantity")]
        public void ThenIShouldSeeTheItemAddedIsListedWithCorrectPriceAndQuantity()
        {
           var itemName = _seleniumHelpers.GetElementText(ShoppingCartPageElements.FirstItemNameInCart);
            Assert.IsTrue(_nameOfItemAdded == itemName, $"Expected item name - {_nameOfItemAdded}, displayed item name - {itemName}");

            var itemPrice = double.Parse(_seleniumHelpers.GetElementText(ShoppingCartPageElements.FirstItemUnitPriceInCart));
            Assert.IsTrue(_amountOfItemAdded == itemPrice, $"Expected item price - {_amountOfItemAdded}, displayed item price - {itemPrice}");

            var expectedTotalAmount = _quantityOfItemAdded * _amountOfItemAdded;
            var totalAmount = double.Parse(_seleniumHelpers.GetElementText(ShoppingCartPageElements.TotalAmount));
            Assert.IsTrue(expectedTotalAmount == totalAmount,
                $"Expected total amount - {expectedTotalAmount}, displayed total amount - {totalAmount}");
        }
        
        [Then(@"I agree with the terms")]
        public void ThenIAgreeWithTheTerms()
        {
            _seleniumHelpers.ClickElement(ShoppingCartPageElements.TermsService);
        }

        [When(@"I Select Checkout as guest button")]
        public void WhenISelectCheckoutAsGuestButton()
        {
            _seleniumHelpers.ClickElement(CheckoutPageElements.CheckoutAsGuest);
        }


        [Then(@"I should be in Checkout page")]
        public void ThenIShouldBeInCheckoutPage()
        {
            Assert.IsTrue(_seleniumHelpers.CheckElementDisplayed(CheckoutPageElements.CheckoutTitle,5),
                "Failed to load checkout page.");
        }
        
        [Then(@"I should be able to confirm the order")]
        public void ThenIShouldBeAbleToConfirmTheOrder()
        {
            _seleniumHelpers.ClickElement(CheckoutPageElements.ConfirmOrder);

            _seleniumHelpers.CheckElementDisplayed(OrderConfirmedPageElements.ThankYouTitle,5);
            _seleniumHelpers.CheckElementDisplayed(OrderConfirmedPageElements.OrderSuccessfulMessage,5);

        }

        [Then(@"I should be able to view order details")]
        public void ThenIShouldBeAbleToViewOrderDetails()
        {
            _seleniumHelpers.ClickElement(OrderConfirmedPageElements.OrderDetailsLink);

            _seleniumHelpers.CheckElementDisplayed(OrderDetailsPageElements.OrderInfoLink,5);
        }

    }
}
