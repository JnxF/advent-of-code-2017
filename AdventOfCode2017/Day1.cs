using System;

namespace AdventOfCode2017
{
    public class Day1 : ISolver<int>
    {
        public readonly string input;

        public Day1(string input)
        {
            this.input = input;
        }

        public Day1()
        {
            input = Properties.Resources.Day1;
        }

        public int FirstPart()
        {
            int total = 0;
            for (int i = 0; i < input.Length; ++i)
            {
                var next = input[(i + 1) % input.Length];
                if (input[i] == next)
                {
                    total += int.Parse(input[i] + " ");
                }
            }
            return total;
        }

        public int SecondPart()
        {
            int total = 0;
            for (int i = 0; i < input.Length; ++i)
            {
                var next = input[(i + (input.Length / 2)) % input.Length];
                if (input[i] == next)
                {
                    total += int.Parse(input[i] + " ");
                }
            }
            return total;
        }
    }
}
