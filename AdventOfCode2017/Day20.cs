using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace AdventOfCode2017
{
    public class Day20 : ISolver<int>
    {
        public readonly string input;

        public Day20(string input)
        {
            this.input = input;
        }

        public static void Main()
        {
            var k = new Day20();
            Console.WriteLine(k.FirstPart());
            Console.WriteLine(k.SecondPart());
        }

        public Day20()
        {
            input = Properties.Resources.Day20;
        }

        public class Particle
        {
            public int p1 { get; set; }
            public int p2 { get; set; }
            public int p3 { get; set; }
            public int v1 { get; set; }
            public int v2 { get; set; }
            public int v3 { get; set; }
            public int a1 { get; set; }
            public int a2 { get; set; }
            public int a3 { get; set; }

            public int A(int i) => i == 1 ? a1 : i == 2 ? a2 : a3;

            public int V(int i) => i == 1 ? v1 : i == 2 ? v2 : v3;

            public int P(int i) => i == 1 ? p1 : i == 2 ? p2 : p3;
        }

        private Particle[] Input()
        {
            return Regex.Split(input, @"\r?\n|\r")
                .Where(s => s != "")
                .Select(ParseLine)
                .ToArray();
        }

        private Particle ParseLine(string line)
        {
            Regex expression = new Regex(@"p=<\s*(-?\d+),\s*(-?\d+),\s*(-?\d+)>, v=<\s*(-?\d+),\s*(-?\d+),\s*(-?\d+)>, a=<\s*(-?\d+),\s*(-?\d+),\s*(-?\d+)>");
            var matches = expression.Matches(line);

            return new Particle
            {
                p1 = int.Parse(matches[0].Groups[1].Value),
                p2 = int.Parse(matches[0].Groups[2].Value),
                p3 = int.Parse(matches[0].Groups[3].Value),
                v1 = int.Parse(matches[0].Groups[4].Value),
                v2 = int.Parse(matches[0].Groups[5].Value),
                v3 = int.Parse(matches[0].Groups[6].Value),
                a1 = int.Parse(matches[0].Groups[7].Value),
                a2 = int.Parse(matches[0].Groups[8].Value),
                a3 = int.Parse(matches[0].Groups[9].Value),
            };
        }

        public int FirstPart()
        {
            var input = Input();
            var pairedInput = input.Zip(Enumerable.Range(0, input.Length), (part, index) => (index, part));
            return pairedInput.OrderBy(p => Math.Abs(p.part.a1) + Math.Abs(p.part.a2) + Math.Abs(p.part.a3))
                .ThenBy(p => Math.Abs(p.part.v1) + Math.Abs(p.part.v2) + Math.Abs(p.part.v3))
                .ThenBy(p => Math.Abs(p.part.p1) + Math.Abs(p.part.p2) + Math.Abs(p.part.p3))
                .First().index;
        }


        public int SecondPart()
        {
            var particles = Input();

            for (int iteration = 0; iteration < 900; ++iteration)
            {
                int n = particles.Length;
                bool[] validParticles = new bool[n];
                for (int i = 0; i < n; ++i) validParticles[i] = true;

                var calculatedTime = new Dictionary<(int, int), int?>();

                int? tMin = null;
                for (int i = 0; i < n; ++i)
                {
                    for (int j = i + 1; j < n; ++j)
                    {
                        int? t = CollisionParticlesMoment(particles[i], particles[j]);
                        calculatedTime[(i, j)] = t;
                        if (tMin == null || (t != null && t < tMin))
                        {
                            tMin = t;
                        }
                    }
                }

                for (int i = 0; i < n; ++i)
                {
                    for (int j = i + 1; j < n; ++j)
                    {
                        int? t = calculatedTime[(i, j)];
                        if (t != null && t == tMin)
                        {
                            validParticles[i] = false;
                            validParticles[j] = false;
                        }
                    }
                }

                HashSet<Particle> survivals = new HashSet<Particle>();
                for (int i = 0; i < n; ++i)
                {
                    if (validParticles[i])
                    {
                        survivals.Add(particles[i]);
                    }
                }

                particles = survivals.ToArray();
                if (n == particles.Length) break;
            }

            return particles.Length;
        }

        public static (int?, int?) SolveSecondDegreeEquation(double a, double b, double c)
        {
            if (a == 0) return (null, null);
            var disc = b * b - 4 * a * c;
            var sqr = Math.Sqrt(disc);

            var sol1 = (-b + sqr) / (2 * a);
            var sol2 = (-b - sqr) / (2 * a);
            int? sol1Rounded = null;
            int? sol2Rounded = null;

            if (Math.Abs(sol1 - Math.Round(sol1)) < 0.0001 && sol1 >= 0)
            {
                sol1Rounded = Convert.ToInt32(Math.Round(sol1));
            }

            if (Math.Abs(sol2 - Math.Round(sol2)) < 0.0001 && sol2 >= 0)
            {
                sol2Rounded = Convert.ToInt32(Math.Round(sol2));
            }

            int? hueco1 = null;
            int? hueco2 = null;
            if (sol2Rounded != null && sol2Rounded >= 0) hueco1 = sol2Rounded;
            if (sol1Rounded != null && sol1Rounded >= 0) hueco2 = sol1Rounded;
            if (hueco1 == null) { hueco1 = hueco2; hueco2 = null; }
            return (hueco1, hueco2);
        }

        public static (int?, bool inf) SolveFirstDegreeEquation(double b, double c)
        {
            if (b == 0) return (null, true);
            double sol = -c / b;

            if (Math.Abs(sol - Math.Round(sol)) < 0.0001 && sol >= 0)
            {
                return (Convert.ToInt32(Math.Round(sol)), false);
            }
            return (null, false);
        }

        private static (HashSet<int>, bool infinite) TimeSolutionsPerCoordinate(Particle m1, Particle m2, int coordinate)
        {
            double a = (m1.A(coordinate) - m2.A(coordinate)) / 2.0;
            double b = m1.V(coordinate) - m2.V(coordinate) + (m1.A(coordinate) - m2.A(coordinate)) / 2.0;
            double c = m1.P(coordinate) - m2.P(coordinate);

            HashSet<int> sols = new HashSet<int>();
            bool inf = false;
            if (a == 0)
            {
                (var solution, bool myInf) = SolveFirstDegreeEquation(b, c);
                inf = myInf;
                if (solution != null) sols.Add(solution.Value);
            } else
            {
                (int? s1, int? s2) = SolveSecondDegreeEquation(a, b, c);
                if (s1 != null) sols.Add(s1.Value);
                if (s2 != null) sols.Add(s2.Value);
            }
            return (sols, inf);
        }

        public static int? CollisionParticlesMoment(Particle m1, Particle m2)
        {
            var (x, x_inf) = TimeSolutionsPerCoordinate(m1, m2, 1);
            var (y, y_inf) = TimeSolutionsPerCoordinate(m1, m2, 2);
            var (z, z_inf) = TimeSolutionsPerCoordinate(m1, m2, 3);

            HashSet<int> resSet;
            if (!x_inf) resSet = x;
            else if (!y_inf) resSet = y;
            else if (!z_inf) resSet = z;
            else return 0;

            if (!x_inf) resSet.IntersectWith(x);
            if (!y_inf) resSet.IntersectWith(y);
            if (!z_inf) resSet.IntersectWith(z);

            if (resSet.Any())
            {
                return resSet.Min();
            }
            else
            {
                return null;
            }
        }
    }
}
