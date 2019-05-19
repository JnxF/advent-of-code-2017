using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace AdventOfCode2017
{
    public class Day25 : ISolver<int>
    {
        public readonly string input;
        public readonly int checksumStep;

        public Day25(string input, int checksumStep)
        {
            this.input = input;
            this.checksumStep = checksumStep;
        }

        public Day25()
        {
            input = Properties.Resources.Day25;
            checksumStep = 12459852;
        }

        public static void Main()
        {
            var k = new Day25();
            Console.WriteLine(k.FirstPart());
            Console.WriteLine(k.SecondPart());
        }

        Dictionary<string, (bool, bool, string, bool, bool, string)> Input()
        {
            var states = input.Replace("\r", "")
                .Split("\n\n")
                .Skip(1)
                .Select(s =>
                {
                    var m = Regex.Matches(s, @"\w+\.")
                    .Select(i => i.Value)
                    .Select(i => i.TrimEnd('.'))
                    .ToArray();
                    return (m[0] == "1", m[1] == "right", m[2], m[3] == "1", m[4] == "right", m[5]);
                })
                .ToArray();

            var dict = new Dictionary<string, (bool, bool, string, bool, bool, string)>();
            char c = 'A';
            foreach (var s in states)
            {
                dict[new string ( new[] { c })] = s;
                ++c;
            }
            return dict;
        }

        public int FirstPart()
        {
            var input = Input();
            var tape = new bool[500000];
            int pos = tape.Length / 2;
            string state = "A";
            for (int i = 0; i < checksumStep; ++i)
            {
                var (a, b, c, d, e, f) = input[state];
                if (tape[pos] == false)
                {
                    tape[pos] = a;
                    if (b) ++pos; else --pos;
                    state = c;
                } else
                {
                    tape[pos] = d;
                    if (e) ++pos; else --pos;
                    state = f;
                }
            }
            return tape.Where(c => c).Count();
        }

        public int SecondPart()
        {
            throw new NotImplementedException();
        }
    }
}
