using AdventOfCode2017;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace AdventOfCode2017Tests
{
    public class Day21Tests
    {
        [Fact]
        public void Day21()
        {
            var day = new Day21();
            Assert.Equal(125, day.FirstPart());
            Assert.Equal(1782917, day.SecondPart());
        }

        [Fact]
        public void Day21_FirstPart()
        {
            var myInput = @"../.# => ##./#../..." + "\n" + @".#./..#/### => #..#/..../..../#..#";
            Assert.Equal(12, new Day21(myInput, 2).FirstPart());
        }
    }
}
