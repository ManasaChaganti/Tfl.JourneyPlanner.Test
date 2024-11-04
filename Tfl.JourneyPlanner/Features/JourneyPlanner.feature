Feature: Journey Planner

Background:
	Given user on the home page

Scenario Outline: 1. Plan a journey and validate Walking and Cycling journey time
	Given the journey is planned from "<FromStation>" to "<ToStation>"
	Then user clicks on plan for my journey
	Then user should validate the walking time <WalkingTime> and Cycling time <CyclingTime> displayed
	
Examples:
	| Sno | FromStation                          | ToStation                            | WalkingTime | CyclingTime |
	| 1   | Leicester Square Underground Station | Covent Garden Underground Station    | 7mins       | 1mins       |
	| 2   | Covent Garden Underground Station    | Leicester Square Underground Station | 5mins       | 2mins       |

Scenario: 2. Update journey with least walking preference and validate updated journey time
	Given the journey is planned from "<FromStation>" to "<ToStation>"
	Then user clicks on plan for my journey
	When user edit preferences to select routes with least walking
	And user update the journey
	Then I validate the journey time 11mins is displayed correctly
Examples:
	| Sno | FromStation                          | ToStation                         | JourneyTime |
	| 1   | Leicester Square Underground Station | Covent Garden Underground Station | 11mins      |

Scenario: 3. user clicks on view Details to access the information at To station
	Given the journey is planned from "<FromStation>" to "<ToStation>"
	Then user clicks on plan for my journey
	When user edit preferences to select routes with least walking
	And user update the journey
	Then user click on the View Details
	Then verify complete access information
Examples:
	| Sno | FromStation                          | ToStation                         |
	| 1   | Leicester Square Underground Station | Covent Garden Underground Station |

@ignore
Scenario: 6.Plan a journey  by selecting Arriving, validate Walking and Cycling journey time
TODO: These are few additional scenarios that can be included 
	Given the journey is planned from "<FromStation>" to "<ToStation>"
	Then user selects Arriving
	Then user clicks on plan for my journey
	Then user should validate the walking time <WalkingTime> and Cycling time <CyclingTime> displayed

@ignore
Scenario: 7.Plan a journey  by selecting Arriving and Click on Later Journeys ,validate Walking and Cycling journey time
	Given the journey is planned from "<FromStation>" to "<ToStation>"
	Then user selects Arriving
	Then user clicks on plan for my journey
	When user click on Later Journey
	Then user should validate the walking time and Cycling time displayed
@ignore
Scenario: 8. Update journey with Step free access and  updated journey
	Given the journey is planned from "<FromStation>" to "<ToStation>"
	Then user clicks on plan for my journey
	When user edit preferences to select Step-free access
	And user update the journey