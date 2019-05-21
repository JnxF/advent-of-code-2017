using AdventOfCode2017;
using Xunit;

namespace AdventOfCode2017Tests
{
    public class Day13Tests
    {
        [Fact]
        public void Day13()
        {
            var day = new Day13();
            Assert.Equal(1640, day.FirstPart());
            Assert.Equal(3960702, day.SecondPart());
        }

        [Fact]
        public void Day13_FirstPart()
        {
            var myInput = @"0: 3
1: 2
4: 4
6: 4";
            Assert.Equal(24, new Day13(myInput).FirstPart());
        }

        [Fact]
        public void Day13_SecondPart()
        {
            var myInput = @"0: 3
1: 2
4: 4
6: 4";
            Assert.Equal(10, new Day13(myInput).SecondPart());
        }

    }
}
