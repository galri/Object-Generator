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
            foreach (var item in result)
            {
                Assert.Contains(item.StringProp, new string[] { p0, p1 });
            }
        }
    }
}
