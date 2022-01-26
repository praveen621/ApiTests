Feature: CreateUser

Scenario: Add a user
Given I input name "Mike"
And I input Job "STE"
When I send create a user request
Then validate user is created