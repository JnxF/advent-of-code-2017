using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode2017
{
    public class Day10 : ISolver<int>
    {
        public readonly string input;
        public readonly int[] list;

        public Day10(string input, int listSize)
        {
            this.input = input;
            list = Enumerable.Range(0, listSize).ToArray();
        }

        public Day10()
        {
            input = "94,84,0,79,2,27,81,1,123,93,218,23,103,255,254,243";
            list = Enumerable.Range(0, 256).ToArray();
        }

        int[] Input()
        {
            return input.Split(",")
                .Select(i => int.Parse(i))
                .ToArray();
        }


        public static void Swap<T>(ref T a, ref T b)
        {
            T temp = a;
            a = b;
            b = temp;
        }

        public static void ReverseSubarray<T>(T[] arr, int i, int j)
        {
            int n = arr.Length;
            // Normal reverse
            if (i < j)
            {
                for (int t = 0; t <= (j-i)/2; ++t)
                {
                    Swap(ref arr[i + t], ref arr[j - t]);
                }
            }
            else
            {
                while (i != j)
                {
                    Swap(ref arr[i], ref arr[j]);
                    i = (i + 1) % n;
                    --j;
                    if (i == 0 && j == -1) break;
                    if (j < 0)
                    {
                        j = n - 1;
                    }
                }
            }
            
        }
        
        public int FirstPart()
        {
            int currentPosition = 0;
            int skipSize = 0;
            int n = list.Length;
            foreach (var length in Input())
            {
                int endReverse;
                if (length == 0)
                    endReverse = currentPosition;
                else
                    endReverse = (currentPosition + length - 1) % n;
                ReverseSubarray(list, currentPosition, endReverse);
                currentPosition += length + skipSize;
                currentPosition %= n;
                ++skipSize;
            }
            return list[0] * list[1];
        }

        public int SecondPart()
        {
            throw new NotImplementedException();
        }
    }
}
