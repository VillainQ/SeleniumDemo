Feature: DashboardNavigation
	In order to navigate to around page
	As an annonymous user
	I need to click around main dashbaord menu

@menu
Scenario Outline: Navigate to about us via carriers dashboard
	Given I am on Ubs main page on <browser> with <language>
	And Selected language is english
	When I select about as in carrier dropdown
	Then I will be redirected to about us page
		Examples:
		| browser | language |
		| chrome  | en       |