using AdventOfCode.Year2024;
using Helpers;

namespace Year2024
{
    internal class Test_Day_08
    {

        [Test]
        public void Sample_Part_1()
        {
            Puzzle_Day_08 puzzle = new Puzzle_Day_08("D8S1.txt");
            Assert.That(puzzle.Solve_Part01(), Is.EqualTo(14));
        }

        [Test]
        public void Sample_Part_2()
        {
            Puzzle_Day_08 puzzle = new Puzzle_Day_08("D8S1.txt");
            Assert.That(puzzle.Solve_Part02(), Is.EqualTo(34));
        }

        [Test]
        public void Solution()
        {
            Puzzle_Day_08 puzzle = new Puzzle_Day_08("D8P1.txt");
            Assert.That(puzzle.Solve_Part01(), Is.EqualTo(371));
            Assert.That(puzzle.Solve_Part02(), Is.EqualTo(1229));
        }
    }
}
