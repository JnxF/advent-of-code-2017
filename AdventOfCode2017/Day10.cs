using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2017
{
    public class Day10 : ISolver<string>
    {
        public readonly string input;
        public readonly byte[] list;

        public Day10(string input, int listSize=256)
        {
            this.input = input;
            list = Enumerable.Range(0, listSize).Select(i => (byte) i).ToArray();
        }

        public Day10()
        {
            this.input = "94,84,0,79,2,27,81,1,123,93,218,23,103,255,254,243";
            list = Enumerable.Range(0, 256).Select(i => (byte) i).ToArray();
        }

        private byte[] Input()
        {
            return input.Split(",")
                .Select(i => byte.Parse(i))
                .ToArray();
        }

        public byte[] Input2()
        {
            return input.ToCharArray()
                .Select(i => (byte)i)
                .Concat(new byte[] { 17, 31, 73, 47, 23 })
                .ToArray();
        }

        public static void ReverseSubarray<T>(T[] list, int a, int b)
        {
            int n = list.Length;
            if (a < b)
            {
                List<T> res = list.Skip(a).Take(b - a + 1).Reverse().ToList();
                for (int i = 0; i < res.Count; ++i) list[a + i] = res[i];
            }
            else
            {
                List<T> res = new List<T>();
                int p = a;
                while (true)
                {
                    res.Add(list[p]);
                    if (p == b) break;
                    p = (p + 1) % n;
                }
                res.Reverse();
                p = a;
                for (int i = 0; i < res.Count; ++i)
                {
                    list[p] = res[i];
                    p = (p + 1) % n;
                }
            }
        }
        private void RunRound(byte[] input, ref int pos, ref int skip, int n)
        {
            foreach (var len in input)
            {
                if (len != 0)
                {
                    int a = pos;
                    int b = (pos + len - 1) % n;
                    ReverseSubarray(list, a, b);
                }

                pos = (pos + len + skip) % n;
                ++skip;
            }
        }

        public string FirstPart()
        {
            var input = Input();
            int pos = 0;
            int skip = 0;
            RunRound(input, ref pos, ref skip, list.Length);

            return (list[0] * list[1]).ToString();
        }

        public string SecondPart()
        {
            var input = Input2();
            int pos = 0;
            int skip = 0;

            for (int v = 0; v < 64; ++v)
            {
                RunRound(input, ref pos, ref skip, list.Length);
            }

            List<string> denseHash = new List<string>();
            for (int i = 0; i < 16; ++i)
            {
                byte x = list[16 * i];
                for (int j = 16 * i + 1; j < 16 * (i + 1); ++j)
                {
                    x ^= list[j];
                }
                denseHash.Add((x < 16 ? "0" : "") + Convert.ToString(x, 16));
            }

            return string.Join("", denseHash);
        }
    }
}
