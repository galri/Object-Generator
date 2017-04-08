using NUnit.Framework;
using PocoGenerator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace IntegrationTests.Random
{
    [TestFixture]
    public class RandomTest
    {
        [Test]
        public void RandomeHalfish()
        {
            //Arrange
            var randomer = new RandomeGenerator();
            var result = new int[100];

            //Act
            for (int i = 0; i < 100; i++)
            {
                result[i] = randomer.get(0,2);
            }

            //Assert
            var zeroes = result.Count(t => t == 0);
            var ones = result.Count(t => t == 1);
            Assert.Greater(zeroes,40);
            Assert.Greater(ones, 40);
        }
    }
}
