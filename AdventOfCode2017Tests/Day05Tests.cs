using AdventOfCode2017;
using Xunit;

namespace AdventOfCode2017Tests
{
    public class Day05Tests
    {
        [Fact]
        public void Day05()
        {
            var day = new Day05();
            Assert.Equal(355965, day.FirstPart());
            Assert.Equal(26948068, day.SecondPart());
        }

        [Fact]
        public void Day05_FirstPart()
        {
            Assert.Equal(5, new Day05("0\n3\n0\n1\n-3").FirstPart());
        }

        [Fact]
        public void Day05_SecondPart()
        {
            Assert.Equal(10, new Day05("0\n3\n0\n1\n-3").SecondPart());
        }
    }
}
