using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode2017
{
    public class Day7 : ISolver<string>
    {
        public readonly string input;

        public Day7(string input)
        {
            this.input = input;
        }

        public Day7()
        {
            input = Properties.Resources.Day7;
        }


        private Dictionary<string, HashSet<string>> Input()
        {
            var lines = input.Replace("\r", "")
                .Replace(",", "")
                .Split("\n")
                .Select(i => i.Split(" "));

            var res = new Dictionary<string, HashSet<string>>();
            foreach (var line in lines)
            {
                var k = line[0];
                var descendants = line.Skip(3);
                res[k] = new HashSet<string>(descendants);
            }
            return res;
        }

        private Dictionary<string, int> Weights()
        {
            return input.Replace("\r", "")
                .Replace("(", "")
                .Replace(")", "")
                .Split("\n")
                .Select(i => i.Split(" "))
                .Select(i => new KeyValuePair<string, int>(i[0], int.Parse(i[1])))
                .ToDictionary(i => i.Key, i => i.Value);
        }

        private static string BottomProgram(Dictionary<string, HashSet<string>> input)
        {
            var isDescendentProgram = new Dictionary<string, bool>();
            foreach (var (k, v) in input)
            {
                isDescendentProgram[k] = false;
            }

            foreach (var (_, v) in input)
            {
                foreach (var descendent in v)
                {
                    isDescendentProgram[descendent] = true;
                }
            }

            return isDescendentProgram.Where(i => i.Value == false).First().Key;
        }

        public string FirstPart()
        {
            return BottomProgram(Input());
        }

        private class Tree
        {
            public string Node { get; set; }
            public int Weight { get; set; }
            public Tree[] Des { get; set; }

            public int Missing { get; set; }
            public int GlobalWeight { get; set; }
        }


        public string SecondPart()
        {
            var input = Input();
            var bottom = BottomProgram(input);
            var weights = Weights();
            var tree = BuildTree(bottom, input, weights);
            Decorate(tree);
            return tree.Missing.ToString();
        }

        private static void Decorate(Tree tree)
        {
            if (tree.Des == null)
            {
                tree.GlobalWeight = tree.Weight;
                tree.Missing = 0;
            } else
            {
                foreach (var d in tree.Des)
                {
                    Decorate(d);
                }

                tree.GlobalWeight = tree.Weight + tree.Des.Select(i => i.GlobalWeight).Sum();

                // If the missing are already detected, pass it up
                if (tree.Des.Any(i => i.Missing != 0))
                {
                    tree.Missing = tree.Des.Select(i => i.Missing).Max();
                }
                // Else calculate it
                else
                {
                    var s = new Dictionary<int, int>();
                    foreach (var t in tree.Des.Select(i => i.GlobalWeight))
                    {
                        if (!s.ContainsKey(t)) s[t] = 0;
                        ++s[t];
                    }

                    if (s.Count > 1)
                    {
                        var weird = s.Where(i => i.Value == 1).First().Key;
                        var normal = s.Where(i => i.Value != 1).First().Key;
                        int pos = 0;
                        while (tree.Des[pos].GlobalWeight != weird) ++pos;

                        tree.Missing = tree.Des[pos].Weight - Math.Abs(weird - normal);
                    }
                    else
                    {
                        tree.Missing = 0;
                    }
                }
                
            }
        }

        private static Tree BuildTree(string n, Dictionary<string, HashSet<string>> input, Dictionary<string, int> weights)
        {
            return new Tree
            {
                Node = n,
                Weight = weights[n],
                Des = (input[n].Count != 0 ? input[n].Select(i => BuildTree(i, input, weights)).ToArray() : null)
            };
        }
    }
}
