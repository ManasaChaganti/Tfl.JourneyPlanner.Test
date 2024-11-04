Feature: Journey Planner Negative Scenarios

Scenario: 4.Validate widget with out Locations
	Given user on the home page
	Then user clicks on plan for my journey
	Then Validate if widget is unable to plan the 

Scenario: 5.Validate widget with invalid Locations
	Given user on the home page
	Given the journey is planned from "Leicester Square Underground Station" to "2312187382178*&^%"
	Then user clicks on plan for my journey
	Then Validate widget provide invalid results