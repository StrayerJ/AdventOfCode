using AdventOfCode.Year2024;
using Helpers;

namespace Year2024
{
    internal class Test_Day_09
    {
        private string SampleFile = "D9S1.txt";
        private string PuzzleFile = "D9P1.txt";

        [Test]
        public void Sample_Part_1()
        {
            Puzzle_Day_09 puzzle = new Puzzle_Day_09(SampleFile);
            Assert.That(puzzle.Solve_Part01(), Is.EqualTo(1928));
        }

        [Test]
        public void Sample_Part_2()
        {
            Puzzle_Day_09 puzzle = new Puzzle_Day_09(SampleFile);
            Assert.That(puzzle.Solve_Part02(), Is.EqualTo(2858));
        }

        [Test]
        [Explicit("This test takes a long time to run. Only run it manually.")]
        public void Solution()
        {
            Puzzle_Day_09 puzzle = new Puzzle_Day_09(PuzzleFile);
            Assert.That(puzzle.Solve_Part01(), Is.EqualTo(6332189866718));

            puzzle = new Puzzle_Day_09(PuzzleFile);
            Assert.That(puzzle.Solve_Part02(), Is.EqualTo(6353648390778));
        }
    }
}
