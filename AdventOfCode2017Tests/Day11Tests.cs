using AdventOfCode2017;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace AdventOfCode2017Tests
{
    public class Day11Tests
    {
        [Fact]
        public void Day11()
        {
            var day = new Day11();
            Assert.Equal(805, day.FirstPart());
            Assert.Equal(1535, day.SecondPart());
        }

        [Theory]
        [InlineData("ne,ne,ne", 3)]
        [InlineData("ne,ne,sw,sw", 0)]
        [InlineData("ne,ne,s,s", 2)]
        [InlineData("se,sw,se,sw,sw", 3)]
        public void Day11_FirstPart(string input, int output)
        {
            Assert.Equal(output, new Day11(input).FirstPart());
        }
    }
}
