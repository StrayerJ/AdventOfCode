using Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Year2024
{
    public class Puzzle_Day_10
    {
        private int[][] TopographyMap;
        private List<(int X, int Y)> TrailHeads = new List<(int, int)>();

        public Puzzle_Day_10(string filename)
        {
            TopographyMap = InputHelper.ParseMatrixFromFile_Normalized<int>(InputHelper.GetInputFilePath("2024", filename), "");
            TrailHeads = FindAllTrailheads();
        }

        public int Solve_Part01()
        {
            int totalScore = 0;
            List<HashSet<(int X, int Y)>> paths = FindPaths();
            foreach (var path in paths)
            {
                totalScore += GetScore(path);
            }

            return totalScore;
        }

        public int Solve_Part02()
        {
            // Find all distinct paths from trailheads to trail ends
            List<List<(int X, int Y)>> allPaths = FindDistinctPaths();

            // Return the count of all distinct paths
            return allPaths.Count;
        }


        public List<(int X, int Y)> FindAllTrailheads()
        {
            for (int i = 0; i < TopographyMap.Length; i++)
            {
                for (int j = 0; j < TopographyMap[i].Length; j++)
                {
                    if (TopographyMap[i][j] == 0)
                    {
                        TrailHeads.Add((i, j));
                    }
                }
            }
            return TrailHeads;
        }

        public List<HashSet<(int X, int Y)>> FindPaths()
        {
            List<HashSet<(int X, int Y)>> allPaths = new List<HashSet<(int X, int Y)>>();

            //find each path from the trailhead to a 9, by moving in the four cardinal directions and incrementing topography value by 1
            foreach (var trailhead in TrailHeads)
            {
                HashSet<(int X, int Y)> path = new HashSet<(int X, int Y)>();
                RecursivelyFindPath(trailhead, ref path);
                allPaths.Add(path);
            }



            return allPaths;

        }

        private bool RecursivelyFindPath((int X, int Y) currentPos, ref HashSet<(int X, int Y)> paths)
        {
            int currentVal = TopographyMap[currentPos.X][currentPos.Y];

            // Add the current position to the path
            paths.Add(currentPos);

            // Base case: if the current value is 9, the path ends here
            if (currentVal == 9)
                return true;

            // Define all cardinal directions
            var directions = new[]
            {
                CardinalDirection.North,
                CardinalDirection.East,
                CardinalDirection.South,
                CardinalDirection.West
            };

            bool foundPath = false;

            foreach (var direction in directions)
            {
                (int X, int Y) nextPos = MoveDirection(currentPos, direction);

                // Check bounds and if the next value is incremented by 1
                if (CheckBounds(nextPos) && TopographyMap[nextPos.X][nextPos.Y] == currentVal + 1)
                {
                    // Recursively explore paths from the next position
                    if (RecursivelyFindPath(nextPos, ref paths))
                    {
                        foundPath = true;
                    }
                }
            }

            // If no valid path is found from this position, remove it from the path
            if (!foundPath)
                paths.Remove(currentPos);

            return foundPath;
        }

        private int GetScore(HashSet<(int X, int Y)> trail)
        {
            int score = 0;
            foreach (var pos in trail)
            {
                if(TopographyMap[pos.X][pos.Y] == 9)
                {
                    score++;
                }
            }
            return score;
        }

        public List<List<(int X, int Y)>> FindDistinctPaths()
        {
            List<List<(int X, int Y)>> allPaths = new List<List<(int X, int Y)>>();

            foreach (var trailhead in TrailHeads)
            {
                List<(int X, int Y)> currentPath = new List<(int X, int Y)>();
                RecursivelyFindDistinctPaths(trailhead, currentPath, allPaths);
            }

            return allPaths;
        }

        //just making a new function for pt2 instead of reworking pt1
        private void RecursivelyFindDistinctPaths((int X, int Y) currentPos, List<(int X, int Y)> currentPath, List<List<(int X, int Y)>> allPaths)
        {
            int currentVal = TopographyMap[currentPos.X][currentPos.Y];

            // Add the current position to the current path
            currentPath.Add(currentPos);

            // Base case: if the current value is 9, save the path and return
            if (currentVal == 9)
            {
                allPaths.Add(new List<(int X, int Y)>(currentPath));
                currentPath.RemoveAt(currentPath.Count - 1); // Backtrack
                return;
            }

            // Define all cardinal directions
            var directions = new[]
            {
                CardinalDirection.North,
                CardinalDirection.East,
                CardinalDirection.South,
                CardinalDirection.West
            };

            foreach (var direction in directions)
            {
                (int X, int Y) nextPos = MoveDirection(currentPos, direction);

                // Check bounds and if the next value is incremented by 1
                if (CheckBounds(nextPos) && TopographyMap[nextPos.X][nextPos.Y] == currentVal + 1 && !currentPath.Contains(nextPos))
                {
                    // Recursively explore paths from the next position
                    RecursivelyFindDistinctPaths(nextPos, currentPath, allPaths);
                }
            }

            // Backtrack by removing the current position from the path
            currentPath.RemoveAt(currentPath.Count - 1);
        }

        private bool CheckBounds((int X, int Y) pos)
        {
            return pos.X >= 0 && pos.X < TopographyMap.Length && pos.Y >= 0 && pos.Y < TopographyMap[0].Length;
        }

        private (int X, int Y) MoveDirection((int X, int Y) currentPos, CardinalDirection direction)
        {
            return direction switch
            {
                CardinalDirection.North => (currentPos.X, currentPos.Y + 1),
                CardinalDirection.East => (currentPos.X + 1, currentPos.Y),
                CardinalDirection.South => (currentPos.X, currentPos.Y - 1),
                CardinalDirection.West => (currentPos.X - 1, currentPos.Y),
                _ => throw new Exception("Invalid direction")
            };
        }
    }
}
