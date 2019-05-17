using System;

namespace AdventOfCode2017
{
    public class Day1 : ISolver
    {
        /* public static void Main(string[] args)
        {
            var _ = new Day1();
            Console.WriteLine(_.FirstPart());
            Console.WriteLine(_.SecondPart());
        } */

        public string FirstPart()
        {
            var numero = Properties.Resources.Day1;
            int total = 0;
            for (int i = 0; i < numero.Length; ++i)
            {
                var next = numero[(i + 1) % numero.Length];
                if (numero[i] == next)
                {
                    total += int.Parse(numero[i] + " ");
                }
            }
            return total.ToString();
        }

        public string SecondPart()
        {
            var numero = Properties.Resources.Day1;
            int total = 0;
            for (int i = 0; i < numero.Length; ++i)
            {
                var next = numero[(i + (numero.Length / 2)) % numero.Length];
                if (numero[i] == next)
                {
                    total += int.Parse(numero[i] + " ");
                }
            }
            return total.ToString();
        }
    }
}
