using AdventOfCode2017;
using Xunit;

namespace AdventOfCode2017Tests
{
    public class Day07Tests
    {
        [Fact]
        public void Day07()
        {
            var day = new Day07();
            Assert.Equal("eqgvf", day.FirstPart());
            Assert.Equal("757", day.SecondPart());
        }

        [Fact]
        public void Day07_FirstPart()
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
            Assert.Equal("tknk", new Day07(myInput).FirstPart());
        }

        [Fact]
        public void Day07_SecondPart()
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
            Assert.Equal("60", new Day07(myInput).SecondPart());
        }

    }
}
