using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AdventOfCode2017
{
    public class Day18 : ISolver<int>
    {
        public readonly string input;

        public Day18(string input)
        {
            this.input = input;
        }

        public Day18()
        {
            input = Properties.Resources.Day18;
        }


        private (string, string, string)[] Input()
        {
            return input.Replace("\r", "")
                .Trim()
                .Split("\n")
                .Select(i => i.Split(" "))
                .Select(i => (i[0], i[1], (i.Length == 3 ? i[2] : null)))
                .ToArray();
        }

        public int FirstPart()
        {
            var input = Input();
            var dict = new Dictionary<string, long>();
            int pc = 0;
            long lastFrequency = 0;
            while (pc < input.Length)
            {
                var (instr, X, Y) = input[pc];
                switch (instr)
                {
                    case "snd":
                        lastFrequency = GetValue(X, dict);
                        break;
                    case "rcv":
                        var mustJump0 = GetValue(X, dict) != 0;
                        if (mustJump0)
                            return (int)lastFrequency;
                        break;
                    case "set":
                        if (!dict.ContainsKey(X)) dict[X] = 0;
                        dict[X] = GetValue(Y, dict);
                        break;
                    case "add":
                        if (!dict.ContainsKey(X)) dict[X] = 0;
                        dict[X] += GetValue(Y, dict);
                        break;
                    case "mod":
                        if (!dict.ContainsKey(X)) dict[X] = 0;
                        dict[X] %= GetValue(Y, dict);
                        break;
                    case "mul":
                        if (!dict.ContainsKey(X)) dict[X] = 0;
                        dict[X] *= GetValue(Y, dict);
                        break;
                    case "jgz":
                        var mustJump = GetValue(X, dict) > 0;
                        if (mustJump)
                            pc += (int)GetValue(Y, dict) - 1;
                        break;
                }
                ++pc;
            }
            return -1;
        }

        private static long GetValue(string y, Dictionary<string, long> dict)
        {
            bool isNumber = int.TryParse(y, out int number);
            if (isNumber)
            {
                return number;
            }
            else
            {
                if (!dict.ContainsKey(y)) dict[y] = 0;
                return dict[y];
            }
        }

        private static bool ExecuteStep((string, string, string) myInstruction, ref int pc, Dictionary<string, long> dict, ConcurrentQueue<long> ownQueue, ConcurrentQueue<long> otherQueue, out bool send)
        {
            send = false;
            var (instr, X, Y) = myInstruction;
            switch (instr)
            {
                case "snd":
                    send = true;
                    otherQueue.Enqueue(GetValue(X, dict));
                    break;
                case "rcv":
                    if (ownQueue.Count == 0)
                    {
                        return false;
                    }
                    else
                    {
                        if (!dict.ContainsKey(X)) dict[X] = 0;
                        long result;
                        bool k;
                        do { k = ownQueue.TryDequeue(out result); } while (!k);
                        dict[X] = result;
                    }
                    break;
                case "set":
                    if (!dict.ContainsKey(X)) dict[X] = 0;
                    dict[X] = GetValue(Y, dict);
                    break;
                case "add":
                    if (!dict.ContainsKey(X)) dict[X] = 0;
                    dict[X] += GetValue(Y, dict);
                    break;
                case "mod":
                    if (!dict.ContainsKey(X)) dict[X] = 0;
                    dict[X] %= GetValue(Y, dict);
                    break;
                case "mul":
                    if (!dict.ContainsKey(X)) dict[X] = 0;
                    dict[X] *= GetValue(Y, dict);
                    break;
                case "jgz":
                    var mustJump = GetValue(X, dict) > 0;
                    if (mustJump)
                        pc += (int)GetValue(Y, dict) - 1;
                    break;
            }
            ++pc;
            return true;
        }

        public int SecondPart()
        {
            var input = Input();
            ConcurrentQueue<long> queue0 = new ConcurrentQueue<long>();
            ConcurrentQueue<long> queue1 = new ConcurrentQueue<long>();
            int totalSendTask1 = 0;

            Task t0 = Task.Factory.StartNew(() => Run(0, input, ref queue0, ref queue1, ref totalSendTask1));
            Task t1 = Task.Factory.StartNew(() => Run(1, input, ref queue1, ref queue0, ref totalSendTask1));

            int totalSendPrevious;
            do
            {
                totalSendPrevious = totalSendTask1;
                Task.WaitAll(new Task[] { t0, t1 }, 500);
            } while (totalSendPrevious != totalSendTask1);

            return totalSendTask1;
        }

        private static void Run(long id, (string, string, string)[] input, ref ConcurrentQueue<long> ownQueue, ref ConcurrentQueue<long> otherQueue, ref int totalSendTask1)
        {
            var dict = new Dictionary<string, long> { ["p"] = id };
            int pc = 0;
            while (pc < input.Length)
            {
                var instr = input[pc];
                ExecuteStep(instr, ref pc, dict, ownQueue, otherQueue, out bool send);
                if (send && id == 1)
                {
                    ++totalSendTask1;
                }
            }
        }
    }
}
