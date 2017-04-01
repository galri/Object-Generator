using System;
using System.Collections;
using System.Collections.Generic;
using PocoGenerator;
using TechTalk.SpecFlow;

namespace IntegrationTests
{
	public class BaseBinding
	{
		public const string Generator = "Generator";

		internal const string Generated = "Generated";


        public static Generator<TestClass> GetG()
		{
            return (Generator<TestClass>)ScenarioContext.Current[Generator];
		}

        internal static void SetResult(IEnumerable<TestClass> generatedResult)
        {
            ScenarioContext.Current.Add(Generated, generatedResult);
        }

        public static IEnumerable<TestClass> GetGResult()
		{
            return (IEnumerable<TestClass>)ScenarioContext.Current[Generated];
		}

   }
}
