Feature: KiwiSaverRetirementCalculator
As a Product Owner
I want that the KiwiSaver Retirement Calculator users are able to calculate what their KiwiSaver projected balance would be at retirement
So that the users are able to plan their investments better.

#using json file
@prod
Scenario Outline: KiwiSaver retirement projection is displayed for different user profiles - using json
	Given I am in the KiwiSaver Retirement Calculator Page
	When I fill up the calculator with my user profile as <Persona>
	Then I am able to calculate my projected balances at retirement

	Examples:
	| Persona                 |
	| Employed Persona 1      |
	| Self-employed Persona 1 |
	| Not employed Persona 1  |

#using scenario outline
@prod
Scenario Outline: KiwiSaver retirement projection is displayed for different user profiles - using scenario outline
	Given I am in the KiwiSaver Retirement Calculator Page
	When I enter <Current Age> in Current age
	And I select <Employment Status> in Employment status
	And I enter <Salary> in Salary
	And I select <KiwiSaver Member Contribution> in KiwiSaver member contribution
	And I enter <Current KiwiSaver Balance> in Current KiwiSaver balance
	And I enter <Voluntary Contributions> in Voluntary contributions
	And I select <Frequency> in Frequency
	And I select <Risk Profile> in Risk profile
	And I enter <Savings Goal At Retirement> in Savings goal at retirement
	Then I am able to calculate my projected balances at retirement

	Examples:
	| Current Age | Employment Status | Salary | KiwiSaver Member Contribution | Current KiwiSaver Balance | Voluntary Contributions | Frequency   | Risk Profile | Savings Goal At Retirement |
	| 30          | Employed          | 82000  | 4%                            |                           |                         |             | Defensive    |                            |
	| 45          | Self-employed     |        |                               | 100000                    | 90                      | Fortnightly | Conservative | 290000                     |
	| 55          | Not employed      |        |                               | 140000                    | 10                      | Annually    | Balanced     | 200000                     |

