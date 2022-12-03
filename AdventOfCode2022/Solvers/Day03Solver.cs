using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.Solvers
{
    public class Day03Solver
    {
        public readonly List<string> ProblemInput = File.ReadLines(@"C:ProblemInputs\Day03Input.txt").ToList();
        public readonly Dictionary<string, int> Priorities = new Dictionary<string, int>()
        {
            {"a", 1},
            {"b", 2},
            {"c", 3},
            {"d", 4},
            {"e", 5},
            {"f", 6},
            {"g", 7},
            {"h", 8},
            {"i", 9},
            {"j", 10},
            {"k", 11},
            {"l", 12},
            {"m", 13},
            {"n", 14},
            {"o", 15},
            {"p", 16},
            {"q", 17},
            {"r", 18},
            {"s", 19},
            {"t", 20},
            {"u", 21},
            {"v", 22},
            {"w", 23},
            {"x", 24},
            {"y", 25},
            {"z", 26}
        };

        public CompartmentContents GetCompartmentContents(string rucksack)
        {
            var compartments = new CompartmentContents();

            var capacity = rucksack.Count() / 2;
            compartments.CompartmentOneContents = rucksack[..capacity];
            compartments.CompartmentTwoContents = rucksack[capacity..];

            return compartments;
        }

        public int GetCapcitySum(List<string> problemInput)
        {
            var capacitySum = 0;

            foreach (var rucksack in problemInput)
            {
                var compartmentContents = GetCompartmentContents(rucksack);
                var commonItemList = compartmentContents.CompartmentOneContents
                    .Intersect(compartmentContents.CompartmentTwoContents).ToList();

                capacitySum = AddPriorityToSum(capacitySum, commonItemList);
            }

            return capacitySum;
        }

        private int AddPriorityToSum(int capacitySum, List<char> commonItemList)
        {
            var commonItem = commonItemList[0].ToString().ToLower();
            var priority = Priorities[commonItem];

            if (commonItemList[0].ToString() != commonItem)
            {
                priority += 26;
            }

            capacitySum += priority;
            return capacitySum;
        }

        public int GetAllGroupBadgeSum()
        {
            var elfGroup = new List<string>();
            var badgeSum = 0;

            for (int i = 0; i < ProblemInput.Count(); i++)
            {
                var inputLine = ProblemInput[i];
                var groupCount = i + 1;

                elfGroup.Add(inputLine);
                badgeSum = GetGroupBageSum(elfGroup, badgeSum, groupCount);
            }

            return badgeSum;
        }

        private int GetGroupBageSum(List<string> elfGroup, int badgeSum, int groupCount)
        {
            if (groupCount % 3 == 0)
            {
                var commonItemList = elfGroup[0]
                .Intersect(elfGroup[1])
                .Intersect(elfGroup[2])
                .ToList();

                badgeSum = AddPriorityToSum(badgeSum, commonItemList);

                elfGroup.Clear();
            }

            return badgeSum;
        }
    }

    public class CompartmentContents
    {
        public string CompartmentOneContents { get; set; }
        public string CompartmentTwoContents { get; set; }
    }
}
