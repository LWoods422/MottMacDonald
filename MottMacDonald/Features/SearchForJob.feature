Feature: SearchForJob

A short summary of the feature

@tag1
Scenario: CareersPage
	Given I navigate to the Careers Page
	When I search for '<Job>'
	Then I verify the search returns '<Job>'
	And I verify when I click on “view Job” I am directed to the details for the '<Job>'

	Examples: 
	| Job                              |
	| Project Manager- Water Resources |
	| Test Automation Engineer         |
	
