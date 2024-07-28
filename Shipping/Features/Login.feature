Feature: Login

@mytag
Scenario: Login with valid user entries
	Given Launch the browser
	When  User enter the username and password
	When  User click on Login button
	Then  User has been logged in successfull message should display
	And   Home page should display
	And   Close the Browser