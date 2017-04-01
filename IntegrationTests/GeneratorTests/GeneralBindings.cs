using System;
using PocoGenerator;
using TechTalk.SpecFlow;

namespace IntegrationTests
{
    [Binding]
    public class GeneralBindings : BaseBinding
    {
        [Given("I have a generator for a class TestClass")]
        public void GivenIHaveEnteredSomethingIntoTheCalculator()
        {
            var generator = new Generator<TestClass>();
            ScenarioContext.Current.Add(Generator, generator);
        }

        [When("I invoke generate with amount (.*)")]
        public void Gnerate(int number)
        {
            var generator = GetG();
            var generatedResult = generator.Generate(number);
            SetResult(generatedResult);
        } 
    }
}
