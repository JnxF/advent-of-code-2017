using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode2017
{
    public class Day15 : ISolver<int>
    {
        public readonly int _initialA;
        public readonly int _initialB;

        private const ulong A_FACTOR = 16807;
        private const ulong B_FACTOR = 48271;

        public Day15(int initialA, int initialB)
        {
            _initialA = initialA;
            _initialB = initialB;
        }

        public Day15()
        {
            _initialA = 783;
            _initialB = 325;
        }

        public int FirstPart()
        {
            int total = 0;
            ulong A = (ulong) _initialA;
            ulong B = (ulong) _initialB;
            for (int iteration = 0; iteration < 40000000; ++iteration)
            {
                A *= A_FACTOR;
                B *= B_FACTOR;
                A %= 2147483647UL;
                B %= 2147483647UL;

                if (A % 65536UL == B % 65536UL)
                {
                    ++total;
                }
            }
            return total;
        }

        public int SecondPart()
        {
            int total = 0;
            ulong A = (ulong)_initialA;
            ulong B = (ulong)_initialB;
            for (int iteration = 0; iteration < 5000000; ++iteration)
            {
                do
                {
                    A *= A_FACTOR;
                    A %= 2147483647UL;
                } while (A % 4 != 0);


                do
                {
                    B *= B_FACTOR;
                    B %= 2147483647UL;
                } while (B % 8 != 0);


                if (A % 65536UL == B % 65536UL)
                {
                    ++total;
                }
            }
            return total;
        }
    }
}
