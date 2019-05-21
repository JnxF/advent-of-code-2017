using AdventOfCode2017;
using Xunit;

namespace AdventOfCode2017Tests
{
    public class Day02Tests
    {
        [Fact]
        public void Day02()
        {
            var day = new Day02();
            Assert.Equal(51139, day.FirstPart());
            Assert.Equal(272, day.SecondPart());
        }

        [Fact]
        public void Day02_FirstPart()
        {
            var myInput = @"5 1 9 5
7 5 3
2 4 6 8";
            Assert.Equal(18, new Day02(myInput).FirstPart());
        }

        [Fact]
        public void Day02_SecondPart()
        {
            var myInput = @"5 9 2 8
9 4 7 3
3 8 6 5";
            Assert.Equal(9, new Day02(myInput).SecondPart());
        }
    }
}
