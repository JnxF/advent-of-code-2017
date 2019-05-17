using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode2017
{
    public class Day5 : ISolver
    {
     

        private int[] Input()
        {
            return Properties.Resources.Day5
                .Split("\n", StringSplitOptions.RemoveEmptyEntries)
                .Select(i => int.Parse(i))
                .ToArray();
        }
        public string FirstPart()
        {
            int pointer = 0;
            var input = Input();
            int n = input.Length;
            int counter;
            for (counter = 0; pointer >= 0 && pointer < n; ++counter)
            {
                ++input[pointer];
                pointer += input[pointer] - 1;
            }
            return counter.ToString();
        }

        public string SecondPart()
        {
            int pointer = 0;
            var input = Input();
            int n = input.Length;
            int counter;
            for (counter = 0; pointer >= 0 && pointer < n; ++counter)
            {
                int previous = input[pointer];
                
                if (previous >= 3)
                {
                    --input[pointer];
                } else
                {
                    ++input[pointer];
                }

                pointer += previous;
            }
            return counter.ToString();
        }
    }
}
