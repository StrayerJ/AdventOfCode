using AdventOfCode.Year2024;
using Helpers;

namespace Year2024
{
    internal class Test_Day_05
    {
        [Test]
        public void Sample_Part_1()
        {
            Puzzle_Day_05 puzzle = new Puzzle_Day_05(InputHelper.GetInputFilePath("2024", "D5S1.txt"));
            Assert.That(puzzle.Solve_Part01(), Is.EqualTo(143));
        }

        [Test]
        public void Sample_Part_2()
        {
            Puzzle_Day_05 puzzle = new Puzzle_Day_05(InputHelper.GetInputFilePath("2024", "D5S1.txt"));
            Assert.That(puzzle.Solve_Part02(), Is.EqualTo(123));
        }

        [Test]
        public void Solution()
        {
            Puzzle_Day_05 puzzle = new Puzzle_Day_05(InputHelper.GetInputFilePath("2024", "D5P1.txt"));
            Assert.That(puzzle.Solve_Part01(), Is.EqualTo(4905));
            Assert.That(puzzle.Solve_Part02(), Is.EqualTo(6204));
        }
    }
}
