using AdventOfCode2017;
using Xunit;

namespace AdventOfCode2017Tests
{
    public class Day9Tests
    {
        [Fact]
        public void Day9()
        {
            var day = new Day9();
            Assert.Equal(15922, day.FirstPart());
            Assert.Equal(7314, day.SecondPart());
        }

        [Theory]
        [InlineData(@"{}", 1)]
        [InlineData(@"{{{}}}", 6)]
        [InlineData(@"{{},{}}", 5)]
        [InlineData(@"{{{},{},{{}}}}", 16)]
        [InlineData(@"{<a>,<a>,<a>,<a>}", 1)]
        [InlineData(@"{{<ab>},{<ab>},{<ab>},{<ab>}}", 9)]
        [InlineData(@"{{<!!>},{<!!>},{<!!>},{<!!>}}", 9)]
        [InlineData(@"{{<a!>},{<a!>},{<a!>},{<ab>}}", 3)]
        public void Day9_FirstPart(string input, int output)
        {
            Assert.Equal(output, new Day9(input).FirstPart());
        }

        [Theory]
        [InlineData(@"<>", 0)]
        [InlineData(@"<random characters>", 17)]
        [InlineData(@"<<<<>", 3)]
        [InlineData(@"<{!>}>", 2)]
        [InlineData(@"<!!>", 0)]
        [InlineData(@"<!!!>>", 0)]
        [InlineData("<{o\"i!a,<{i<a>", 10)]
        public void Day9_SecondPart(string input, int output)
        {
            Assert.Equal(output, new Day9(input).SecondPart());
        }
    }
}
