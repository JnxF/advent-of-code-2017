using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode2017
{
    public class Day11 : ISolver<int>
    {
        public readonly string input;

        public Day11(string input)
        {
            this.input = input;
        }

        public Day11()
        {
            input = Properties.Resources.Day11;
        }

        private string[] Input()
        {
            return input.Split(",");
        }

        public int FirstPart()
        {
            int x = 0, y = 0, z = 0;
            foreach (var step in Input())
            {
                switch (step)
                {
                    case "n":
                        ++y; --z;
                        break;
                    case "s":
                        --y; ++z;
                        break;
                    case "ne":
                        ++x; --z;
                        break;
                    case "se":
                        ++x; --y;
                        break;
                    case "nw":
                        --x; ++y;
                        break;
                    case "sw":
                        --x; ++z;
                        break;
                }
            }
            return (Math.Abs(x) + Math.Abs(y) + Math.Abs(z))/ 2;
        }

        public int SecondPart()
        {
            int max = 0;
            int x = 0, y = 0, z = 0;
            foreach (var step in Input())
            {
                switch (step)
                {
                    case "n":
                        ++y; --z;
                        break;
                    case "s":
                        --y; ++z;
                        break;
                    case "ne":
                        ++x; --z;
                        break;
                    case "se":
                        ++x; --y;
                        break;
                    case "nw":
                        --x; ++y;
                        break;
                    case "sw":
                        --x; ++z;
                        break;
                }
                max = Math.Max(max, (Math.Abs(x) + Math.Abs(y) + Math.Abs(z)) / 2);
            }
            return max;
        }
    }
}
