using AdventOfCode2017;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace AdventOfCode2017Tests
{
    public class Day15Tests
    {
        [Fact]
        public void Day15()
        {
            var day = new Day15();
            Assert.Equal(650, day.FirstPart());
            Assert.Equal(336, day.SecondPart());
        }

        [Fact]
        public void Day15_FirstPart()
        {
            Assert.Equal(588, new Day15(65, 8921).FirstPart());
        }

        [Fact]
        public void Day15_SecondPart()
        {
            Assert.Equal(309, new Day15(65, 8921).SecondPart());
        }
    }
}
