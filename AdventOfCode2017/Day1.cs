using System;

namespace AdventOfCode2017
{
    public class Day1 : ISolver
    {
        public string FirstPart()
        {
            var number = Properties.Resources.Day1;
            int total = 0;
            for (int i = 0; i < number.Length; ++i)
            {
                var next = number[(i + 1) % number.Length];
                if (number[i] == next)
                {
                    total += int.Parse(number[i] + " ");
                }
            }
            return total.ToString();
        }

        public string SecondPart()
        {
            var number = Properties.Resources.Day1;
            int total = 0;
            for (int i = 0; i < number.Length; ++i)
            {
                var next = number[(i + (number.Length / 2)) % number.Length];
                if (number[i] == next)
                {
                    total += int.Parse(number[i] + " ");
                }
            }
            return total.ToString();
        }
    }
}
