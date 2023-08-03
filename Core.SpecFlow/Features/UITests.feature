Feature: UITests

@UI
Scenario: Perform search UItest
	Given I confirm privacy
 	Given I search for "Playing surfaces"
	Then Results should be more than "1000"

@UI
Scenario: Redirection for instagram
	Given Expected social network url
	And I confirm privacy
	And I switch to social network "Instagram"
	Then I verify expected url with actual

@UI
Scenario: Count header links
	Given I confirm privacy
	And I change language to "Russian"
	Then I verify that header links count should be 0

@UI
Scenario: Fifa partners test
	Given Expected partners list
	And I confirm privacy
	Then I verify that partners lists should be the same
	