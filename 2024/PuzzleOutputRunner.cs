using Helpers;
namespace AdventOfCode.Year2024
{
    public class PuzzleOutputRunner
    {
        public void Run()
        {
            //--------------------------DAY 01 - Part 01---------------------------------
            Console.WriteLine("AoC - Day 01 - Part 01");
            Puzzle_Day_01 D1P1_Puzzle = new(InputHelper.GetInputFilePath("2024", "D1P1.txt"));
            Console.WriteLine(D1P1_Puzzle.Solve_Part01());


            //--------------------------DAY 01 - Part 02---------------------------------
            Console.WriteLine("AoC - Day 01 - Part 02");
            Puzzle_Day_01 D1P2_Puzzle = new(InputHelper.GetInputFilePath("2024", "D1P1.txt"));
            Console.WriteLine(D1P2_Puzzle.Solve_Part02());




            //--------------------------DAY 02 - Part 01---------------------------------
            Console.WriteLine("AoC - Day 02 - Part 01");
            Puzzle_Day_02 D2P1_Puzzle = new(InputHelper.GetInputFilePath("2024", "D2P1.txt"));
            Console.WriteLine(D2P1_Puzzle.Solve_Part01());

            //--------------------------DAY 02 - Part 02---------------------------------
            Console.WriteLine("AoC - Day 02 - Part 02");
            Puzzle_Day_02 D2P2_Puzzle = new(InputHelper.GetInputFilePath("2024", "D2P1.txt"));
            Console.WriteLine(D2P2_Puzzle.Solve_Part02());
        }
    }
}
