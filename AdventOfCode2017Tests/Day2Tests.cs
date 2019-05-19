using AdventOfCode2017;
using Xunit;

namespace AdventOfCode2017Tests
{
    public class Day2Tests
    {
        [Fact]
        public void Day2()
        {
            var day = new Day2();
            Assert.Equal(51139, day.FirstPart());
            Assert.Equal(272, day.SecondPart());
        }

        [Fact]
        public void Day2_FirstPart()
        {
            var myInput = @"5 1 9 5
7 5 3
2 4 6 8";
            Assert.Equal(18, new Day2(myInput).FirstPart());
        }

        [Fact]
        public void Day2_SecondPart()
        {
            var myInput = @"5 9 2 8
9 4 7 3
3 8 6 5";
            Assert.Equal(9, new Day2(myInput).SecondPart());
        }
    }
}
