Feature: InformationIcon
As a Product Owner
I want that while using the KiwiSaver Retirement Calculator all fields in the calculator have got the information icon present
So that the user is able to get a clear understanding of what needs to be entered in the field.

@prod
Scenario Outline: User clicks on an information icon and sees the correct info message
	Given I am in the KiwiSaver Retirement Calculator Page
	When I click on the information icon for <Calculator Element>
	Then I am informed of what needs to be entered in the <Calculator Element>

	Examples:
	| Calculator Element            |
	| Current age                   |
	| Employment status             |
	| Salary                        |
	| KiwiSaver member contribution |
	| Current KiwiSaver balance     |
	| Voluntary contributions       |
	| Risk profile                  |
	| Savings goal at retirement    |