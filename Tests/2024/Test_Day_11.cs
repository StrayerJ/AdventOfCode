using AdventOfCode.Year2024;
using Helpers;

namespace Year2024
{
    internal class Test_Day_11
    {
        private string SampleFile = "D11S1.txt";
        private string PuzzleFile = "D11P1.txt";

        [Test]
        public void Sample_Part_1()
        {
            Puzzle_Day_11 puzzle = new(SampleFile);
            Assert.That(puzzle.Solve_Part01(), Is.EqualTo(55312));
        }

        [Test]
        public void Sample_Part_2()
        {
            Puzzle_Day_11 puzzle = new(SampleFile);
            Assert.That(puzzle.Solve_Part02(), Is.EqualTo(65601038650482));
        }

        [Test]
        public void Solution()
        {
            Puzzle_Day_11 puzzle = new(PuzzleFile);
            Assert.That(puzzle.Solve_Part01(), Is.EqualTo(186996));
            Assert.That(puzzle.Solve_Part02(), Is.EqualTo(221683913164898));
        }
    }
}
