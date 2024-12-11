using Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Year2024
{
    public class Puzzle_Day_06
    {
        string[][] Map;

        //list of coordinates for obstacles
        List<(int, int)> Obstacles = new List<(int, int)>();
        HashSet<(int, int)> Visited = new HashSet<(int, int)>();
        HashSet<(int, int, CardinalDirection)> PathHistory = new HashSet<(int, int, CardinalDirection)>();

        (int, int) StartingGuardPosition;
        CardinalDirection StartingGuardDirection;

        public Puzzle_Day_06(string filename)
        {
            string fpath = InputHelper.GetInputFilePath("2024", filename);
            string[][] tMap = InputHelper.ParseMatrixFromFile<string>(fpath, "");
            Map = ContainerHelper.NormalizeToXY<string>(tMap);

            InitializeMap();
        }

        public int Solve_Part01()
        {
            TraverseMap();
            return Visited.Count;
        }

        public int Solve_Part02()
        {
            return FindPotentialLoops();
        }

        private void InitializeMap()
        {
            for (int x = 0; x < Map.Length; x++)
            {
                for (int y = 0; y < Map[x].Length; y++)
                {
                    (int, int) currPos = new(x, y);
                    string currPosVal = Map[x][y];

                    switch (currPosVal)
                    {
                        case ".":
                            //open space - do nothing
                            break;
                        case "#":
                            //obstacle - add to list
                            Obstacles.Add((x, y));
                            break;
                        default:
                            //must be a guard position
                            SetGuard(currPos, currPosVal);
                            break;
                    }
                }
            }
        }

        private void SetGuard((int, int) pos, string val)
        {
            StartingGuardPosition = pos;
            switch (val)
            {
                case ">":
                    StartingGuardDirection = CardinalDirection.East;
                    break;
                case "<":
                    StartingGuardDirection = CardinalDirection.West;
                    break;
                case "^":
                    StartingGuardDirection = CardinalDirection.North;
                    break;
                case "v":
                    StartingGuardDirection = CardinalDirection.South;
                    break;
                default:
                    throw new Exception("Invalid guard direction");
            }
        }

        private (int, int) Forward((int, int) pos, CardinalDirection dir)
        {
            switch (dir)
            {
                case CardinalDirection.North:
                    return (pos.Item1, pos.Item2 + 1);
                case CardinalDirection.East:
                    return (pos.Item1 + 1, pos.Item2);
                case CardinalDirection.South:
                    return (pos.Item1, pos.Item2 - 1);
                case CardinalDirection.West:
                    return (pos.Item1 - 1, pos.Item2);
                default:
                    throw new Exception("Invalid guard direction");
            }
        }

        private CardinalDirection TurnRight(CardinalDirection dir)
        {
            switch (dir)
            {
                case CardinalDirection.North:
                    return CardinalDirection.East;
                case CardinalDirection.East:
                    return CardinalDirection.South;
                case CardinalDirection.South:
                    return CardinalDirection.West;
                case CardinalDirection.West:
                    return CardinalDirection.North;
                default:
                    throw new Exception("Invalid guard direction");
            }
        }

        private bool TraverseMap()
        {
            bool hasExited = false;
            (int, int) currPos = StartingGuardPosition;
            CardinalDirection currDir = StartingGuardDirection;

            // Ensure the starting position is marked as visited
            Visited.Add(currPos);
            PathHistory.Add((currPos.Item1, currPos.Item2, currDir));

            while (!hasExited)
            {
                // Move forward to the next position
                (int, int) nextPos = Forward(currPos, currDir);

                // Check if we left the map
                if (nextPos.Item1 < 0 || nextPos.Item1 >= Map.Length || nextPos.Item2 < 0 || nextPos.Item2 >= Map[0].Length)
                {
                    hasExited = true;
                }
                else if (Obstacles.Contains(nextPos))
                {
                    // If we hit an obstacle, turn right
                    currDir = TurnRight(currDir);
                }
                else
                {
                    // Move to the next position and mark it as visited
                    currPos = nextPos;
                    Visited.Add(currPos);

                    if(PathHistory.Contains((currPos.Item1, currPos.Item2, currDir)))
                    {
                        //guard has fallen into a loop
                        return false;
                    }

                    PathHistory.Add((currPos.Item1, currPos.Item2, currDir));
                }
            }

            return true;
        }

        private int FindPotentialLoops()
        {
            int potentialLoops = 0;

            //brute force adding obstacles to the map and checking if the guard will fall into a loop
            for (int x = 0; x < Map.Length; x++)
            {
                for (int y = 0; y < Map[x].Length; y++)
                {
                    if (Map[x][y] == ".")
                    {
                        //add obstacle
                        Obstacles.Add((x, y));

                        //reset visited and path history
                        Visited.Clear();
                        PathHistory.Clear();

                        //traverse the map
                        bool hasExited = TraverseMap();

                        //check if the guard has fallen into a loop
                        if (!hasExited)
                        {
                            potentialLoops++;
                        }

                        //remove obstacle
                        Obstacles.Remove((x, y));
                    }
                }
            }

            return potentialLoops;
        }

    }
}
