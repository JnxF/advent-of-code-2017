using AdventOfCode2017;
using System;
using Xunit;
using System.Linq;
using System.Reflection;

namespace AdventOfCode2017Tests
{
    public class UnitTest1
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
    }
}
