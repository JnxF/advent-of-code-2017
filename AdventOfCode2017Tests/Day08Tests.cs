using AdventOfCode2017;
using Xunit;

namespace AdventOfCode2017Tests
{
    public class Day08Tests
    {
        private readonly string _commonInput = @"b inc 5 if a > 1
a inc 1 if b < 5
c dec -10 if a >= 1
c inc -20 if c == 10";

        [Fact]
        public void Day08()
        {
            var day = new Day08();
            Assert.Equal(5849, day.FirstPart());
            Assert.Equal(6702, day.SecondPart());
        }

        [Fact]
        public void Day08_FirstPart()
        {
            Assert.Equal(1, new Day08(_commonInput).FirstPart());
        }

        [Fact]
        public void Day08_SecondPart()
        {
            Assert.Equal(10, new Day08(_commonInput).SecondPart());
        }
    }
}
