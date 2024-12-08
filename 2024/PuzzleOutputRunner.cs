using Helpers;
namespace AdventOfCode.Year2024
{
    public class PuzzleOutputRunner
    {
        public void Run()
        {
            Console.WriteLine("Advent of Code 2024 - Puzzle Output Runner");
            while (true)
            {
                Console.WriteLine("Enter the day number to run the puzzle for (blank to exit):");
                string input = Console.ReadLine();
                if (string.IsNullOrEmpty(input))
                {
                    break;
                }

                if (int.TryParse(input, out int dayNumber))
                {
                    RunPuzze(dayNumber);
                }
                else
                {
                    break;
                }

                //2 blank lines
                Console.WriteLine();
                Console.WriteLine();
            }
        }

        private void RunPuzze(int DayNumber)
        {
            switch (DayNumber)
            {
                case 1:
                    //--------------------------DAY 01---------------------------------
                    Puzzle_Day_01 D1_Puzzle = new(InputHelper.GetInputFilePath("2024", "D1P1.txt"));
                    Console.WriteLine("AoC - Day 01 - Part 01");
                    Console.WriteLine(D1_Puzzle.Solve_Part01());
                    Console.WriteLine("AoC - Day 01 - Part 02");
                    Console.WriteLine(D1_Puzzle.Solve_Part02());
                    break;
                case 2:
                    //--------------------------DAY 02---------------------------------
                    Puzzle_Day_02 D2_Puzzle = new(InputHelper.GetInputFilePath("2024", "D2P1.txt"));
                    Console.WriteLine("AoC - Day 02 - Part 01");
                    Console.WriteLine(D2_Puzzle.Solve_Part01());
                    Console.WriteLine("AoC - Day 02 - Part 02");
                    Console.WriteLine(D2_Puzzle.Solve_Part02());
                    break;
                case 3:
                    //--------------------------DAY 03---------------------------------
                    Puzzle_Day_03 D3_Puzzle = new(InputHelper.GetInputFilePath("2024", "D3P1.txt"), true);
                    Console.WriteLine("AoC - Day 03 - Part 01");
                    Console.WriteLine(D3_Puzzle.Solve_Part01());
                    Console.WriteLine("AoC - Day 03 - Part 02");
                    Console.WriteLine(D3_Puzzle.Solve_Part02());
                    break;
                case 4:
                    //--------------------------DAY 04---------------------------------
                    Puzzle_Day_04 D4_Puzzle = new(InputHelper.GetInputFilePath("2024", "D4P1.txt"));
                    Console.WriteLine("AoC - Day 04 - Part 01");
                    Console.WriteLine(D4_Puzzle.Solve_Part01());
                    Console.WriteLine("AoC - Day 04 - Part 02");
                    Console.WriteLine(D4_Puzzle.Solve_Part02());
                    break;
                case 5:
                    //--------------------------DAY 05---------------------------------
                    Puzzle_Day_05 D5_Puzzle = new(InputHelper.GetInputFilePath("2024", "D5P1.txt"));
                    Console.WriteLine("AoC - Day 05 - Part 01");
                    Console.WriteLine(D5_Puzzle.Solve_Part01());
                    Console.WriteLine("AoC - Day 05 - Part 02");
                    Console.WriteLine(D5_Puzzle.Solve_Part02());
                    break;
                case 6:
                    //--------------------------DAY 06---------------------------------
                    Puzzle_Day_06 D6_Puzzle = new(InputHelper.GetInputFilePath("2024", "D6P1.txt"));
                    Console.WriteLine("AoC - Day 06 - Part 01");
                    Console.WriteLine(D6_Puzzle.Solve_Part01());
                    Console.WriteLine("AoC - Day 06 - Part 02");
                    Console.WriteLine(D6_Puzzle.Solve_Part02());
                    break;
                case 7:
                    //--------------------------DAY 07---------------------------------
                    Puzzle_Day_07 D7_Puzzle = new(InputHelper.GetInputFilePath("2024", "D7P1.txt"));
                    Console.WriteLine("AoC - Day 07 - Part 01");
                    Console.WriteLine(D7_Puzzle.Solve_Part01());
                    Console.WriteLine("AoC - Day 07 - Part 02");
                    Console.WriteLine(D7_Puzzle.Solve_Part02());
                    break;
                default:
                    Console.WriteLine("Day not implemented yet");
                    break;

            }
        }
    }
}
