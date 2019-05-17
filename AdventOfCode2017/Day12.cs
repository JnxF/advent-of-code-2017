﻿using AdventOfCode2017.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode2017
{
    public class Day12 : ISolver
    {
        public static void Main()
        {
            var k = new Day12();
            Console.WriteLine(k.FirstPart());
            Console.WriteLine(k.SecondPart());
        }

        bool[,] ReadMatrix()
        {
            var rawInput = Properties.Resources.Day12bis;

            var lines = Regex.Split(rawInput.Trim(), @"\r?\n|\r")
                .Select(i => i.Split("<->")[1])
                .Select(line => line.Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(i => int.Parse(i)).ToArray())
                .ToArray();

            int n = lines.Count();

            bool[,] m = new bool[n, n];
            for (int i = 0; i < n; ++i)
            {
                foreach (var connected in lines[i])
                {
                    m[i, connected] = true;
                    m[connected, i] = true;
                }
            }
            return m;
        }

        public string FirstPart()
        {
            var m = ReadMatrix();
            return DFS(m).ToString();
        }

        private int DFS(bool[,] m)
        {
            var q = new Queue<int>();
            q.Enqueue(0);
            int n = m.GetLength(0);
            var visited = new bool[n];
            for (int i = 0; i < n; ++i) visited[i] = false;
            visited[0] = true;
            var accessed = new HashSet<int>();
            while (q.Count != 0)
            {
                int top = q.Dequeue();
                accessed.Add(top);
                for (int i = 0; i < n; ++i)
                {
                    if (m[top, i] && !visited[i])
                    {
                        visited[i] = true;
                        q.Enqueue(i);
                    }
                }
            }
            return accessed.Count;
        }

        public string SecondPart()
        {
            var m = ReadMatrix();
            int n = m.GetLength(0);
            var uf = new UnionFind(n);
            for (int i = 0; i < n; ++i)
            {
                for (int j = 0; j < n; ++j)
                {
                    if (m[i, j])
                    {
                        uf.Union(i, j);
                    }
                }
            }
            return uf.Count.ToString();
        }
    }
}