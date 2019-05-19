using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode2017
{
    public class Day23 : ISolver<int>
    {
        public readonly string input;

        public Day23(string input)
        {
            this.input = input;
        }

        public Day23()
        {
            input = Properties.Resources.Day23;
        }

        private (string, string, string)[] Input()
        {
            return input.Replace("\r", "")
                .Trim()
                .Split("\n")
                .Select(i => i.Split(" "))
                .Select(i => (i[0], i[1], i[2]))
                .ToArray();
        }

        public int FirstPart()
        {
            var input = Input();
            var dict = new Dictionary<string, int>();
            int pc = 0;
            int totalMul = 0;
            while (pc >= 0 && pc < input.Length)
            {
                var (instr, X, Y) = input[pc];
                switch (instr)
                {
                    case "set":
                        if (!dict.ContainsKey(X)) dict[X] = 0;
                        dict[X] = GetValue(Y, dict);
                        break;
                    case "sub":
                        if (!dict.ContainsKey(X)) dict[X] = 0;
                        dict[X] -= GetValue(Y, dict);
                        break;
                    case "mul":
                        ++totalMul;
                        if (!dict.ContainsKey(X)) dict[X] = 0;
                        dict[X] *= GetValue(Y, dict);
                        break;
                    case "jnz":
                        var mustJump = GetValue(X, dict) != 0;
                        if (mustJump)
                            pc += int.Parse(Y) - 1;
                        break;
                }
                ++pc;
            }
            return totalMul;
        }

        private int GetValue(string y, Dictionary<string, int> dict)
        {
            bool isNumber = int.TryParse(y, out int number);
            if (isNumber)
            {
                return number;
            } else
            {
                if (!dict.ContainsKey(y)) dict[y] = 0;
                return dict[y];
            }
        }

        /// <summary>
        /// Calculates the number of non prime numbers
        /// between (x*100 + 100000) and (x*100 + 100000) + 170000
        /// in steps of 17, where x is the initial value of b.
        /// </summary>
        /// <returns>The number of non-prime found numbers</returns>
        public int SecondPart()
        {
            int x = int.Parse(Input()[0].Item3) * 100 + 100000;
            var nonPrimes = 0;
            for (var i = x; i <= x + 17000; i += 17)
            {
                // Check if i is not prime
                if (Enumerable.Range(2, i - 3).Any(d => i % d == 0))
                {
                    ++nonPrimes;
                }
            }
            return nonPrimes;
        }
    }
}
