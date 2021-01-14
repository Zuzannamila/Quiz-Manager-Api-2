using System.Collections.Generic;
using Katas;
using Katas.Models;
using Xunit;

namespace Test
{
    public class KatasTestClass 
    {
        public KatasClass _testClass = new KatasClass();
    }

    public class AreCatsDominant : KatasTestClass
    {
        [Fact]
        public void GivenNoAnimals_ReturnsNull()
        {
            // arrange
            var animals = new List<Animal>();

            // act
            var result = _testClass.AreCatsDominant(animals);

            // assert
            Assert.Null(result);
        }

        [Fact]
        public void GivenOnlyCats_ReturnsTrue()
        {
            // arrange
            var animals = new List<Animal> { new Cat() };

            // act
            var result = _testClass.AreCatsDominant(animals);

            // assert
            Assert.True(result);
        }

        [Fact]
        public void GivenOnlyDogs_ReturnsFalse()
        {
            // arrange
            var animals = new List<Animal> { new Dog() };

            // act
            var result = _testClass.AreCatsDominant(animals);

            // assert
            Assert.False(result);
        }

        [Fact]
        public void GivenMixedInput_ReturnsExpectedValue()
        {
            // arrange
            var animals1 = new List<Animal> { new Dog(), new Cat(), new Cat() };
            var animals2 = new List<Animal> { new Dog(), new Dog(), new Cat() };
            var animals3 = new List<Animal> { new Dog(), new Dog(), new Cat(), new Cat() };

            // act
            var result1 = _testClass.AreCatsDominant(animals1);
            var result2 = _testClass.AreCatsDominant(animals2);
            var result3 = _testClass.AreCatsDominant(animals3);

            // assert
            Assert.True(result1);
            Assert.False(result2);
            Assert.Null(result3);
        }
    }
}
