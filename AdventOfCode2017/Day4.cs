using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode2017
{
    public class Day4 : ISolver<int>
    {
        public readonly string input;

        public Day4(string input)
        {
            this.input = input;
        }

        public Day4()
        {
            input = Properties.Resources.Day4;
        }

        private IEnumerable<IEnumerable<string>> Input()
        {
            return Regex.Split(input.Trim(), @"\r?\n|\r")
            .Where(_ => _.Trim() != "")
            .Select(line => Regex.Split(line.Trim(), @"\s+|\t+"));
        }

        private bool ValidLineFirstPart(IEnumerable<string> line)
        {
            HashSet<string> mySet = new HashSet<string>();
            foreach (var word in line)
            {
                if (mySet.Contains(word))
                {
                    return false;
                }
                mySet.Add(word);
            }
            return true;
        }

        public int FirstPart()
        {
            return Input()
                .Where(l => ValidLineFirstPart(l))
                .Count();
        }

        private bool ValidLineSecondPart(IEnumerable<string> line)
        {
            HashSet<string> mySet = new HashSet<string>();
            foreach (var word in line)
            {
                char[] charArray = word.ToCharArray();
                Array.Sort(charArray);
                var myWord = new string(charArray);

                if (mySet.Contains(myWord))
                {
                    return false;
                }
                mySet.Add(myWord);
            }
            return true;
        }

        public int SecondPart()
        {
            return Input()
                .Where(l => ValidLineSecondPart(l))
                .Count();
        }
    }
}
