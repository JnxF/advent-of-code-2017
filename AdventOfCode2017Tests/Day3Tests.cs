using AdventOfCode2017;
using Xunit;

namespace AdventOfCode2017Tests
{
    public class Day3Tests
    {
        [Fact]
        public void Day3()
        {
            var day = new Day3(289326);
            Assert.Equal(419, day.FirstPart());
        }

        [Theory]
        [InlineData(1, 0)]
        [InlineData(12, 3)]
        [InlineData(23, 2)]
        [InlineData(1024, 31)]
        [InlineData(289326, 419)]
        public void Day1_FirstPart(int input, int output)
        {
            Assert.Equal(output, new Day3(input).FirstPart());
        }

    }
}
