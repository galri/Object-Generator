using System;
using NUnit.Framework;
using PocoGenerator;

namespace UnitTests
{
	[TestFixture]
	public class GeneratorTests
	{
		[Test]
		public void GenerateWithoutSetup() 
		{
			var generator = new Generator<object>();

			var result  = generator.Generate(10);
		}
	}
}
