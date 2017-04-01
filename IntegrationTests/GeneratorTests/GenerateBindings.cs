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
	}
}
