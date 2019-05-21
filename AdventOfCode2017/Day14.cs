using AdventOfCode2017.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode2017
{
    public class Day14 : ISolver<int>
    {
        public readonly string input;

        public Day14(string input)
        {
            this.input = input;
        }

        public Day14()
        {
            input = "hwlqcszp";
        }

        private static string Encode(string s) => new Day10(s).SecondPart();

        public int FirstPart()
        {
            return BuildMatrix().Cast<char>().ToArray().Where(i => i == '1').Count();
        }

        public int SecondPart()
        {
            char[,] mat = BuildMatrix();
            int numberOkay = mat.Cast<char>().ToArray().Where(i => i == '1').Count();
            int[,] posicionUF = CalcularPositionUF(mat);
            return CalculateGroups(mat, numberOkay, posicionUF); 
        }

        private static int[,] CalcularPositionUF(char[,] mat)
        {
            int[,] posicionUF = new int[128, 128];
            int ant = -1;
            for (int i = 0; i < 128; ++i)
            {
                for (int j = 0; j < 128; ++j)
                {
                    if (mat[i, j] == '1')
                    {
                        ++ant;
                        posicionUF[i, j] = ant;
                    }
                }
            }
            return posicionUF;
        }

        private static int CalculateGroups(char[,] mat, int numberOkay, int[,] posicionUF)
        {
            var uf = new UnionFind(numberOkay);
            for (int i = 0; i < 128; ++i)
            {
                for (int j = 0; j < 128; ++j)
                {
                    if (mat[i, j] == '0') continue;
                    var positions = new (int, int)[] { (1, 0), (-1, 0), (0, 1), (0, -1) };

                    foreach (var (di, dj) in positions)
                    {
                        if (i + di >= 0 && j + dj >= 0 && i + di < 128 && j + dj < 128 && mat[i + di, j + dj] == '1')
                        {
                            uf.Union(posicionUF[i, j], posicionUF[i + di, j + dj]);
                        }
                    }
                }
            }
            return uf.Count;
        }

        private char[,] BuildMatrix()
        {
            char[,] mat = new char[128, 128];
            for (int i = 0; i < 128; ++i)
            {
                var d = Encode(input + "-" + i);
                var binary = string.Join("",
                  d.Select(c => Convert.ToString(Convert.ToInt32(c.ToString(), 16), 2).PadLeft(4, '0'))
                );
                for (int j = 0; j < 128; ++j)
                {
                    mat[i, j] = binary[j];
                }
            }
            return mat;
        }
    }
}
