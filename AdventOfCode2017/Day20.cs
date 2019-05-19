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

        public Day20()
        {
            input = Properties.Resources.Day20;
        }

        public class Particle
        {
            public int P1 { get; set; }
            public int P2 { get; set; }
            public int P3 { get; set; }
            public int V1 { get; set; }
            public int V2 { get; set; }
            public int V3 { get; set; }
            public int A1 { get; set; }
            public int A2 { get; set; }
            public int A3 { get; set; }

            public int A(int i) => i == 1 ? A1 : i == 2 ? A2 : A3;

            public int V(int i) => i == 1 ? V1 : i == 2 ? V2 : V3;

            public int P(int i) => i == 1 ? P1 : i == 2 ? P2 : P3;
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
                P1 = int.Parse(matches[0].Groups[1].Value),
                P2 = int.Parse(matches[0].Groups[2].Value),
                P3 = int.Parse(matches[0].Groups[3].Value),
                V1 = int.Parse(matches[0].Groups[4].Value),
                V2 = int.Parse(matches[0].Groups[5].Value),
                V3 = int.Parse(matches[0].Groups[6].Value),
                A1 = int.Parse(matches[0].Groups[7].Value),
                A2 = int.Parse(matches[0].Groups[8].Value),
                A3 = int.Parse(matches[0].Groups[9].Value),
            };
        }

        public int FirstPart()
        {
            var input = Input();
            var pairedInput = input.Zip(Enumerable.Range(0, input.Length), (part, index) => (index, part));
            return pairedInput.OrderBy(p => Math.Abs(p.part.A1) + Math.Abs(p.part.A2) + Math.Abs(p.part.A3))
                .ThenBy(p => Math.Abs(p.part.V1) + Math.Abs(p.part.V2) + Math.Abs(p.part.V3))
                .ThenBy(p => Math.Abs(p.part.P1) + Math.Abs(p.part.P2) + Math.Abs(p.part.P3))
                .First().index;
        }

        private int? CalculateCollisionTimes(ref Particle[] particles, out Dictionary<(int, int), int?> calculatedTimes)
        {
            int n = particles.Length;
            bool[] validParticles = new bool[n];
            for (int i = 0; i < n; ++i) validParticles[i] = true;

            calculatedTimes = new Dictionary<(int, int), int?>();

            int? tMin = null;
            for (int i = 0; i < n; ++i)
            {
                for (int j = i + 1; j < n; ++j)
                {
                    int? t = CollisionParticlesMoment(particles[i], particles[j]);
                    calculatedTimes[(i, j)] = t;
                    if (tMin == null || (t != null && t < tMin))
                    {
                        tMin = t;
                    }
                }
            }
            return tMin;
        }

        private bool[] FindValidParticles(int n, ref Dictionary<(int,int), int?> calculatedTimes, int? tMin)
        {
            bool[] validParticles = new bool[n];
            for (int i = 0; i < n; ++i) validParticles[i] = true;
            for (int i = 0; i < n; ++i)
            {
                for (int j = i + 1; j < n; ++j)
                {
                    int? t = calculatedTimes[(i, j)];
                    if (t != null && t == tMin)
                    {
                        validParticles[i] = false;
                        validParticles[j] = false;
                    }
                }
            }
            return validParticles;
        }

        public int SecondPart()
        {
            var particles = Input();

            for (int iteration = 0; iteration < 900; ++iteration)
            {
                int n = particles.Length;
                int? tMin = CalculateCollisionTimes(ref particles, out var calculatedTimes);
                bool[] validParticles = FindValidParticles(n, ref calculatedTimes, tMin);

                // Recalculate particles
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
            int? sol1Rounded = null, sol2Rounded = null;

            if (Math.Abs(sol1 - Math.Round(sol1)) < 0.0001 && sol1 >= 0)
                sol1Rounded = Convert.ToInt32(Math.Round(sol1));

            if (Math.Abs(sol2 - Math.Round(sol2)) < 0.0001 && sol2 >= 0)
                sol2Rounded = Convert.ToInt32(Math.Round(sol2));

            int? hueco1 = null, hueco2 = null;
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
                return (Convert.ToInt32(Math.Round(sol)), false);

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

            return resSet.Any() ? new int?(resSet.Min()) : null;
        }
    }
}
