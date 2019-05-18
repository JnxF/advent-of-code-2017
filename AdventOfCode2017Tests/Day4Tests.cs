using AdventOfCode2017;
using Xunit;

namespace AdventOfCode2017Tests
{
    public class Day4Tests
    {
        [Fact]
        public void Day4()
        {
            var day = new Day4();
            Assert.Equal(386, day.FirstPart());
            Assert.Equal(208, day.SecondPart());
        }

        [Theory]
        [InlineData("aa bb cc dd ee", 1)]
        [InlineData("aa bb cc dd aa", 0)]
        [InlineData("aa bb cc dd aaa", 1)]
        public void Day4_FirstPart(string input, int output)
        {
            Assert.Equal(output, new Day4(input).FirstPart());
        }

        [Theory]
        [InlineData("abcde fghij", 1)]
        [InlineData("abcde xyz ecdab", 0)]
        [InlineData("a ab abc abd abf abj", 1)]
        [InlineData("iiii oiii ooii oooi oooo", 1)]
        [InlineData("oiii ioii iioi iiio", 0)]
        public void Day4_SecondPart(string input, int output)
        {
            Assert.Equal(output, new Day4(input).SecondPart());
        }
    }
}
