Feature: Login
	In order to login
	As a proper user
	I need to pass all data or information about missing data will be provided

@login
Scenario Outline: Login ubs safe failed with empty contact number validation
	Given I am on Ubs main page on <browser> with <language>
	And I have selected Ubs safe in Login menu
	When I press Continue
	Then validation with empty contact number will be shown.

	Examples:
		| browser | language |
		| chrome  | en       |
		| firefox | en       |