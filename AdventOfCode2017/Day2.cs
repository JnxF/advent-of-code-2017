using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode2017
{
    public class Day2 : ISolver<int>
    {
        public readonly string input;

        public Day2(string input)
        {
            this.input = input;
        }

        public Day2()
        {
            input = Properties.Resources.Day2;
        }

        IEnumerable<IEnumerable<int>> Input()
        {
            return input.Replace("\r", "")
            .Split("\n")
            .Where(_ => _.Trim() != "")
            .Select(line => Regex.Split(line.Trim(), @"\s+|\t+")
            .Where(_ => _.Trim() != "")
            .Select(j => int.Parse(j)));
        }

        public int FirstPart()
        {
            var input = Input();
            var total = 0;
            foreach (var row in input)
            {
                total += row.Max() - row.Min();
            }
            return total;
        }

        public int SecondPart()
        {
            var input = Input();
            var total = 0;
            foreach (var row in input)
            {
                var divis = DivisionOfDivisibleNumbers(row.ToArray());
                total += divis;
            }
            return total;
        }

        private int DivisionOfDivisibleNumbers(int[] row)
        {
            int n = row.Length;
            for (int i = 0; i < n; ++i)
            {
                for (int j = i + 1; j < n; ++j)
                {
                    if (row[i] % row[j] == 0) return row[i] / row[j];
                    if (row[j] % row[i] == 0) return row[j] / row[i];
                }
            }
            return default;
        }
    }
}
