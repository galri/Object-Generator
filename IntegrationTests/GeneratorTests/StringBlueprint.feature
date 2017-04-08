Feature: string bluprinting
    Able to set varied possible values for string properties

Scenario: Generate StringProp with default values
    Given I have a generator for a class TestClass
    When I invoke generate with amount 1
    Then the string property should be default string

Scenario: Generate StringProp with fixed set value.
    Given I have a generator for a class TestClass
    And I set blueprint for property to fixed value "Test"
    When I invoke generate with amount 10
    Then All StringProp should have value "Test" for all objects

Scenario: Generate StringProp with fixed randome Values
    Given I have a generator for a class TestClass
    And I set blueprint for StringProp to "test" and "test2"
    When I invoke generate with amount 100
    Then All StringProp should be "test" or "test2"