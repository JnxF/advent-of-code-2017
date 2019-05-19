using AdventOfCode2017;
using Xunit;

namespace AdventOfCode2017Tests
{
    public class Day24Tests
    {
        [Fact]
        public void Day24()
        {
            var day = new Day24();
            Assert.Equal(1940, day.FirstPart());
            Assert.Equal(1928, day.SecondPart());
        }

        [Fact]
        public void Day24_FirstPart()
        {
            var myInput = @"0/2
2/2
2/3
3/4
3/5
0/1
10/1
9/10";
            Assert.Equal(31, new Day24(myInput).FirstPart());
        }

        [Fact]
        public void Day24_SecondPart()
        {
            var myInput = @"0/2
2/2
2/3
3/4
3/5
0/1
10/1
9/10";
            Assert.Equal(19, new Day24(myInput).SecondPart());
        }
    }
}
