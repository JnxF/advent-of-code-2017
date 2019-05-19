using AdventOfCode2017;
using Xunit;

namespace AdventOfCode2017Tests
{
    public class Day12Tests
    {
        private readonly string _commonInput = @"0 <-> 2
1 <-> 1
2 <-> 0, 3, 4
3 <-> 2, 4
4 <-> 2, 3, 6
5 <-> 6
6 <-> 4, 5";

        [Fact]
        public void Day12()
        {
            var day = new Day12();
            Assert.Equal(283, day.FirstPart());
            Assert.Equal(195, day.SecondPart());
        }

        [Fact]
        public void Day12_FirstPart()
        {
            Assert.Equal(6, new Day12(_commonInput).FirstPart());
        }

        [Fact]
        public void Day12_SecondPart()
        {
            Assert.Equal(2, new Day12(_commonInput).SecondPart());
        }
    }
}
