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
        public void Day10()
        {
            var day = new Day10();
            Assert.Equal("23715", day.FirstPart());
            Assert.Equal("9496857a6a8dd1104df1a801e9237d79", day.SecondPart());
        }
 

        [Theory]
        [InlineData(new[] { 1, 2, 3 }, 0, 2, new[] { 3, 2, 1 })]
        [InlineData(new[] { 10, 20, 30, 40, 50 }, 0, 1, new[] { 20, 10, 30, 40, 50 })]
        [InlineData(new[] { 10, 20, 30, 40, 50 }, 4, 4, new[] { 10, 20, 30, 40, 50 })]
        [InlineData(new[] { 1, 2, 3, 4, 5 }, 1, 3, new[] { 1, 4, 3, 2, 5 })]
        [InlineData(new[] { 1, 2, 3, 4, 5 }, 3, 1, new[] { 5, 4, 3, 2, 1 })]
        [InlineData(new[] { 1, 2, 3, 4, 5 }, 4, 0, new[] { 5, 2, 3, 4, 1 })]
        public void Day10_ReverseSubarray(int[] actual, int i, int j, int[] expected)
        {
            AdventOfCode2017.Day10.ReverseSubarray(actual, i, j);
            Assert.Equal(expected, actual);
        }


        [Fact]
        public void Day10_FirstPart()
        {
            var day = new Day10("3,4,1,5", 5);
            Assert.Equal("12", day.FirstPart());
        }
        [Fact]
        public void Day10_Input2()
        {
            var day = new Day10("1,2,3", 5);
            Assert.Equal(new byte[] { 49, 44, 50, 44, 51, 17, 31, 73, 47, 23 }, day.Input2());
        }

        [Theory]
        [InlineData("", "a2582a3a0e66e6e86e3812dcb672a272")]
        [InlineData("AoC 2017", "33efeb34ea91902bb2f59c9920caa6cd")]
        [InlineData("1,2,3", "3efbe78a8d82f29979031a4aa0b16a9d")]
        [InlineData("1,2,4", "63960835bcdc130f0b66d7ff4f6a5a8e")]
        [InlineData(",,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,", "4025d0367a524e323cfc75a663f0d384")]
        public void Day10_SecondPart(string input, string output)
        {
            Assert.Equal(output, new Day10(input, 256).SecondPart());
        }
    }
}
