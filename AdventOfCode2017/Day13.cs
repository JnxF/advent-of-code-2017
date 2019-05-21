using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2017
{
    public class Day13 : ISolver<int>
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
            var lines = input.Replace("\r", "").Trim().Split("\n");
            foreach (var line in lines)
            {
                var splitted = line.Split(": ").Select(i => int.Parse(i)).ToArray();
                res[splitted[0]] = splitted[1];
            }
            return res;
        }


        public int FirstPart()
        {
            var input = Input();
            var total = 0;

            foreach ((var depth, var range) in input)
            {
                int frequency = 2 * (range - 1);
                if (depth % frequency == 0)
                {
                    total += depth * range;
                }
            }
            
            return total;
        }
        
        public int SecondPart()
        {
            var input = Input();
            for (int iteration = 0; ; ++iteration)
            {
                bool ok = true;
                foreach (var (depth, range) in input)
                {
                    int frequency = 2 * (range - 1);
                    if ((depth + iteration) % frequency == 0)
                    {
                        ok = false;
                        break;
                    }
                }
                if (ok)
                {
                    return iteration;
                }
            }
        }
    }
}
