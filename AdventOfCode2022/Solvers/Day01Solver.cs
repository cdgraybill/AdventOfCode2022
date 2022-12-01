using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.Solvers
{
    public class Day01Solver
    {
        public readonly List<string> ProblemInput = File.ReadLines(@"C:ProblemInputs\Day01Input.txt").ToList();

        public List<int> GetHaulsOfAllElves(List<string> sampleInput)
        {
            var hauls = new List<int>();
            var totalCalories = 0;

            foreach (string line in sampleInput)
            {
                if (line != "")
                {
                    var food = int.Parse(line);
                    totalCalories += food;
                }
                else
                {
                    hauls.Add(totalCalories);
                    totalCalories = 0;
                }
            }

            return hauls;
        }

        public int GetLargestCalorieAmount(List<int> hauls)
        {
            return hauls.Max();
        }

        public int GetTotalOfTopThreeCalorieAmounts(List<int> hauls)
        {
            int first = -1;
            int second = -1;
            int third = -1;

            foreach (int haul in hauls)
            {
                if (haul > first) 
                {
                    third = second;
                    second = first; 
                    first = haul; 
                }
                else if (haul > second) 
                { 
                    second = haul; 
                }
                else if (haul > third)
                {
                    third = haul;
                }
            }

            return first + second + third;
        }
    }
}
