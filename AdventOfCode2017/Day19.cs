using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace AdventOfCode2017
{
    public class Day19 : ISolver<string>
    {
        public readonly string input;

        private string seenLetters;
        private int seenTiles;

        public Day19(string input)
        {
            this.input = input;
        }

        public Day19()
        {
            input = Properties.Resources.Day19;
        }

        private char[,] Input()
        {
            var lines = input.Replace("\r", "").Split("\n");
            int n = lines.Length;
            int m = lines[1].Length;
            char[,] res = new char[n, m];
            for (int i = 0; i < n; ++i)
            {
                for (int j = 0; j < m; ++j)
                {
                    res[i, j] = lines[i][j];
                }
            }
            return res;
        }

        private bool Accessible(char[,] mat, int y, int x)
        {
            return y >= 0 && x >= 0 && y < mat.GetLength(0) && x < mat.GetLength(1) && mat[y, x] != ' ';
        }

        private enum Direction
        {
            UP, DOWN, RIGHT, LEFT
        };

        private void UpAndDownTurn(ref char[,] mat, int y, ref int x, ref Direction dir, ref bool canContinue)
        {
            if (Accessible(mat, y, x + 1))
            {
                ++x;
                dir = Direction.RIGHT;
            }
            else if (Accessible(mat, y, x - 1))
            {
                --x;
                dir = Direction.LEFT;
            }
            else
            {
                canContinue = false;
            }
        }

        private void LeftAndRightTurn(ref char[,] mat, ref int y, int x, ref Direction dir, ref bool canContinue)
        {
            if (Accessible(mat, y - 1, x))
            {
                --y;
                dir = Direction.UP;
            }
            else if (Accessible(mat, y + 1, x))
            {
                ++y;
                dir = Direction.DOWN;
            }
            else
            {
                canContinue = false;
            }
        }


        void FindPath(char[,] mat, int x)
        {
            int y = 0;
            var dir = Direction.DOWN;

            seenLetters = "";
            seenTiles = 0;

            bool canContinue = true;
            while (canContinue)
            {
                ++seenTiles;
                if (mat[y, x] != '|' && mat[y, x] != '+' && mat[y, x] != '-' && mat[y, x] != ' ')
                {
                    seenLetters += mat[y, x];
                }

                switch (dir)
                {
                    case Direction.UP:
                    case Direction.DOWN:
                        if (dir == Direction.UP && Accessible(mat, y - 1, x))
                            --y;
                        else if (dir == Direction.DOWN && Accessible(mat, y + 1, x))
                            ++y;
                        else
                            UpAndDownTurn(ref mat, y, ref x, ref dir, ref canContinue);
                        break;

                    case Direction.LEFT:
                    case Direction.RIGHT:
                        if (dir == Direction.LEFT && Accessible(mat, y, x - 1))
                            --x;
                        else if (dir == Direction.RIGHT && Accessible(mat, y, x + 1))
                            ++x;
                        else
                            LeftAndRightTurn(ref mat, ref y, x, ref dir, ref canContinue);
                        break;
                }
            }

        }


        private int FirstPipe(char[,] mat)
        {
            for (int i = 0; ; ++i)
            {
                if (mat[0, i] == '|')
                {
                    return i;
                }
            }
        }

        public string FirstPart()
        {
            if (seenLetters == null)
            {
                var mat = Input();
                FindPath(mat, FirstPipe(mat));
            }
            return seenLetters;
        }


        public string SecondPart()
        {
            if (seenLetters == null)
            {
                var mat = Input();
                FindPath(mat, FirstPipe(mat));
            }
            return seenTiles.ToString();
        }
    }
}
