namespace AdventOfCode2017
{
    public class Day01 : ISolver<int>
    {
        public readonly string input;

        public Day01(string input)
        {
            this.input = input;
        }

        public Day01()
        {
            input = Properties.Resources.Day1;
        }

        public int FirstPart()
        {
            int total = 0;
            for (int i = 0; i < input.Length; ++i)
            {
                var next = input[(i + 1) % input.Length];
                if (input[i] == next)
                {
                    total += int.Parse(input[i] + " ");
                }
            }
            return total;
        }

        public int SecondPart()
        {
            int total = 0;
            for (int i = 0; i < input.Length; ++i)
            {
                var next = input[(i + (input.Length / 2)) % input.Length];
                if (input[i] == next)
                {
                    total += int.Parse(input[i] + " ");
                }
            }
            return total;
        }
    }
}
