using AdventOfCode2017;
using Xunit;

namespace AdventOfCode2017Tests
{
    public class Day06Tests
    {
        [Fact]
        public void Day06()
        {
            var day = new Day06();
            Assert.Equal(12841, day.FirstPart());
            Assert.Equal(8038, day.SecondPart());
        }

        [Fact]
        public void Day06_FirstPart()
        {
            Assert.Equal(5, new Day06("0\t2\t7\t0").FirstPart());
        }

        [Fact]
        public void Day06_SecondPart()
        {
            Assert.Equal(4, new Day06("0\t2\t7\t0").SecondPart());
        }
    }
}
