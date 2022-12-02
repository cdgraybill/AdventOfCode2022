using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.Solvers
{
    public class Day02Solver
    {
        public readonly List<string> ProblemInput = File.ReadLines(@"C:ProblemInputs\Day02Input.txt").ToList();

        public int GetRoundScore_PartOne(char opponentsMove, char myMove)
        {
            var score = 0;

            switch(opponentsMove, myMove)
            {
                case ('A', 'X'):
                    score = 4;
                    break;
                case ('A', 'Y'):
                    score = 8;
                    break;
                case ('A', 'Z'):
                    score = 3;
                    break;
                case ('B', 'X'):
                    score = 1;
                    break;
                case ('B', 'Y'):
                    score = 5;
                    break;
                case ('B', 'Z'):
                    score = 9;
                    break;
                case ('C', 'X'):
                    score = 7;
                    break;
                case ('C', 'Y'):
                    score = 2;
                    break;
                case ('C', 'Z'):
                    score = 6;
                    break;
            }

            return score;
        }

        public int GetRoundScore_PartTwo(char opponentsMove, char myMove)
        {
            var score = 0;

            switch (opponentsMove, myMove)
            {
                case ('A', 'X'):
                    score = 3;
                    break;
                case ('A', 'Y'):
                    score = 4;
                    break;
                case ('A', 'Z'):
                    score = 8;
                    break;
                case ('B', 'X'):
                    score = 1;
                    break;
                case ('B', 'Y'):
                    score = 5;
                    break;
                case ('B', 'Z'):
                    score = 9;
                    break;
                case ('C', 'X'):
                    score = 2;
                    break;
                case ('C', 'Y'):
                    score = 6;
                    break;
                case ('C', 'Z'):
                    score = 7;
                    break;
            }

            return score;
        }

        public Answers GetTotalScore()
        {
            var totalScorePartOne = 0;
            var totalScorePartTwo = 0;
            var roundMoves = GetRoundMoves(ProblemInput);

            for (int i = 0; i < roundMoves.OpponentsMoves.Count; i++)
            {
                totalScorePartOne += GetRoundScore_PartOne(roundMoves.OpponentsMoves[i], roundMoves.MyMoves[i]);
                totalScorePartTwo += GetRoundScore_PartTwo(roundMoves.OpponentsMoves[i], roundMoves.MyMoves[i]);
            }

            var answers = new Answers()
            {
                PartOneAnswer = totalScorePartOne,
                PartTwoAnswer = totalScorePartTwo
            };

            return answers;
        }

        private RoundMoves GetRoundMoves(List<string> problemInput)
        {
            var opponentsMoves = new List<char>();
            var myMoves = new List<char>();

            foreach (var line in problemInput)
            {
                opponentsMoves.Add(line[0]);
                myMoves.Add(line[2]);
            }

            var roundMoves = new RoundMoves()
            {
                OpponentsMoves = opponentsMoves,
                MyMoves = myMoves
            };

            return roundMoves;
        }
    }

    public class RoundMoves
    {
        public List<char> OpponentsMoves { get; set; }
        public List<char> MyMoves { get; set; }
    }

    public class Answers
    {
        public int PartOneAnswer { get; set; }
        public int PartTwoAnswer { get; set; }
    }
}
