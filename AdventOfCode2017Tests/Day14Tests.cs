using AdventOfCode2017;
using Xunit;

namespace AdventOfCode2017Tests
{
    public class Day14Tests
    {
        [Fact]
        public void Day14()
        {
            var day = new Day14();
            Assert.Equal(8304, day.FirstPart());
            Assert.Equal(1018, day.SecondPart());
        }

        [Fact]
        public void Day14_FirstPart()
        {
            Assert.Equal(8108, new Day14("flqrgnkx").FirstPart());
        }

        [Fact]
        public void Day14_SecondPart()
        {
            Assert.Equal(1242, new Day14("flqrgnkx").SecondPart());
        }
    }
}
