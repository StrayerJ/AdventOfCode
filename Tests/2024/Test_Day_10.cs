using AdventOfCode.Year2024;
using Helpers;

namespace Year2024
{
    internal class Test_Day_10
    {
        private string SampleFile = "D10S1.txt";
        private string PuzzleFile = "D10P1.txt";

        [Test]
        public void Sample_Part_1()
        {
            Puzzle_Day_10 puzzle = new(SampleFile);
            Assert.That(puzzle.Solve_Part01(), Is.EqualTo(36));
        }

        [Test]
        public void Sample_Part_2()
        {
            Puzzle_Day_10 puzzle = new(SampleFile);
            Assert.That(puzzle.Solve_Part02(), Is.EqualTo(81));
        }

        [Test]
        public void Solution()
        {
            Puzzle_Day_10 puzzle = new(PuzzleFile);
            Assert.That(puzzle.Solve_Part01(), Is.EqualTo(0));
            Assert.That(puzzle.Solve_Part02(), Is.EqualTo(0));
        }
    }
}
