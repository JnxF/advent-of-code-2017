using AdventOfCode2017;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace AdventOfCode2017Tests
{
    public class Day7Tests
    {
        [Fact]
        public void Day7()
        {
            var day = new Day7();
            Assert.Equal("eqgvf", day.FirstPart());
            Assert.Equal("757", day.SecondPart());
        }

        [Fact]
        public void Day7_FirstPart()
        {
            var myInput = @"pbga (66)
xhth (57)
ebii (61)
havc (66)
ktlj (57)
fwft (72) -> ktlj, cntj, xhth
qoyq (66)
padx (45) -> pbga, havc, qoyq
tknk (41) -> ugml, padx, fwft
jptl (61)
ugml (68) -> gyxo, ebii, jptl
gyxo (61)
cntj (57)";
            Assert.Equal("tknk", new Day7(myInput).FirstPart());
        }

        [Fact]
        public void Day7_SecondPart()
        {
            var myInput = @"pbga (66)
xhth (57)
ebii (61)
havc (66)
ktlj (57)
fwft (72) -> ktlj, cntj, xhth
qoyq (66)
padx (45) -> pbga, havc, qoyq
tknk (41) -> ugml, padx, fwft
jptl (61)
ugml (68) -> gyxo, ebii, jptl
gyxo (61)
cntj (57)";
            Assert.Equal("60", new Day7(myInput).SecondPart());
        }

    }
}
