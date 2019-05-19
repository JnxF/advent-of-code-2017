using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode2017
{
    public class Day17 : ISolver<int>
    {
        public readonly int input;

        public Day17(int input)
        {
            this.input = input;
        }

        public Day17()
        {
            input = 386;
        }

        public int FirstPart()
        {
            List<int> list = new List<int> { 0 };
            int pointer = 0;
            for (int i = 1; i <= 2017; ++i)
            {
                pointer += input;
                pointer %= list.Count;
                list.Insert(pointer + 1, i);
                pointer = (pointer + 1) % list.Count;
            }
            return list[(pointer + 1) % list.Count];
        }

        public int SecondPart()
        {
            var pointer = 0;
            var found = 0;
            for (int i = 1; i < 50000000; i++)
            {
                pointer = ((pointer + input) % i) + 1;
                if (pointer == 1)
                {
                    found = i;
                }
            }
            return found;
        }
    }
}
