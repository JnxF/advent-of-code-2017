using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Linq;

namespace AdventOfCode2017
{
    public class Day24 : ISolver<int>
    {
        public readonly string input;

        public Day24(string input)
        {
            this.input = input;
        }

        public Day24()
        {
            input = Properties.Resources.Day24;
        }

        (int, int)[] Input()
        {
            return Regex.Split(input.Trim(), @"\r?\n|\r")
                .Select(i => i.Split("/").Select(n => int.Parse(n)).ToArray())
                .Select(i => (i[0], i[1]))
                .ToArray();
        }

        int Value((int, int) x) => x.Item1 + x.Item2;

        public int FirstPart()
        {
            var input = new HashSet<(int, int)>(Input());

            var startingNodes = input.Where(i => i.Item1 == 0 || i.Item2 == 0);
            int maxValue = 0;
            foreach (var startingNode in startingNodes)
            {
                var itsInput = new HashSet<(int, int)>(input);
                itsInput.Remove(startingNode);

                int next = startingNode.Item1 == 0 ? startingNode.Item2 : startingNode.Item1; 
                int value = Backtrack1(startingNode, itsInput, next);
                maxValue = Math.Max(maxValue, value);
            }
            return maxValue;
        }

        private int Backtrack1((int, int) startingNode, HashSet<(int, int)> itsInput, int next)
        {
            int max = 0;
            foreach (var input in itsInput)
            {
                if (input.Item1 != next && input.Item2 != next) continue;
                var myNewInput = new HashSet<(int, int)>(itsInput);
                myNewInput.Remove(input);

                int myNext = next == input.Item1 ? input.Item2 : input.Item1; 

                max = Math.Max(max, Backtrack1(input, myNewInput, myNext));
            }

            return Value(startingNode) + max;
        }


        public int SecondPart()
        {
            var input = new HashSet<(int, int)>(Input());

            var startingNodes = input.Where(i => i.Item1 == 0 || i.Item2 == 0);

            HashSet<(int, int)> values = new HashSet<(int, int)>();
            foreach (var startingNode in startingNodes)
            {
                var itsInput = new HashSet<(int, int)>(input);
                itsInput.Remove(startingNode);

                int next = startingNode.Item1 == 0 ? startingNode.Item2 : startingNode.Item1;
                values.Add(Backtrack2(startingNode, itsInput, 0, next));
            }

            return values.OrderByDescending(v => v.Item1) // highest length to lowest
                .ThenByDescending(v => v.Item2)
                .First()
                .Item2;
        }

        // (length, weight)
        private (int, int) Backtrack2((int, int) startingNode, HashSet<(int, int)> itsInput, int prof, int next)
        {
            HashSet<(int, int)> values = new HashSet<(int, int)>();

            foreach (var input in itsInput)
            {
                if (input.Item1 != next && input.Item2 != next) continue;
                var myNewInput = new HashSet<(int, int)>(itsInput);
                myNewInput.Remove(input);

                int myNext = next == input.Item1 ? input.Item2 : input.Item1;

                values.Add(Backtrack2(input, myNewInput, prof + 1, myNext));
            }

            var bestOne = values.OrderByDescending(v => v.Item1) // highest length to lowest
                 .ThenByDescending(v => v.Item2)
                 .FirstOrDefault();
            return (1 + bestOne.Item1, bestOne.Item2 + Value(startingNode));
        }

        
    }
}
