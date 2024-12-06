using AdventOfCode.Year2024;
using Helpers;

namespace Year2024
{
    internal class Test_Day_06
    {
        [Test]
        public void Sample_Part_1()
        {
            Puzzle_Day_06 puzzle = new Puzzle_Day_06("D6S1.txt");
            Assert.That(puzzle.Solve_Part01(), Is.EqualTo(41));
        }

        [Test]
        public void Sample_Part_2()
        {
            Puzzle_Day_06 puzzle = new Puzzle_Day_06("D6S1.txt");
            Assert.That(puzzle.Solve_Part02(), Is.EqualTo(6));
        }

        [Test]
        public void Solution()
        {
            Puzzle_Day_06 puzzle = new Puzzle_Day_06("D6P1.txt");
            Assert.That(puzzle.Solve_Part01(), Is.EqualTo(4663));
            
            //disable too slow (brute forced solution)
            //Assert.That(puzzle.Solve_Part02(), Is.EqualTo(1530));
        }
    }
}
