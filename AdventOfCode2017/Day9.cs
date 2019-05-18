using System;

namespace AdventOfCode2017
{
    public class Day9 : ISolver<int>
    {
        public readonly string input;

        public Day9(string input)
        {
            this.input = input;
        }

        public Day9()
        {
            input = Properties.Resources.Day9;
        }

        public int FirstPart()
        {
            int height = 0;
            int total = 0;
            bool inRubish = false;
            bool exclamationDetected = false;
            foreach (var c in input)
            {
                if (exclamationDetected)
                {
                    exclamationDetected = false;
                    continue;
                }

                if (inRubish)
                {
                    if (c == '!')
                        exclamationDetected = true;
                    else if (c == '>')
                        inRubish = false;
                }
                else
                {
                    if (c == '{') ++height;
                    else if (c == '}')
                    {
                        total += height;
                        --height;
                    }
                    else if (c == '<') inRubish = true;
                }
            }
            return total;
        }

        public int SecondPart()
        {
            bool inRubish = false;
            bool exclamationDetected = false;
            int totalRubish = 0;
            foreach (var c in input)
            {
                if (exclamationDetected)
                {
                    exclamationDetected = false;
                    continue;
                }

                if (inRubish)
                {
                    if (c == '!')
                        exclamationDetected = true;
                    else if (c == '>')
                        inRubish = false;
                    else
                        ++totalRubish;
                }
                else if (c == '<')
                    inRubish = true;
            }

            return totalRubish;
        }
    }
}
