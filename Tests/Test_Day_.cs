using AdventOfCode.Year2024;
using Helpers;

namespace Year2024
{
    internal class Test_Day_
    {
        private string SampleFile = "DXS1.txt";
        private string PuzzleFile = "DXP1.txt";

        [Test]
        public void Sample_Part_1()
        {
            Puzzle_Day_XX puzzle = new(SampleFile);
            Assert.That(puzzle.Solve_Part01(), Is.EqualTo(0));
        }

        [Test]
        public void Sample_Part_2()
        {
            Puzzle_Day_XX puzzle = new(SampleFile);
            Assert.That(puzzle.Solve_Part02(), Is.EqualTo(0));
        }

        [Test]
        public void Solution()
        {
            Puzzle_Day_XX puzzle = new(PuzzleFile);
            Assert.That(puzzle.Solve_Part01(), Is.EqualTo(0));
            Assert.That(puzzle.Solve_Part02(), Is.EqualTo(0));
        }
    }
}
