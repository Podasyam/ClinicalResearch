@sanity
Feature: FeatureName GoogleSearchResults

@mytag
Scenario: Search results in Google browser
	Given Launch the browser <environment>
	When  User enter text Selenium 
	When  User click on Search button
	Then  Selenium search results should display	
	And   Close the Browser
	Examples:
    | environment |
    | chrome      |
    | Edge        |