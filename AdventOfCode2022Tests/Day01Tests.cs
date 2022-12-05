using AdventOfCode2022.Solvers;

namespace AdventOfCode2022Tests
{
    public class Day01Tests
    {
        private List<string> sampleInput = new List<string>()
        {
            "1000",
            "2000",
            "3000",
            "",
            "4000",
            "",
            "5000",
            "6000",
            "",
            "7000",
            "8000",
            "9000",
            "",
            "10000"
        };

        [Test]
        public void GetHaulsOfAllElves()
        {
            var solver = new Day01Solver();

            var hauls = solver.GetHaulsOfAllElves(sampleInput);

            Assert.That(hauls, Does.Contain(6000));
            Assert.That(hauls, Does.Contain(4000));
            Assert.That(hauls, Does.Contain(11000));
            Assert.That(hauls, Does.Contain(24000));
        }

        [Test]
        public void GetTotalOfTopThreeCalorieAmounts_Solve()
        {
            var solver = new Day01Solver();

            var hauls = solver.GetHaulsOfAllElves(solver.ProblemInput);
            var totalCalories = solver.GetTotalOfTopThreeCalorieAmounts(hauls);

            Assert.That(totalCalories, Is.EqualTo(209691));
        }

        [Test]
        public void GetLargestCalorieAmount_Solve()
        {
            var solver = new Day01Solver();

            var hauls = solver.GetHaulsOfAllElves(solver.ProblemInput);
            var largestCalorieAmount = solver.GetLargestCalorieAmount(hauls);

            Assert.That(largestCalorieAmount, Is.EqualTo(71300));
        }
    }
}