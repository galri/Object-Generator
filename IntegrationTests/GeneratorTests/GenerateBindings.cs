using System;
using System.Linq;
using NUnit.Framework;
using PocoGenerator;

using TechTalk.SpecFlow;

namespace IntegrationTests
{
	[Binding]
    public class GenerateBindings : BaseBinding
	{
        [Then("I should receive (.*) objects")]
		public void ThenTheResultShouldBe(int amount)
		{
            var result = GetGResult();
            Assert.AreEqual(amount, result.Count());
		}

        [Then(@"the string property should be default string")]
        public void ThenTheStringPropertyShouldBeDefaultString()
        {
            var result = GetGResult();
            Assert.AreEqual(default(string), result.First().StringProp);
        }

        [Given(@"I set blueprint for property to fixed value ""(.*)""")]
        public void GivenISetBlueprintForPropertyToFixedValue(string p0)
        {
            var gen = GetG();
            gen.Bt<TestClass>().Fixed(nameof(TestClass.StringProp), p0);
        }

        [Then(@"All StringProp should have value ""(.*)"" for all objects")]
        public void ThenAllStringPropShouldHaveValueForAllObjects(string p0)
        {
            var result = GetGResult();

            foreach (var item in result)
            {
                Assert.AreEqual(p0, item.StringProp);
            }
        }

        [Given(@"I set blueprint for StringProp to ""(.*)"" and ""(.*)""")]
        public void GivenISetBlueprintForStringPropToAnd(string p0, string p1)
        {
            var gen = GetG();
            gen.Bt<TestClass>().Possible(nameof(TestClass.StringProp), new string[] { p0, p1 });
        }

        [Then(@"All StringProp should be ""(.*)"" or ""(.*)""")]
        public void ThenAllStringPropShouldBeOr(string p0, string p1)
        {
            var result = GetGResult();
            int firsts = 0;
            int seconds = 0;
            foreach (var item in result)
            {
                if (item.StringProp == p0)
                    firsts++;
                else if (item.StringProp == p1)
                    seconds++;
                else
                    throw new AssertionException("Invalid string prop");
            }
            Assert.Greater(firsts, 40);
            Assert.Greater(seconds, 40);
        }

        [Given(@"I set blueprint for numberprop between (.*) and (.*)")]
        public void GivenISetBlueprintForNumberpropBetweenAnd(int p0, int p1)
        {
            GetG().Bt<TestClass>().Between(nameof(TestClass.NumberProp), p0, p1);
        }

        [Then(@"the numberprop should be between (.*) and (.*)")]
        public void ThenTheNumberpropShouldBeBetweenAnd(int p0, int p1)
        {
            var result = GetGResult();

            foreach (var item in result)
            {
                Assert.LessOrEqual(p0, item.NumberProp);
                Assert.GreaterOrEqual(p1, item.NumberProp);
            }
        }
    }
}
