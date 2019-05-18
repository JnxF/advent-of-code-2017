using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode2017
{
    public class Day16 : ISolver<string>
    {
        public readonly string input;

        public Day16(string input)
        {
            this.input = input;
        }

        public Day16()
        {
            input = Properties.Resources.Day16;
        }

        private IDanceMove ParseProgram(string program)
        {
            IDanceMove res;
            var remainding = program.Substring(1);
            switch (program[0])
            {
                case 's':
                    res = new Spin(int.Parse(remainding));
                    break;
                case 'x':
                    var numbers = remainding.Split("/").Select(i => int.Parse(i)).ToArray();
                    res = new Exchange(numbers[0], numbers[1]);
                    break;
                default: // 'p'
                    var programs = remainding.Split("/").ToArray();
                    res = new Partner(programs[0], programs[1]);
                    break;
            }
            return res;
        }

        private IEnumerable<IDanceMove> Input()
        {
            return input.Split(",")
                .Select(pr => ParseProgram(pr))
                .ToArray();
        }

        private enum ProgramType
        {
            SPIN, EXCHANGE, PARTNER
        };

        private interface IDanceMove
        {
            string Dance(string programs);
        }

        private class Spin : IDanceMove
        {
            private readonly int _size;

            public Spin(int size)
            {
                _size = size;
            }

            public string Dance(string programs)
            {
                int n = programs.Length;
                return new string(programs.TakeLast(_size).ToArray()) + new string(programs.Take(n - _size).ToArray());
            }
        }

        private class Exchange : IDanceMove
        {
            private readonly int _positionA;
            private readonly int _positionB;

            public Exchange(int positionA, int positionB)
            {
                _positionA = positionA;
                _positionB = positionB;
            }

            public string Dance(string programs)
            {
                var sb = new StringBuilder(programs);
                var orig = sb[_positionA];
                sb[_positionA] = sb[_positionB];
                sb[_positionB] = orig;
                return sb.ToString();
            }
        }

        private class Partner : IDanceMove
        {
            private readonly string _programA;
            private readonly string _programB;

            public Partner(string programA, string programB)
            {
                _programA = programA;
                _programB = programB;
            }

            public string Dance(string programs)
            {
                int positionA = programs.IndexOf(_programA[0]);
                int positionB = programs.IndexOf(_programB[0]);

                var sb = new StringBuilder(programs);
                var orig = sb[positionA];
                sb[positionA] = sb[positionB];
                sb[positionB] = orig;
                return sb.ToString();
            }
        }

        public string FirstPart()
        {
            string programs = "abcdefghijklmnop";
            var input = Input();
            foreach (var danceMove in input)
            {
                programs = danceMove.Dance(programs);
            }
            return programs;
        }

        public string SecondPart()
        {
            string programs = "abcdefghijklmnop";
            var input = Input();
            // This number is found by inspection.
            // Programs orders are repeated in cycle
            // One should compute 1000000000 modulo the cycle
            // And get that program order
            for (int i = 0; i <= 99; ++i)
            {
                foreach (var danceMove in input)
                {
                    programs = danceMove.Dance(programs);
                }
            }
            return programs;
        }
    }
}
