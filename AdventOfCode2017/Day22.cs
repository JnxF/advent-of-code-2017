using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace AdventOfCode2017
{
    public class Day22 : ISolver<int>
    {
        public readonly string input;
        private const int GRID_SIZE = 1001;

        public Day22(string input)
        {
            this.input = input;
        }

        public Day22()
        {
            input = Properties.Resources.Day22;
        }


        private char[][] Input()
        {
            return input
                .Replace("\r", "")
                .Split("\n")
                .Select(i => i.ToCharArray())
                .ToArray();
        }

        private enum Direction
        {
            UP, RIGHT, DOWN, LEFT
        }

        public int FirstPart()
        {
            var mat = new bool[GRID_SIZE, GRID_SIZE];
            var input = Input();

            PlaceInputInMatrix(ref input, ref mat);

            int x = GRID_SIZE / 2;
            int y = GRID_SIZE / 2;

            var dir = Direction.UP;

            int totalInfected = 0;
            for (int i = 0; i < 10000; ++i)
            {
                // Print(ref mat, x, y);
                if (Move(ref mat, ref x, ref y, ref dir))
                {
                    ++totalInfected;
                }
            }

            return totalInfected;
        }


        public int SecondPart()
        {
            var mat = new CellStatus[GRID_SIZE, GRID_SIZE];
            var input = Input();

            PlaceInputInMatrix2(ref input, ref mat);

            int x = GRID_SIZE / 2;
            int y = GRID_SIZE / 2;

            var dir = Direction.UP;

            int totalInfected = 0;
            for (int i = 0; i < 10000000; ++i)
            {
                // Print(ref mat, x, y);
                if (Move2(ref mat, ref x, ref y, ref dir))
                {
                    ++totalInfected;
                }
            }

            return totalInfected;
        }

        private enum CellStatus
        {
            CLEAN, WEAKENED, INFECTED, FLAGGED
        }


        private bool Move(ref bool[,] mat, ref int x, ref int y, ref Direction dir)
        {
            bool causedInfection = false;
            if (mat[y, x])
                dir = dir == Direction.LEFT ? Direction.UP : dir + 1;
            else
                dir = dir == Direction.UP ? Direction.LEFT : dir - 1;

            if (!mat[y, x])
            {
                mat[y, x] = true;
                causedInfection = true;
            }
            else
            {
                mat[y, x] = false;
            }

            Continue(dir, ref x, ref y);
            return causedInfection;
        }


        private void PlaceInputInMatrix(ref char[][] input, ref bool[,] mat)
        {
            int m = input.Length;
            int p = (GRID_SIZE - m) / 2;

            for (int i = 0; i < m; ++i)
            {
                for (int j = 0; j < m; ++j)
                {
                    mat[i + p, j + p] = (input[i][j] == '#');
                }
            }
        }


        private bool Move2(ref CellStatus[,] mat, ref int x, ref int y, ref Direction dir)
        {
            bool causedInfection = false;
            switch (mat[y, x])
            {
                case CellStatus.CLEAN:
                    dir = dir == Direction.UP ? Direction.LEFT : dir - 1;
                    mat[y, x] = CellStatus.WEAKENED;
                    break;
                case CellStatus.INFECTED:
                    dir = dir == Direction.LEFT ? Direction.UP : dir + 1;
                    mat[y, x] = CellStatus.FLAGGED;
                    break;
                case CellStatus.WEAKENED:
                    mat[y, x] = CellStatus.INFECTED;
                    causedInfection = true;
                    break;
                case CellStatus.FLAGGED:
                    dir = (Direction)(((int)dir + 2) % 4);
                    mat[y, x] = CellStatus.CLEAN;
                    break;
            }
            Continue(dir, ref x, ref y);
            return causedInfection;
        }

        private void PlaceInputInMatrix2(ref char[][] input, ref CellStatus[,] mat)
        {
            int m = input.Length;
            int p = (GRID_SIZE - m) / 2;

            for (int i = 0; i < m; ++i)
            {
                for (int j = 0; j < m; ++j)
                {
                    mat[i + p, j + p] = (input[i][j] == '#' ? CellStatus.INFECTED : CellStatus.CLEAN);
                }
            }
        }

        private void Continue(Direction dir, ref int x, ref int y)
        {
            switch (dir)
            {
                case Direction.UP:
                    --y;
                    break;
                case Direction.RIGHT:
                    ++x;
                    break;
                case Direction.DOWN:
                    ++y;
                    break;
                case Direction.LEFT:
                    --x;
                    break;
            }
        }

    }
}
