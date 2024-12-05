using AdventOfCode.Year2024;
using Helpers;

namespace Year2024
{
    internal class Test_Day_03
    {
        private string sampleInput = "";


        [Test]
        public void Sample_Part_1()
        {
            Puzzle_Day_03 puzzle = new(@"xmul(2,4)%&mul[3,7]!@^do_not_mul(5,5)+mul(32,64]then(mul(11,8)mul(8,5))");
            Assert.That(puzzle.Solve_Part01(), Is.EqualTo(161));
        }

        [Test]
        public void Sample_Part_2()
        {
            Puzzle_Day_03 puzzle = new(@"xmul(2,4)&mul[3,7]!^don't()_mul(5,5)+mul(32,64](mul(11,8)undo()?mul(8,5))");
            Assert.That(puzzle.Solve_Part02(), Is.EqualTo(48));
        }

        [Test]
        public void Solution()
        {
        }
    }
}
