using AdventOfCode2022.Solvers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022Tests
{
    public class Day06Tests
    {
        [Test]
        public void PartOne_Solve()
        {
            var solver = new Day06Solver();
            var characterCount = solver.CountCharacters_PartOne(solver.Datastream);

            Assert.That(characterCount, Is.EqualTo(1929));
        }

        [Test]
        public void PartTwo_Solve()
        {
            var solver = new Day06Solver();
            var characterCount = solver.CountCharacters_PartTwo(solver.Datastream);

            Assert.That(characterCount, Is.EqualTo(3298));
        }
    }
}
