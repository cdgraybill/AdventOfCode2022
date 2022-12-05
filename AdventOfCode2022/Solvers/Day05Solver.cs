using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.Solvers
{
    public class Day05Solver
    {
        public readonly List<string> Crates = File.ReadLines(@"C:ProblemInputs\Day05Input_Crates.txt").ToList();
        public readonly List<string> Moves = File.ReadLines(@"C:ProblemInputs\Day05Input_Moves.txt").ToList();

        public readonly List<string> SampleCrates = File.ReadLines(@"C:SampleInputs\Day05SampleInput_Crates.txt").ToList();
        public readonly List<string> SampleMoves = File.ReadLines(@"C:SampleInputs\Day05SampleInput_Moves.txt").ToList();

        public List<string> GetSimplifiedCrateMap(List<string> originalCrateMap)
        {
            var crateMap = new List<string>();

            for (int i = 1; i <= originalCrateMap.Count; i++)
            {
                RemoveSpaces(originalCrateMap[i - 1]);

                var removedOpen = originalCrateMap[i - 1].Replace("[", string.Empty);
                var removedClosed = removedOpen.Replace("]", string.Empty);

                if (i == originalCrateMap.Count)
                {
                    var spacesRemoved = originalCrateMap.Last().Replace(" ", string.Empty).ToCharArray();
                    var xAxis = string.Join(" ", spacesRemoved);
                    
                    crateMap.Add(xAxis);
                    return crateMap;
                }

                crateMap.Add(removedClosed);
            }

            return crateMap;
        }

        private static void RemoveSpaces(string line)
        {
            for (int i = 0; i < line.Length; i++)
            {
                if (line[i] % 3 == 0)
                    line.Remove(i);
            }
        }

        private StackInstructions GetStackInstructions(string line)
        {
            var substring = line[..^7];

            return new StackInstructions()
            {
                NumberOfCrates = GetNumberOfCrates(line),
                StartingStack = int.Parse(substring[0].ToString()),
                EndingStack = int.Parse(substring[1].ToString())
            };
        }

        private int GetNumberOfCrates(string line)
        {
            var sb = new StringBuilder();
            sb.Append(line[5]);

            if (line[6] != ' ')
                sb.Append(line[6]);

            return int.Parse(sb.ToString());
        }

        private string GetCrateName(string crate)
        {
            return crate[1].ToString();
        }
    }

    internal class StackInstructions
    {
        public int NumberOfCrates { get; set; }
        public int StartingStack { get; set; }
        public int EndingStack { get; set; }
    }
}
