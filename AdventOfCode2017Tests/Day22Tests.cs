using AdventOfCode2017;
using Xunit;

namespace AdventOfCode2017Tests
{
    public class Day22Tests
    {
        [Fact]
        public void Day22()
        {
            var day = new Day22();
            Assert.Equal(5460, day.FirstPart());
            Assert.Equal(2511702, day.SecondPart());
        }

        [Fact]
        public void Day22_FirstPart()
        {
            var myInput = @"..#
#..
...";
            Assert.Equal(5587, new Day22(myInput).FirstPart());
        }

        [Fact]
        public void Day22_SecondPart()
        {
            var myInput = @"..#
#..
...";
            Assert.Equal(2511944, new Day22(myInput).SecondPart());
        }
    }
}
