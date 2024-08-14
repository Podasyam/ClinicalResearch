@sanity
Feature: FeatureName GoogleSearchResults

@DataSource:C:/Users/User/source/repos/ClinicalResearch/Shipping/Data/TestData.xlsx @DataSet:Sheet1
Scenario: Search results in Google browser
	Given Launch the browser <environment>
	When  User enter text Selenium 
	When  User click on Search button
	Then  Selenium search results should display	
	And   Close the Browser


@DataSource:C:/Users/User/source/repos/ClinicalResearch/Shipping/Data/TestData.xlsx @DataSet:Sheet1
Scenario: Search inactive links in webpage
	Given Launch the browser <environment>
	When  User click on cloths link 
	Then  User should navigate to cloths webpage	
	

	#SpecFlow+ Runner supports parallel execution with AppDomain, SharedAppDomain and Process isolation.