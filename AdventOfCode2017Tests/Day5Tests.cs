using AdventOfCode2017;
using Xunit;

namespace AdventOfCode2017Tests
{
    public class Day5Tests
    {
        [Fact]
        public void Day5()
        {
            var day = new Day5();
            Assert.Equal(355965, day.FirstPart());
            Assert.Equal(26948068, day.SecondPart());
        }

        [Fact]
        public void Day5_FirstPart()
        {
            Assert.Equal(5, new Day5("0\n3\n0\n1\n-3").FirstPart());
        }

        [Fact]
        public void Day5_SecondPart()
        {
            Assert.Equal(10, new Day5("0\n3\n0\n1\n-3").SecondPart());
        }
    }
}
