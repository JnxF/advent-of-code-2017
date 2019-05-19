using AdventOfCode2017;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace AdventOfCode2017Tests
{
    public class Day20Tests
    {
        [Fact]
        public void Day20()
        {
            var day = new Day20();
            Assert.Equal(170, day.FirstPart());
            Assert.Equal(571, day.SecondPart());
        }

        [Fact]
        public void Day20_FirstPart()
        {
            var myInput = @"p=< 3,0,0>, v=< 2,0,0>, a=<-1,0,0>
p=< 4,0,0>, v=< 0,0,0>, a=<-2,0,0>";
            Assert.Equal(0, new Day20(myInput).FirstPart());
        }

        [Fact]
        public void Day20_SecondPart()
        {
            var myInput = @"p=<-6,0,0>, v=<3,0,0>, a=<0,0,0>
p=<-4,0,0>, v=<2,0,0>, a=<0,0,0>
p=<-2,0,0>, v=<1,0,0>, a=<0,0,0>
p=<3,0,0>, v=<-1,0,0>, a=<0,0,0>";
            Assert.Equal(1, new Day20(myInput).SecondPart());
        }

        [Theory]
        [InlineData(1, -5, 6, 2, 3)] // (x-3)(x-2)
        [InlineData(0, 1, 1, null, null)] // Without a^2 term
        [InlineData(3, -30, 25 * 3, 5, 5)] // 3(x-5)^2
        [InlineData(1, -1, 0.25, null, null)] // (x-0.5)^2
        [InlineData(1, -2 * 0.95, 0.95 * 0.95, null, null)] // (x-0.95)^2
        [InlineData(1, -2 * 0.995, 0.995 * 0.995, null, null)] // (x-0.95)^2
        [InlineData(1, -2, 1, 1, 1)] // (x-1)^2
        [InlineData(1, 0, -1, 1, null)] // (x+1)(x-1) => x = 1
        [InlineData(1, 5, 6, null, null)] // (x+2)(x+3) => null
        [InlineData(1, 1, 0, 0, null)] // x(x+1) => 0
        public void Day20_SolveSecondDegreeEquation(double a, double b, double c, int? exp1, int? exp2)
        {
            Assert.Equal((exp1, exp2), AdventOfCode2017.Day20.SolveSecondDegreeEquation(a, b, c));
        }

        [Theory]
        [InlineData(5, -10, 2, false)] // 5x - 10 = 0 => x = 2
        [InlineData(2, -3, null, false)] // 2x - 3 = 0 => x = 3/2
        [InlineData(1, -0.999, null, false)] // x - 0.999 = 0 => null
        [InlineData(1, -1, 1, false)] // x - 1 = 0 => x = 1
        [InlineData(0, 5, null, true)] // 0x +5 = 0 => x = all values
        public void Day20_SolveFirstDegreeEquation(double b, double c, int? exp, bool inf)
        {
            Assert.Equal((exp, inf), AdventOfCode2017.Day20.SolveFirstDegreeEquation(b, c));
        }

        [Fact]
        public void Day20_CollisionParticlesMoment_Test1()
        {
            var p1 = new Day20.Particle { p1 = -6, p2 = 0, p3 = 0, v1 = 3, v2 = 0, v3 = 0, a1 = 0, a2 = 0, a3 = 0, };
            var p2 = new Day20.Particle { p1 = -4, p2 = 0, p3 = 0, v1 = 2, v2 = 0, v3 = 0, a1 = 0, a2 = 0, a3 = 0, };
            var p3 = new Day20.Particle { p1 = -2, p2 = 0, p3 = 0, v1 = 1, v2 = 0, v3 = 0, a1 = 0, a2 = 0, a3 = 0, };
            Assert.Equal(2, AdventOfCode2017.Day20.CollisionParticlesMoment(p1, p2));
            Assert.Equal(2, AdventOfCode2017.Day20.CollisionParticlesMoment(p1, p3));
            Assert.Equal(2, AdventOfCode2017.Day20.CollisionParticlesMoment(p2, p3));
        }

        [Fact]
        public void Day20_CollisionParticlesMoment_Test2()
        {
            var p1 = new Day20.Particle { p1 = 1, p2 = 0, p3 = 0, v1 = 1, v2 = 0, v3 = 0, a1 = 1, a2 = 0, a3 = 0, };
            var p2 = new Day20.Particle { p1 = -1, p2 = 0, p3 = 0, v1 = -1, v2 = 0, v3 = 0, a1 = -1, a2 = -2, a3 = 0, };
            Assert.Null(AdventOfCode2017.Day20.CollisionParticlesMoment(p1, p2));
        }

        [Fact]
        public void Day20_CollisionParticlesMoment_Test3()
        {
            var p1 = new Day20.Particle { p1 = 3, p2 = 0, p3 = 0, v1 = 0, v2 = 0, v3 = 0, a1 = -1, a2 = 0, a3 = 0 };
            var p2 = new Day20.Particle { p1 = 0, p2 = 3, p3 = 0, v1 = 0, v2 = 0, v3 = 0, a1 = 0, a2 = -1, a3 = 0 };
            Assert.Equal(2, AdventOfCode2017.Day20.CollisionParticlesMoment(p1, p2));
        }
    }
}
