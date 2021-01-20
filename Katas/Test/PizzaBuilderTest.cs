using System.Diagnostics;
using Threading;
using Xunit;

namespace Test
{
    public class PizzaBuilderTest
    {
        [Fact]
        public void IsServedOnTime()
        {
            // arrange
            var pizzaBuilder = new PizzaBuilder();

            // act
            var stopwatch = Stopwatch.StartNew();
            var pizza = pizzaBuilder.Build();
            stopwatch.Stop();

            // assert
            Assert.True(stopwatch.ElapsedMilliseconds < 5000);
        }
    }
}
