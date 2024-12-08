using AdventOfCode.Year2024;
using Helpers;

namespace Year2024
{
    internal class Test_Day_04
    {
        private string sampleInput = "";


        [Test]
        public void Sample_Part_1()
        {
            Puzzle_Day_04 d4 = new Puzzle_Day_04("D4S1.txt");
            Assert.That(d4.Solve_Part01(), Is.EqualTo(18));
        }
            
        [Test]
        public void Sample_Part_2()
        {
            Puzzle_Day_04 d4 = new Puzzle_Day_04("D4S1.txt");
            Assert.That(d4.Solve_Part02(), Is.EqualTo(9));
        }

        [Test]
        public void Solution()
        {
            Puzzle_Day_04 d4 = new Puzzle_Day_04("D4P1.txt");
            Assert.That(d4.Solve_Part01(), Is.EqualTo(2336));
            Assert.That(d4.Solve_Part02(), Is.EqualTo(1831));
        }
    }
}
