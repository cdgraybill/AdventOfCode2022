using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdventOfCode2022.Solvers
{
    public class Day06Solver
    {
        public readonly List<string> Datastream = File.ReadAllLines(@"C:ProblemInputs\Day06Input.txt").ToList();

        public int CountCharacters_PartOne(List<string> input)
        {
            var datastream = input[0];
            var characterCount = 0;

            for (int i = 1; i < datastream.Length; i++)
            {
                var buffer = datastream.Substring(i - 1, 4);
                var hasUniqueCharacters = buffer.Distinct().Count() == buffer.Length;

                if (hasUniqueCharacters)
                {
                    characterCount = i + 3;
                    break;
                }
            }

            return characterCount;
        }

        public int CountCharacters_PartTwo(List<string> input)
        {
            var datastream = input[0];
            var characterCount = 0;

            for (int i = 1; i < datastream.Length; i++)
            {
                var buffer = datastream.Substring(i - 1, 14);
                var hasUniqueCharacters = buffer.Distinct().Count() == buffer.Length;

                if (hasUniqueCharacters)
                {
                    characterCount = i + 13;
                    break;
                }
            }

            return characterCount;
        }
    }
}
