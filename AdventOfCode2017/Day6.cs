using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode2017
{
    public class Day6 : ISolver
    {

        public readonly string input;

        public Day6(string input)
        {
            this.input = input;
        }

        public Day6()
        {
            input = Properties.Resources.Day6;
        }
        private int[] Input()
        {
            return input
                .Split("\t", StringSplitOptions.RemoveEmptyEntries)
                .Select(n => int.Parse(n))
                .ToArray();
        }

        public int FirstPart()
        {
            var history = new HashSet<string>();

            static string converter(int[] a) => string.Join(",", a.Select(p => p.ToString()).ToArray());

            var input = Input();
            history.Add(converter(input));

            for (int i = 0; ; ++i)
            {
                input = Iterate(input);
                if (history.Contains(converter(input)))
                {
                    return i + 1;
                }
                history.Add(converter(input));
            }
        }

        private int[] Iterate(int[] input)
        {
            var argmax = ArgMax(input);
            var aRepartir = input[argmax];
            input[argmax] = 0;
            int i = (argmax + 1) % input.Length;
            while (aRepartir != 0)
            {
                ++input[i];
                i = (i + 1) % input.Length;
                --aRepartir;
            }
            return input;
        }

        private int ArgMax(int[] input)
        {
            var myMax = input[0];
            var myMaxI = 0;
            for (int i = 1; i < input.Length; ++i)
            {
                if (input[i] > myMax)
                {
                    myMax = input[i];
                    myMaxI = i;
                }
            }
            return myMaxI;
        }

        public int SecondPart()
        {
            var history = new Dictionary<string, int>();

            static string converter(int[] a) => string.Join(",", a.Select(p => p.ToString()).ToArray());

            var input = Input();
            history[converter(input)] = 0;

            for (int i = 0; ; ++i)
            {
                input = Iterate(input);
                if (history.Keys.Contains(converter(input)))
                {
                    return i - history[converter(input)];
                }
                history[converter(input)] = i;
            }
        }
    }
}
