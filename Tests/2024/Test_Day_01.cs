using AdventOfCode.Year2024;
using Helpers;

namespace AoC_Tests.Year2024
{
    internal class Test_Day_01
    {
        [Test]
        public void Sample_Part_1()
        {
            var lists = InputHelper.ParseListByColumn_FromString<int>(
                @"3   4
                4   3
                2   5
                1   3
                3   9
                3   3");

            Puzzle_Day_01 puzzle = new(lists[0], lists[1]);
            Assert.That(puzzle.Solve_Part01(), Is.EqualTo(11));
        }


        [Test]
        public void Sample_Part_2()
        {
            var lists = InputHelper.ParseListByColumn_FromString<int>(
                @"3   4
                4   3
                2   5
                1   3
                3   9
                3   3");
            Puzzle_Day_01 puzzle = new(lists[0], lists[1]);
            Assert.That(puzzle.Solve_Part02(), Is.EqualTo(31));
        }

        [Test]
        public void Solution()
        {
            //2086478
            //24941624
            string inputFile = InputHelper.GetInputFilePath("2024", "D1P1.txt");
            Puzzle_Day_01 puzzle = new(inputFile);
            Assert.That(puzzle.Solve_Part01(), Is.EqualTo(2086478));
            Assert.That(puzzle.Solve_Part02(), Is.EqualTo(24941624));
        }
    }
}
