Feature: LanguageChange
	In order to switch language
	As a annonymoys user
	I need to enter website and click 'EN' or 'De'

@languages
Scenario Outline: Change Language to DE 
	Given I am on Ubs main page on <browser> with <language>
	And Selected language is english
	When I click language switch
	Then Page language will change to DE
		Examples:
		| browser | language |
		| chrome  | en       |