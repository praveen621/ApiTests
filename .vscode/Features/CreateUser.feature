
Feature: CreateUSer
Scenario: Create a new user
Given I input name "John"
And I input job "Developer"
When I send create a user request
Then I should see the user created