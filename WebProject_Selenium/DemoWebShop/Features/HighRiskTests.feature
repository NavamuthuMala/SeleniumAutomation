Feature: HighRiskTests

Scenario: Add an item to cart and verify cart
Given I have loaded the demo web shop
And I have selected a category to view
When I press Add to cart button for the first item
Then I should see product added to the cart banner
When I click Shopping cart button
Then I should see the item added is listed with correct price and quantity


Scenario: Checkout the cart and process payment
Given I have an item added in the cart
Then I agree with the terms
When I Select Checkout button
And I Select Checkout as guest button
Then I should be in Checkout page
When I select the default options for shipping and payment methods
Then I should be able to confirm the order
And I should be able to view order details
