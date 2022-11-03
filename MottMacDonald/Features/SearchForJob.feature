Feature: SearchForJob

A short summary of the feature

@tag1
Scenario:Job Search Returns Expected Result
	Given I navigate to the Careers Page
	When I search for '<Job>'
	Then I verify the search returns '<Job>'
	And I verify when I click on “view Job” I am directed to the details for the '<Job>'

	Examples: 
	| Job                              |
	| Test Automation Engineer         |
	
