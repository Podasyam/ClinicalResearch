Feature: Gmail

  Background:
    Given user launch the browser
    And  user should logout

@tag1
Scenario: Access Gmail account
	When  User enter usernmae and passowrd
	Then  gmail homepage should open
	
