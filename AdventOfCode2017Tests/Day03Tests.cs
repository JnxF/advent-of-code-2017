using AdventOfCode2017;
using Xunit;

namespace AdventOfCode2017Tests
{
    public class Day03Tests
    {
        [Fact]
        public void Day03()
        {
            var day = new Day03(289326);
            Assert.Equal(419, day.FirstPart());
            Assert.Equal(289326, day.SecondPart());
        }

        [Theory]
        [InlineData(1, 0)]
        [InlineData(12, 3)]
        [InlineData(23, 2)]
        [InlineData(1024, 31)]
        [InlineData(289326, 419)]
        public void Day1_FirstPart(int input, int output)
        {
            Assert.Equal(output, new Day03(input).FirstPart());
        }

    }
}
