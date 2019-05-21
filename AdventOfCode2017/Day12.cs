using AdventOfCode2017.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2017
{
    public class Day12 : ISolver<int>
    {
        public readonly string input;

        public Day12(string input)
        {
            this.input = input;
        }

        public Day12()
        {
            input = Properties.Resources.Day12;
        }

        bool[,] ReadMatrix()
        {
            var lines = input
                .Replace("\r", "")
                .Trim()
                .Split("\n")
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

        public int FirstPart()
        {
            var m = ReadMatrix();
            return DFS(m);
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

        public int SecondPart()
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
            return uf.Count;
        }
    }
}
