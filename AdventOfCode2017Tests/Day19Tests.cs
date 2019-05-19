using AdventOfCode2017;
using Xunit;

namespace AdventOfCode2017Tests
{
    public class Day19Tests
    {
        [Fact]
        public void Day19()
        {
            var day = new Day19();
            Assert.Equal("XYFDJNRCQA", day.FirstPart());
            Assert.Equal("17450", day.SecondPart());
        }

        [Fact]
        public void Day19_FirstPart()
        {
            var myInput = @"     |          
     |  +--+    
     A  |  C    
 F---|----E|--+ 
     |  |  |  D 
     +B-+  +--+ ";
            Assert.Equal("ABCDEF", new Day19(myInput).FirstPart());
        }

        [Fact]
        public void Day19_SecondPart()
        {
            var myInput = @"     |          
     |  +--+    
     A  |  C    
 F---|----E|--+ 
     |  |  |  D 
     +B-+  +--+ ";
            Assert.Equal("38", new Day19(myInput).SecondPart());
        }
    }
}
