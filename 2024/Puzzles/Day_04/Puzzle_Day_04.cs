using Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Year2024
{
    public class Puzzle_Day_04
    {
        private char[][] WordSearch;

        public Puzzle_Day_04(string filename)
        {
            string input = InputHelper.ParseFile(InputHelper.GetInputFilePath("2024",filename));
            char[][] matrix = ContainerHelper.ParseMatrixFromString<char>(input, "");
            WordSearch = ContainerHelper.NormalizeToXYMap<char>(matrix);
        }

        public int Solve_Part01()
        {
            string searchWord = "XMAS";
            List<(int X, int Y, Direction Dir)> result = FindAllWords(searchWord);
            return result.Count;
        }

        public int Solve_Part02()
        {
            List<(int X, int Y)> result = FindAllCrossMAS();
            return result.Count;
        }

        private List<(int X, int Y, Direction Dir)> FindAllWords(string word)
        {
            List<(int X, int Y, Direction Dir)> result = new List<(int X, int Y, Direction Dir)>();

            for (int y = 0; y < WordSearch.Length; y++)
            {
                for (int x = 0; x < WordSearch[y].Length; x++)
                {
                    if (WordSearch[y][x] == word[0])
                    {
                        foreach (Direction dir in Enum.GetValues(typeof(Direction)))
                        {
                            if (CheckWord(word, x, y, dir))
                            {
                                result.Add((x, y, dir));
                            }
                        }
                    }
                }
            }

            return result;

        }

        private List<(int X, int Y)> FindAllCrossMAS()
        {
            // Find all occurrences of "MAS"
            List<(int X, int Y, Direction Dir)> masPositions = FindAllWords("MAS");

            // List to store valid crossing points
            List<(int X, int Y)> result = new List<(int X, int Y)>();

            // Check for overlaps of 'A' (middle character)
            foreach (var first in masPositions)
            {
                foreach (var second in masPositions)
                {
                    if (first == second)
                        continue;

                    // Get the position of 'A' for both "MAS" occurrences
                    var firstA = GetMiddlePosition(first);
                    var secondA = GetMiddlePosition(second);

                    // Check if they overlap and are aligned
                    if (firstA == secondA && AreAligned(first, second))
                    {
                        if (!result.Contains(firstA))
                            result.Add(firstA);
                    }
                }
            }

            return result;
        }


        private bool CheckWord(string word, int x, int y, Direction dir)
        {
            int dx = 0;
            int dy = 0;

            switch (dir)
            {
                case Direction.Up:
                    dy = -1;
                    break;
                case Direction.Down:
                    dy = 1;
                    break;
                case Direction.Left:
                    dx = -1;
                    break;
                case Direction.Right:
                    dx = 1;
                    break;
                case Direction.UpLeft:
                    dx = -1;
                    dy = -1;
                    break;
                case Direction.UpRight:
                    dx = 1;
                    dy = -1;
                    break;
                case Direction.DownLeft:
                    dx = -1;
                    dy = 1;
                    break;
                case Direction.DownRight:
                    dx = 1;
                    dy = 1;
                    break;
            }

            for (int i = 1; i < word.Length; i++)
            {
                int newX = x + (dx * i);
                int newY = y + (dy * i);

                if (newX < 0 || newX >= WordSearch[0].Length || newY < 0 || newY >= WordSearch.Length)
                {
                    return false;
                }

                if (WordSearch[newY][newX] != word[i])
                {
                    return false;
                }
            }

            return true;

        }

        private (int X, int Y) GetMiddlePosition((int X, int Y, Direction Dir) position)
        {
            int dx = 0, dy = 0;

            switch (position.Dir)
            {
                case Direction.Up:
                    dy = -1;
                    break;
                case Direction.Down:
                    dy = 1;
                    break;
                case Direction.Left:
                    dx = -1;
                    break;
                case Direction.Right:
                    dx = 1;
                    break;
                case Direction.UpLeft:
                    dx = -1; dy = -1;
                    break;
                case Direction.UpRight:
                    dx = 1; dy = -1;
                    break;
                case Direction.DownLeft:
                    dx = -1; dy = 1;
                    break;
                case Direction.DownRight:
                    dx = 1; dy = 1;
                    break;
            }

            // Move one step in the direction to get the position of 'A'
            return (position.X + dx, position.Y + dy);
        }

        private bool AreAligned((int X, int Y, Direction Dir) first, (int X, int Y, Direction Dir) second)
        {
            if((first.Dir == Direction.Up || first.Dir == Direction.Down || first.Dir == Direction.Left || first.Dir == Direction.Right))
            {
                return false;
            }

            if ((second.Dir == Direction.Up || second.Dir == Direction.Down || second.Dir == Direction.Left || second.Dir == Direction.Right))
            {
                return false;
            }

            return true;
        }

    }
}
