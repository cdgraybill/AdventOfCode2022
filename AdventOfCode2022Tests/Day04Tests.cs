using AdventOfCode2022.Solvers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022Tests
{
    public class Day04Tests
    {
        [Test]
        public void PartOne_Solve()
        {
            var solver = new Day04Solver();
            var answer = solver.GetContainedRanges(solver.ProblemInput);

            Assert.That(answer, Is.EqualTo(433));
        }

        [Test]
        public void PartTwo_Solve()
        {
            var solver = new Day04Solver();
            var answer = solver.GetOverlappingRanges(solver.ProblemInput);

            Assert.That(answer, Is.EqualTo(852));
        }
    }
}
