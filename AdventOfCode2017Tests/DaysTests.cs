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
        public void Day5()
        {
            var _ = new Day5();
            Assert.Equal("355965", _.FirstPart());
            Assert.Equal("26948068", _.SecondPart());
        }


        [Fact]
        public void Day6()
        {
            var _ = new Day6();
            Assert.Equal("12841", _.FirstPart());
            Assert.Equal("8038", _.SecondPart());
        }


        [Fact]
        public void Day8()
        {
            var _ = new Day8();
            Assert.Equal("5849", _.FirstPart());
            Assert.Equal("6702", _.SecondPart());
        }


        [Fact]
        public void Day9()
        {
            var _ = new Day9();
            Assert.Equal("15922", _.FirstPart());
            Assert.Equal("7314", _.SecondPart());
        }

        [Theory]
        [InlineData(@"{}", 1)]
        [InlineData(@"{{{}}}", 6)]
        [InlineData(@"{{},{}}", 5)]
        [InlineData(@"{{{},{},{{}}}}", 16)]
        [InlineData(@"{<a>,<a>,<a>,<a>}", 1)]
        [InlineData(@"{{<ab>},{<ab>},{<ab>},{<ab>}}", 9)]
        [InlineData(@"{{<!!>},{<!!>},{<!!>},{<!!>}}", 9)]
        [InlineData(@"{{<a!>},{<a!>},{<a!>},{<ab>}}", 3)]
        public void Day9_FirstPart(string expression, int value)
        {
            var _ = new Day9(expression);
            Assert.Equal(value.ToString(), _.FirstPart());
        }

        [Theory]
        [InlineData(@"<>", 0)]
        [InlineData(@"<random characters>", 17)]
        [InlineData(@"<<<<>", 3)]
        [InlineData(@"<{!>}>", 2)]
        [InlineData(@"<!!>", 0)]
        [InlineData(@"<!!!>>", 0)]
        [InlineData("<{o\"i!a,<{i<a>", 10)]
        public void Day9_SecondPart(string expression, int value)
        {
            var _ = new Day9(expression);
            Assert.Equal(value.ToString(), _.SecondPart());
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
