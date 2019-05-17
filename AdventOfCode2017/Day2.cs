using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode2017
{
    public class Day2 : ISolver
    {
        public static void Main(string[] args)
        {
            var _ = new Day2();
            Console.WriteLine(_.FirstPart());
            Console.WriteLine(_.SecondPart());
        }

        IEnumerable<int>[] Input()
        {
           return Regex.Split(Properties.Resources.Day2.Trim(), @"\r?\n|\r").Select(t => Regex.Split(t.Trim(), @"\s+|\t+").Select(i => int.Parse(i))).ToArray();
        }

        public string FirstPart()
        {
            var input = Input();
            var total = 0;
            foreach (var fila in input)
            {
                total += fila.Max() - fila.Min();
            }
            return total.ToString();
        }

        public string SecondPart()
        {
            var input = Input();
            var total = 0;
            foreach (var fila in input)
            {
                var divis = Divis(fila.ToArray());
                total += divis;
            }
            return total.ToString();
        }

        private int Divis(int[] v)
        {
            int n = v.Length;
            for (int i = 0; i < n; ++i)
            {
                for (int j = i + 1; j < n; ++j)
                {
                    if (v[i] % v[j] == 0) return v[i] / v[j];
                    if (v[j] % v[i] == 0) return v[j]/v[i];
                }
            }
            return default;
        }
    }
}
