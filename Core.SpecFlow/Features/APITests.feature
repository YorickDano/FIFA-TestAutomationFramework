Feature: APITests

@API
Scenario: Record type changing APItest
	Given I create RequestBuilder
	Given I create request
 	Given I set request resource "search"
	Given I set request parameters
	| name         | value            |
	| searchString | Playing Surfaces |
	| page         | 0                |
	| pageSize     | 25               |
	| contentType  | video            |
	| sort         | relevance        |
	| dateFrom     | 1900-01-02       |
	| locale       | en               |
	When I execute request
	Then I verify

@API
Scenario: Check hit title APItest
	Given Response from request configuration from file "fifaSearchRequestData.json"
	And Expected Api data from file "searchResultsExpectedData.json"
	Then I verify that hit titles should be the same

@API
Scenario: Check response code APItest
	Given Response from request configuration from file "fifaSearchRequestData.json"
	Then HTTP code status should be "OK"