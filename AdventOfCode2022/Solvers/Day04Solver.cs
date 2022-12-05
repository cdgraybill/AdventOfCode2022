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
        public int GetContainedRanges(List<string> problemInput)
        {
            var containedRanges = 0;

            foreach (var line in problemInput)
            {
                var assignmentRanges = GetAssignmentRanges(line);

                if (!assignmentRanges.AssignmentRangeOne.Except(assignmentRanges.AssignmentRangeTwo).Any() || 
                    !assignmentRanges.AssignmentRangeTwo.Except(assignmentRanges.AssignmentRangeOne).Any())
                    containedRanges++;
            }

            return containedRanges;
        }
        public int GetOverlappingRanges(List<string> problemInput)
        {
            var overlappingRanges = 0;

            foreach (var line in problemInput)
            {
                var assignmentRanges = GetAssignmentRanges(line);

                if (assignmentRanges.AssignmentRangeOne.Intersect(assignmentRanges.AssignmentRangeTwo).Any())
                    overlappingRanges++;
            }

            return overlappingRanges;
        }

        private string[] SplitSectionAssignments(string inputLine)
        {
            return inputLine.Split(",", StringSplitOptions.RemoveEmptyEntries);
        }

        private (int, int) ParseSectionAssignmentsToInt(string sectionAssignment)
        {
            var ranges = sectionAssignment.Split("-", StringSplitOptions.RemoveEmptyEntries);

            return (int.Parse(ranges[0]), int.Parse(ranges[1]));
        }

        private List<int> GetAssignmentRange(int rangeMin, int rangeMax)
        {
            return Enumerable.Range(rangeMin, rangeMax).ToList();
        }


        private AssignmentRanges GetAssignmentRanges(string line)
        {
            var sectionAssignments = SplitSectionAssignments(line);
            var (rangeOne, rangeTwo) = ParseSectionAssignmentsToInt(sectionAssignments[0]);
            var (rangeThree, rangeFour) = ParseSectionAssignmentsToInt(sectionAssignments[1]);

            var assignmentRangeOne = GetAssignmentRange(rangeOne, rangeTwo - rangeOne + 1);
            var assignmentRangeTwo = GetAssignmentRange(rangeThree, rangeFour - rangeThree + 1);

            return new AssignmentRanges()
            {
                AssignmentRangeOne = assignmentRangeOne,
                AssignmentRangeTwo = assignmentRangeTwo
            };
        }

    }

    public class AssignmentRanges
    {
        public List<int> AssignmentRangeOne { get; set; }
        public List<int> AssignmentRangeTwo { get; set; }
    }
}