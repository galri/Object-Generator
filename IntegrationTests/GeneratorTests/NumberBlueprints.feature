Feature: Number Blueprints
	able to set varied possible values spesific to numbers.

Scenario: Generate numberprop with values set between.
    Given I have a generator for a class TestClass
	And I set blueprint for numberprop between -100 and 9999
    When I invoke generate with amount 100
    Then the numberprop should be between -100 and 9999