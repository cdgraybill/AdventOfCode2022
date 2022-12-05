using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.Solvers
{
    public class Day04Solver
    {
        public readonly List<string> ProblemInput = File.ReadLines(@"C:ProblemInputs\Day04Input.txt").ToList();
        public readonly List<string> SampleInput = File.ReadLines(@"C:SampleInputs\Day04SampleInput.txt").ToList();

        public string[] SplitSectionAssignments(string inputLine)
        {
            return inputLine.Split(",", StringSplitOptions.RemoveEmptyEntries);
        }

        public (int, int) ParseSectionAssignmentsToInt(string sectionAssignment)
        {
            var ranges = sectionAssignment.Split("-", StringSplitOptions.RemoveEmptyEntries);

            return (int.Parse(ranges[0]), int.Parse(ranges[1]));
        }

        public List<int> GetAssignmentRange(int rangeMin, int rangeMax)
        {
            return Enumerable.Range(rangeMin, rangeMax).ToList();
        }

        public int GetContainedRanges(List<string> problemInput)
        {
            var containedRanges = 0;

            foreach (var line in problemInput)
            {
                var sectionAssignments = SplitSectionAssignments(line);
                var (rangeOne, rangeTwo) = ParseSectionAssignmentsToInt(sectionAssignments[0]);
                var (rangeThree, rangeFour) = ParseSectionAssignmentsToInt(sectionAssignments[1]);

                var assignmentRangeOne = GetAssignmentRange(rangeOne, rangeTwo - rangeOne + 1);
                var assignmentRangeTwo = GetAssignmentRange(rangeThree, rangeFour - rangeThree + 1);

                if (!assignmentRangeOne.Except(assignmentRangeTwo).Any() || !assignmentRangeTwo.Except(assignmentRangeOne).Any())
                    containedRanges++;
            }

            return containedRanges;
        }

        public int GetOverlappingRanges(List<string> problemInput)
        {
            var overlappingRanges = 0;

            foreach (var line in problemInput)
            {
                var sectionAssignments = SplitSectionAssignments(line);
                var (rangeOne, rangeTwo) = ParseSectionAssignmentsToInt(sectionAssignments[0]);
                var (rangeThree, rangeFour) = ParseSectionAssignmentsToInt(sectionAssignments[1]);

                var assignmentRangeOne = GetAssignmentRange(rangeOne, rangeTwo - rangeOne + 1);
                var assignmentRangeTwo = GetAssignmentRange(rangeThree, rangeFour - rangeThree + 1);

                if (assignmentRangeOne.Intersect(assignmentRangeTwo).Any())
                    overlappingRanges++;
            }

            return overlappingRanges;
        }
    }
}