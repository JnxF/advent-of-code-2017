using System;

namespace AdventOfCode2017
{
    public class Day3 : ISolver
    {
        readonly int input;

        public Day3(int input)
        {
            this.input = input;
        }

        /* public static void Main()
        {
            var _ = new Day3(289326);
            Console.WriteLine(_.FirstPart());
            Console.WriteLine(_.SecondPart());
        } */


        enum Direction
        {
            Up = 0, Left = 1, Down = 2, Right = 3
        }

        public string FirstPart()
        {
            //int closestSquare = (int)Math.Sqrt(input);
            int sq = (int)Math.Floor((Math.Sqrt(input) - 1) / 2) + 1;

            static int Square(int x) => x * x;
            int s2 = Square(2 * (sq - 1) + 1);

            int rec = input - s2;
            int arista = 2 * sq + 1;

            int x = sq;
            int y = sq;

            var dir = Direction.Up;

            int aristaRestante = arista - 1;
            while (rec != 0)
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
                --rec;
                if (aristaRestante == 0)
                {
                    aristaRestante = arista - 1;
                    ++dir;
                }
            }

            return (Math.Abs(x) + Math.Abs(y)).ToString();
        }

        public string SecondPart()
        {
            throw new NotImplementedException();
        }
    }
}
