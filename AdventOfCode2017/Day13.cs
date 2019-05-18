﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace AdventOfCode2017
{
    public class Day13 : ISolver
    {
        public readonly string input;

        public Day13(string input)
        {
            this.input = input;
        }

        public Day13()
        {
            input = Properties.Resources.Day13;
        }

        IDictionary<int, int> Input()
        {
            var res = new Dictionary<int, int>();
            var lines = Regex.Split(input.Trim(), @"\r?\n|\r");
            foreach (var line in lines)
            {
                var splitted = line.Split(": ").Select(i => int.Parse(i)).ToArray();
                res[splitted[0]] = splitted[1];
            }
            return res;
        }

        public static void Main()
        {
            var k = new Day13();
            Console.WriteLine(k.FirstPart());
            Console.WriteLine(k.SecondPart());
        }

        public int FirstPart()
        {
            var input = Input();
            var total = 0;

            foreach ((var depth, var range) in input)
            {
                int frequency = 2 * (range - 1);
                if (frequency == 0 || depth % frequency == 0)
                {
                    total += depth * range;
                }
            }
            
            return total;
        }
        
        private bool CanPass(IDictionary<int, int> myInput)
        {
            foreach (var (depth, range) in myInput)
            {
                int frequency = 2 * (range - 1);
                if (frequency == 0 || depth % frequency == 0)
                {
                    return false;
                }
            }
            return true;
        }

        public int SecondPart()
        {
            var input = Input();
            for (int iteration = 0; ; ++iteration)
            {
                var dictionary = new Dictionary<int, int>();
                foreach (var (key, value) in input)
                {
                    dictionary[key + iteration] = value;
                }
                if (CanPass(dictionary))
                {
                    return iteration;
                }
            }
        }
    }
}
