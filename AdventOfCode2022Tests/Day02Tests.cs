using AdventOfCode2022.Solvers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022Tests
{
    public class Day02Tests
    {
        [Test]
        public void GetTotalScore_SolveBothParts()
        {
            var solver = new Day02Solver();
            var totalScore = solver.GetTotalScore();

            Assert.That(totalScore.PartOneAnswer, Is.EqualTo(8890));
            Assert.That(totalScore.PartTwoAnswer, Is.EqualTo(10238));
        }
    }
}
