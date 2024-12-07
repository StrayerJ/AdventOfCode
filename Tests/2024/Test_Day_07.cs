using AdventOfCode.Year2024;
using Helpers;

namespace Year2024
{
    internal class Test_Day_07
    {
        [Test]
        public void Sample_Part_1()
        {
            Puzzle_Day_07 puzzle = new Puzzle_Day_07("D7S1.txt");
            Assert.That(puzzle.Solve_Part01(), Is.EqualTo(3749));
        }

        [Test]
        public void Sample_Part_2()
        {
            Puzzle_Day_07 puzzle = new Puzzle_Day_07("D7S1.txt");
            Assert.That(puzzle.Solve_Part02(), Is.EqualTo(11387));
        }

        [Test]
        [Explicit("This test takes a long time to run. Only run it manually.")]
        public void Solution()
        {
            Puzzle_Day_07 puzzle = new Puzzle_Day_07("D7P1.txt");
            Assert.That(puzzle.Solve_Part01(), Is.EqualTo(2501605301465));
            Assert.That(puzzle.Solve_Part02(), Is.EqualTo(44841372855953));
        }
    }
}
