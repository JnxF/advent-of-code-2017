using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode2017
{
    public class Day4 : ISolver
    {

        /*public static void Main()
        {
            var _ = new Day4();
            Console.WriteLine(_.FirstPart());
            Console.WriteLine(_.SecondPart());
        }*/

        IEnumerable<IEnumerable<string>> Input()
        {
            return Regex.Split(Properties.Resources.Day4.Trim(), @"\r?\n|\r")
            .Where(_ => _.Trim() != "")
            .Select(line => Regex.Split(line.Trim(), @"\s+|\t+"));
        }

        public string FirstPart()
        {
            return Input().Where(l => ValidLineFirstPart(l)).Count().ToString();
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

        public string SecondPart()
        {
            return Input().Where(l => ValidLineSecondPart(l)).Count().ToString();
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
    }
}
