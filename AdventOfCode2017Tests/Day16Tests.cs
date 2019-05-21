using AdventOfCode2017;
using Xunit;

namespace AdventOfCode2017Tests
{
    public class Day16Tests
    {
        [Fact]
        public void Day16()
        {
            var day = new Day16();
            Assert.Equal("bkgcdefiholnpmja", day.FirstPart());
            Assert.Equal("knmdfoijcbpghlea", day.SecondPart());
        }

        [Theory]
        [InlineData("s1", "pabcdefghijklmno")]
        [InlineData("x0/1", "bacdefghijklmnop")]
        [InlineData("pf/m", "abcdemghijklfnop")]
        public void Day16_FirstPart(string input, string output)
        {
            Assert.Equal(output, new Day16(input).FirstPart());
        }
    }
}
