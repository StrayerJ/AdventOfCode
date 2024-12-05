using AdventOfCode.Year2024;
using Helpers;

namespace Year2024
{
    internal class Test_Day_02
    {
        private string sampleInput = "";

        [SetUp]
        public void Setup()
        {
            sampleInput = @"7 6 4 2 1
                            1 2 7 8 9
                            9 7 6 2 1
                            1 3 2 4 5
                            8 6 4 4 1
                            1 3 6 7 9";
        }

        [Test]
        public void Sample_Part_1()
        {
            var lists = InputHelper.ParseLists_ByRow_FromString<int>(sampleInput);
            Puzzle_Day_02 puzzle = new(lists);
            Assert.That(puzzle.Solve_Part01(), Is.EqualTo(2));
        }

        [Test]
        public void Sample_Part_2()
        {
            var lists = InputHelper.ParseLists_ByRow_FromString<int>(sampleInput);
            Puzzle_Day_02 puzzle = new(lists);
            Assert.That(puzzle.Solve_Part02(), Is.EqualTo(4));
        }

        [Test]
        public void Solution()
        {
            // 572
            // 612
            string inputFile = InputHelper.GetInputFilePath("2024", "D2P1.txt");
            Puzzle_Day_02 puzzle = new(inputFile);
            Assert.That(puzzle.Solve_Part01(), Is.EqualTo(572));
            Assert.That(puzzle.Solve_Part02(), Is.EqualTo(612));
        }
    }
}
