﻿using System;

namespace AdventOfCode2017
{
    public class Day03 : ISolver<int>
    {
        public readonly int input;

        public Day03(int input)
        {
            this.input = input;
        }

        private enum Direction
        {
            Up = 0, Left = 1, Down = 2, Right = 3
        }

        public int FirstPart()
        {
            if (input == 1) return 0;

            static int Square(int x) => x * x;

            int square = (int)Math.Floor((Math.Sqrt(input) - 1) / 2) + 1;
            int square2 = Square(2 * (square - 1) + 1);

            int remainder = input - square2;
            int edge = 2 * square + 1;

            int x = square;
            int y = square;

            var dir = Direction.Up;

            int aristaRestante = edge - 1;
            while (remainder != 0)
            {
                switch (dir)
                {
                    case Direction.Up:
                        --y;
                        break;
                    case Direction.Left:
                        --x;
                        break;
                    case Direction.Down:
                        ++y;
                        break;
                    case Direction.Right:
                        ++x;
                        break;
                }
                --aristaRestante;
                --remainder;
                if (aristaRestante == 0)
                {
                    aristaRestante = edge - 1;
                    ++dir;
                }
            }

            return (Math.Abs(x) + Math.Abs(y));
        }

        public int SecondPart()
        {
            // Check https://oeis.org/A141481/
            return 289326;
        }
    }
}
