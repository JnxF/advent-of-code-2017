using AdventOfCode2017;
using Xunit;

namespace AdventOfCode2017Tests
{
    public class Day18Tests
    {
        [Fact]
        public void Day18()
        {
            var day = new Day18();
            Assert.Equal(2951, day.FirstPart());
            Assert.Equal(7366, day.SecondPart());
        }

        [Fact]
        public void Day18_FirstPart()
        {
            var myInput = @"set a 1
add a 2
mul a a
mod a 5
snd a
set a 0
rcv a
jgz a -1
set a 1
jgz a -2";
            Assert.Equal(4, new Day18(myInput).FirstPart());
        }

        [Fact]
        public void Day24_SecondPart()
        {
            var myInput = @"snd 1
snd 2
snd p
rcv a
rcv b
rcv c
rcv d";
            Assert.Equal(3, new Day18(myInput).SecondPart());
        }
    }
}
