using AdventOfCode2022.Solvers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022Tests
{
    public class Day03Tests
    {
        [Test]
        public void SolvePartOne()
        {
            var solver = new Day03Solver();
            var capacitySum = solver.FindCapcitySum(solver.ProblemInput);

            Assert.That(capacitySum, Is.EqualTo(7903));
        }

        [Test]
        public void SolvePartTwo()
        {
            var solver = new Day03Solver();
            var groupSum = solver.GetAllGroupBadgeSum();

            Assert.That(groupSum, Is.EqualTo(7903));
        }
    }
}
