using AdventOfCode2017;
using Xunit;

namespace AdventOfCode2017Tests
{
    public class Day17Tests
    {
        [Fact]
        public void Day17()
        {
            var day = new Day17();
            Assert.Equal(419, day.FirstPart());
            Assert.Equal(46038988, day.SecondPart());
        }

        [Fact]
        public void Day17_FirstPart()
        {
            Assert.Equal(638, new Day17(3).FirstPart());
        }
    }
}
