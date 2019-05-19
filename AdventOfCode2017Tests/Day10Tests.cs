using AdventOfCode2017;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace AdventOfCode2017Tests
{
    public class Day10Tests
    {
        

        [Fact]
        public void Day10_Swap()
        {
            var a = 10;
            var b = 20;
            AdventOfCode2017.Day10.Swap(ref a, ref b);
            Assert.Equal(20, a);
            Assert.Equal(10, b);
        }

        [Theory]
        [InlineData(new[] { 1, 2, 3 }, 0, 2, new[] { 3, 2, 1 })]
        [InlineData(new[] { 10, 20, 30, 40, 50 }, 0, 1, new[] { 20, 10, 30, 40, 50 })]
        [InlineData(new[] { 10, 20, 30, 40, 50 }, 4, 4, new[] { 10, 20, 30, 40, 50 })]
        [InlineData(new[] { 1, 2, 3, 4, 5}, 1, 3, new[] { 1, 4, 3, 2, 5 })]
        [InlineData(new[] { 1, 2, 3, 4, 5}, 3, 1, new[] { 5, 4, 3, 2, 1 })]
        [InlineData(new[] { 1, 2, 3, 4, 5}, 4, 0, new[] { 5, 2, 3, 4, 1 })]
        public void Day10_ReverseSubarray(int[] actual, int i, int j, int[] expected)
        {
            AdventOfCode2017.Day10.ReverseSubarray(actual, i, j);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Day10_FirstPart()
        {
            var day = new Day10("3, 4, 1, 5", 5);
            Assert.Equal(12, day.FirstPart());
        }
    }
}
