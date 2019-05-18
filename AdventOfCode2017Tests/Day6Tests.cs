using AdventOfCode2017;
using Xunit;

namespace AdventOfCode2017Tests
{
    public class Day6Tests
    {
        [Fact]
        public void Day6()
        {
            var day = new Day6();
            Assert.Equal(12841, day.FirstPart());
            Assert.Equal(8038, day.SecondPart());
        }

        [Fact]
        public void Day6_FirstPart()
        {
            Assert.Equal(5, new Day6("0\t2\t7\t0").FirstPart());
        }

        [Fact]
        public void Day6_SecondPart()
        {
            Assert.Equal(4, new Day6("0\t2\t7\t0").SecondPart());
        }
    }
}
