using AdventOfCode2017;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace AdventOfCode2017Tests
{
    public class Day23Tests
    {
        [Fact]
        public void Day23()
        {
            var day = new Day23();
            Assert.Equal(3025, day.FirstPart());
            Assert.Equal(915, day.SecondPart());
        }
    }
}
