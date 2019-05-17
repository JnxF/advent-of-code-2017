using AdventOfCode2017;
using Xunit;

namespace AdventOfCode2017Tests
{
    public class DaysTests
    {
        [Fact]
        public void Day1()
        {
            var _ = new Day1();
            Assert.Equal("1253", _.FirstPart());
            Assert.Equal("1278", _.SecondPart());
        }

        [Fact]
        public void Day2()
        {
            var _ = new Day2();
            Assert.Equal("51139", _.FirstPart());
            Assert.Equal("272", _.SecondPart());
        }

        [Fact]
        public void Day3()
        {
            var _ = new Day3(289326);
            Assert.Equal("419", _.FirstPart());
        }

        [Fact]
        public void Day4()
        {
            var _ = new Day4();
            Assert.Equal("386", _.FirstPart());
            Assert.Equal("208", _.SecondPart());
        }


        [Fact]
        public void Day6()
        {
            var _ = new Day6();
            Assert.Equal("12841", _.FirstPart());
            Assert.Equal("8038", _.SecondPart());
        }

        [Fact]
        public void Day12()
        {
            var _ = new Day12();
            Assert.Equal("283", _.FirstPart());
            Assert.Equal("195", _.SecondPart());
        }
    }
}
