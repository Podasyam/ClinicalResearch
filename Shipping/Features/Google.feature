@sanity
Feature: FeatureName GoogleSearchResults

@DataSource:C:/Users/User/source/repos/ClinicalResearch/Shipping/Data/TestData.xlsx @DataSet:Sheet1
Scenario: Search results in Google browser
	Given Launch the browser <environment>
	When  User enter text Selenium 
	When  User click on Search button
	Then  Selenium search results should display	
	And   Close the Browser


	#SpecFlow+ Runner supports parallel execution with AppDomain, SharedAppDomain and Process isolation.