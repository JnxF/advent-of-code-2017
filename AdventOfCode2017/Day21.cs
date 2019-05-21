using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2017
{
    public class Day21 : ISolver<int>
    {
        public readonly string input;
        public readonly int iterationsPart1;

        public Day21(string input, int iterations=5)
        {
            this.input = input;
            this.iterationsPart1 = iterations;
        }

        public Day21()
        {
            input = Properties.Resources.Day21;
            iterationsPart1 = 5;
        }

        private Dictionary<string, string> Input()
        {
            return input.Replace("\r", "")
                .Trim()
                .Split("\n")
                .Select(i => i.Split(" => "))
                .Select(i => new KeyValuePair<string, string>(i[0], i[1]))
                .ToDictionary(i => i.Key, i => i.Value);
        }


        public int FirstPart()
        {
            return Run(iterationsPart1);
        }

        private void Decorate(ref char[,] m, Dictionary<string, string> input)
        {
            int n = m.GetLength(0);
            if (n % 2 == 0)
            {
                int p = (n / 2) * 3;
                char[,] bigger = new char[p, p];

                // 2x2 chunks
                for (int i = 0; i < n; i += 2)
                {
                    for (int j = 0; j < n; j += 2)
                    {
                        char[,] r = Create3x3Square(new char[2, 2] {
                            {m[i,j],m[i,j+1]},
                            {m[i+1,j],m[i+1,j+1]}
                        }, input);

                        for (int I = 0; I < 3; ++I)
                        {
                            for (int J = 0; J < 3; ++J)
                            {
                                bigger[(i / 2) * 3 + I, (j / 2) * 3 + J] = r[I, J];
                            }
                        }
                    }
                }
                m = bigger;
            }
            else if (n % 3 == 0)
            {
                int p = (n / 3) * 4;
                char[,] bigger = new char[p, p];

                // 3x3 chunks
                for (int i = 0; i < n; i += 3)
                {
                    for (int j = 0; j < n; j += 3)
                    {
                        char[,] r = Create4x4Square(new char[3, 3] {
                            {m[i,j],m[i,j+1],m[i,j+2]},
                            {m[i+1,j],m[i+1,j+1],m[i+1,j+2]},
                            {m[i+2,j],m[i+2,j+1],m[i+2,j+2]},
                        }, input);

                        for (int I = 0; I < 4; ++I)
                        {
                            for (int J = 0; J < 4; ++J)
                            {
                                bigger[(i / 3) * 4 + I, (j / 3) * 4 + J] = r[I, J];
                            }
                        }
                    }
                }
                m = bigger;
            }
        }

        private char[,] Create3x3Square(char[,] v, Dictionary<string, string> input)
        {
            char X = '/';
            var str = new string(new char[] {
                v[0,0], v[0,1], X, v[1, 0], v[1, 1]
            });
            var r = input[str];
            return new char[3, 3]
            {
                { r[0], r[1],r[2]},
                { r[4], r[5],r[6]},
                { r[8], r[9],r[10]},
            };
        }

        private char[,] Create4x4Square(char[,] v, Dictionary<string, string> input)
        {
            char X = '/';
            var str = new string(new char[] {
                v[0,0], v[0,1], v[0,2], X,
                v[1, 0], v[1,1], v[1,2], X,
                v[2,0], v[2,1], v[2,2]
            });
            var r = input[str];
            return new char[4, 4]
            {
                { r[0], r[1], r[2], r[3] },
                { r[5], r[6], r[7], r[8] },
                { r[10], r[11], r[12], r[13] },
                { r[15], r[16], r[17], r[18] },
            };
        }

        private void AddDuplicates(Dictionary<string, string> inputs)
        {
            var duplicatedDictionary = new Dictionary<string, string>();

            foreach (var (k, v) in inputs)
            {
                char X = '/';
                if (k.Length == 5)
                {
                    char a = k[0], b = k[1], c = k[3], d = k[4];
                    // Normal
                    duplicatedDictionary[new string(new char[] { c, a, X, d, b })] = v;
                    duplicatedDictionary[new string(new char[] { d, c, X, b, a })] = v;
                    duplicatedDictionary[new string(new char[] { b, d, X, a, c })] = v;

                    // Vertical
                    duplicatedDictionary[new string(new char[] { d, b, X, c, a })] = v;
                    duplicatedDictionary[new string(new char[] { c, d, X, a, b })] = v;
                    duplicatedDictionary[new string(new char[] { a, c, X, b, d })] = v;
                    duplicatedDictionary[new string(new char[] { b, a, X, d, c })] = v;

                    // Horizontal == Vertical
                    // Both
                    duplicatedDictionary[new string(new char[] { d, c, X, b, a })] = v;
                    duplicatedDictionary[new string(new char[] { c,a,X,d,b })] = v;
                    duplicatedDictionary[new string(new char[] { a,b,X,c,d })] = v;
                    duplicatedDictionary[new string(new char[] { b,d,X,a,c })] = v;
                }
                else
                {
                    char a = k[0], b = k[1], c = k[2], d = k[4], e = k[5], f = k[6], g = k[8], h = k[9], i = k[10];
                    // Rotations
                    duplicatedDictionary[new string(new char[] { g, d, a, X, h, e, b, X, i, f, c })] = v;
                    duplicatedDictionary[new string(new char[] { i, h, g, X, f, e, d, X, c, b, a })] = v;
                    duplicatedDictionary[new string(new char[] { c, f, i, X, b, e, h, X, a, d, g })] = v;

                    // Vertical
                    duplicatedDictionary[new string(new char[] { c, b, a, X, f, e, d, X, i, h, g })] = v;
                    duplicatedDictionary[new string(new char[] { i, f, c, X, h, e, b, X, g, d, a })] = v;
                    duplicatedDictionary[new string(new char[] { a, d, g, X, b, e, h, X, c, f, i })] = v;
                    duplicatedDictionary[new string(new char[] { g, h, i, X, d, e, f, X, a, b, c })] = v;

                    // Horizontal
                    duplicatedDictionary[new string(new char[] { g, h, i, X, d, e, f, X, a, b, c })] = v;
                    duplicatedDictionary[new string(new char[] { a, d, g, X, b, e, h, X, c, f, i })] = v;
                    duplicatedDictionary[new string(new char[] { i, f, c, X, h, e, b, X, g, d, a })] = v;
                    duplicatedDictionary[new string(new char[] { c, b, a, X, f, e, d, X, i, h, g })] = v;

                    // Both
                    duplicatedDictionary[new string(new char[] { i, h, g, X, f, e, d, X, c, b, a })] = v;
                    duplicatedDictionary[new string(new char[] { c, f, i, X, b, e, h, X, a, d, g })] = v;
                    duplicatedDictionary[new string(new char[] { g, d, a, X, h, e, b, X, i, f, c })] = v;
                    duplicatedDictionary[new string(new char[] { a, b, c, X, d, e, f, X, g, h, i })] = v;

                }
            }

            // Add duplicates to original one
            duplicatedDictionary.ToList().ForEach(x => inputs[x.Key] = x.Value);
        }

        public int SecondPart()
        {
            return Run(18);
        }

        private int Run(int numIter)
        {
            var input = Input();
            AddDuplicates(input);

            char[,] initial = new char[3, 3]
            {
                {'.', '#', '.'},
                {'.', '.', '#'},
                {'#', '#', '#'},
            };

            for (int i = 0; i < numIter; ++i)
            {
                Decorate(ref initial, input);
            }

            return initial.Cast<char>().ToArray().Where(i => i == '#').Count();
        }
    }
}
