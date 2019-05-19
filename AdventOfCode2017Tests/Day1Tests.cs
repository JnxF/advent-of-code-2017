using AdventOfCode2017;
using Xunit;

namespace AdventOfCode2017Tests
{
    public class Day1Tests
    {
        [Fact]
        public void Day1()
        {
            var day = new Day1();
            Assert.Equal(1253, day.FirstPart());
            Assert.Equal(1278, day.SecondPart());
        }

        [Theory]
        [InlineData("1122", 3)]
        [InlineData("1111", 4)]
        [InlineData("1234", 0)]
        [InlineData("91212129", 9)]
        public void Day1_FirstPart(string input, int output)
        {
            Assert.Equal(output, new Day1(input).FirstPart());
        }

        [Theory]
        [InlineData("1212", 6)]
        [InlineData("1221", 0)]
        [InlineData("123425", 4)]
        [InlineData("123123", 12)]
        [InlineData("12131415", 4)]
        public void Day1_SecondPart(string input, int output)
        {
            Assert.Equal(output, new Day1(input).SecondPart());
        }
    }
}
