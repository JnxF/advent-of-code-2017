using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace AdventOfCode2017
{
    public class Day8 : ISolver<int>
    {
        public readonly string input;

        public Day8(string input)
        {
            this.input = input;
        }

        public Day8()
        {
            input = Properties.Resources.Day8;
        }

        private class Instruction
        {
            public readonly string register;
            public readonly bool increment;
            public readonly int quantity;
            public readonly string registerComparison;
            public readonly string operatorComparison;
            public readonly int quantityComparison;

            public Instruction(string register, bool increment, int quantity, string registerComparison, string operatorComparison, int quantityComparison)
            {
                this.register = register;
                this.increment = increment;
                this.quantity = quantity;
                this.registerComparison = registerComparison;
                this.operatorComparison = operatorComparison;
                this.quantityComparison = quantityComparison;
            }
        }

        Instruction[] Input()
        {
            return input.Replace("\r", "")
                .Trim()
                .Split("\n")
                .Where(_ => _.Trim() != "")
                .Select(line =>
                {
                    var splitted = line.Split(" ");
                    return new Instruction(splitted[0], splitted[1] == "inc", int.Parse(splitted[2]), splitted[4], splitted[5], int.Parse(splitted[6]));
                })
                .ToArray();
        }

        void RunCode(Instruction[] instructions, IDictionary<string, int> registerBank, out int maxValue)
        {
            maxValue = 0;
            foreach (Instruction instruction in instructions)
            {
                if (!registerBank.Keys.Contains(instruction.register))
                {
                    registerBank[instruction.register] = 0;
                }
                if (!registerBank.Keys.Contains(instruction.registerComparison))
                {
                    registerBank[instruction.registerComparison] = 0;
                }

                bool ok = (instruction.operatorComparison == "==" && registerBank[instruction.registerComparison] == instruction.quantityComparison) ||
                    (instruction.operatorComparison == "!=" && registerBank[instruction.registerComparison] != instruction.quantityComparison) ||
                    (instruction.operatorComparison == "<" && registerBank[instruction.registerComparison] < instruction.quantityComparison) ||
                    (instruction.operatorComparison == ">" && registerBank[instruction.registerComparison] > instruction.quantityComparison) ||
                    (instruction.operatorComparison == ">=" && registerBank[instruction.registerComparison] >= instruction.quantityComparison) ||
                    (instruction.operatorComparison == "<=" && registerBank[instruction.registerComparison] <= instruction.quantityComparison);

                if (!ok) continue;

                if (instruction.increment)
                {
                    registerBank[instruction.register] += instruction.quantity;
                }
                else
                {
                    registerBank[instruction.register] -= instruction.quantity;
                }
                maxValue = Math.Max(maxValue, registerBank[instruction.register]);
            }
        }

        public int FirstPart()
        {
            var instructions = Input();
            Dictionary<string, int> registerBank = new Dictionary<string, int>();
            RunCode(instructions, registerBank, out _);
            return registerBank.Values.Max();
        }

        public int SecondPart()
        {
            var instructions = Input();
            Dictionary<string, int> registerBank = new Dictionary<string, int>();
            RunCode(instructions, registerBank, out int maxValue);
            return maxValue;
        }
    }
}
