Feature: Generation
	Generate objects frmo generator.
	
@mytag
Scenario: Create 10 objects without setup.
    Given I have a generator for a class TestClass
	When I invoke generate with amount 10
	Then I should receive 10 objects