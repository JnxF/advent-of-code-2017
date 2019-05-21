using AdventOfCode2017;
using Xunit;

namespace AdventOfCode2017Tests
{
    public class Day25Tests
    {
        [Fact]
        public void Day25()
        {
            var day = new Day25();
            Assert.Equal(4217, day.FirstPart());
        }

        [Fact]
        public void Day25_FirstPart()
        {
            var myInput = @"Begin in state A.
Perform a diagnostic checksum after 6 steps.

In state A:
  If the current value is 0:
    - Write the value 1.
    - Move one slot to the right.
    - Continue with state B.
  If the current value is 1:
    - Write the value 0.
    - Move one slot to the left.
    - Continue with state B.

In state B:
  If the current value is 0:
    - Write the value 1.
    - Move one slot to the left.
    - Continue with state A.
  If the current value is 1:
    - Write the value 1.
    - Move one slot to the right.
    - Continue with state A.";
            Assert.Equal(3, new Day25(myInput, 6).FirstPart());
        }
    }
}
