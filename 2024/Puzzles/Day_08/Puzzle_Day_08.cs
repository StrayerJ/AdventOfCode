using Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Year2024
{
    public class Puzzle_Day_08
    {
        private char[][] AntennaMap;

        HashSet<(char AntennaType, (int X, int Y) AntennaPosition)> AntennaPositions = new HashSet<(char AntennaType, (int X, int Y) AntennaPosition)>();
        HashSet<(char AntennaType, (int X, int Y) Antenna1, (int X, int Y) Antenna2)> AntennaPairs = new HashSet<(char AntennaType, (int X, int Y) Antenna1, (int X, int Y) Antenna2)>();
        HashSet<(int X, int Y)> Antinodes = new HashSet<(int X, int Y)>();

        //regex string to test for single lowercase letter, uppercase letter, or digit
        string antennaMatchPattern = @"[a-z]|[A-Z]|\d";

        public Puzzle_Day_08(string filename)
        {
            string fpath = InputHelper.GetInputFilePath("2024", filename);
            string raw = InputHelper.ParseFile(fpath);
            char[][] baseMatrix = ContainerHelper.ParseMatrixFromString<char>(raw, "");
            AntennaMap = ContainerHelper.NormalizeToXY(baseMatrix);
            FindAntennas();
            GetAntennaPairs();
        }

        public int Solve_Part01()
        {
            FindAntinodes();
            return Antinodes.Count;
        }

        public int Solve_Part02()
        {
            FindAntinodes(false);
            return Antinodes.Count;
        }

        private void FindAntennas()
        {
            //find each position of matching pair of antennas (ie the same letter or digit)
            //use the regex pattern to find the antennas
            for (int x = 0; x < AntennaMap.Length; x++)
            {
                for (int y = 0; y < AntennaMap[x].Length; y++)
                {
                    if (System.Text.RegularExpressions.Regex.IsMatch(AntennaMap[x][y].ToString(), antennaMatchPattern))
                    {
                        //add antenna position
                        AntennaPositions.Add((AntennaMap[x][y], (x, y)));
                    }
                }
            }
        }

        private void GetAntennaPairs()
        {
            //find each pair of antennas that are the same
            foreach (var antenna in AntennaPositions)
            {
                foreach (var otherAntenna in AntennaPositions)
                {
                    if (antenna.AntennaType == otherAntenna.AntennaType && antenna != otherAntenna)
                    {
                        //make sure the reverse pair isn't already in the set
                        if (!AntennaPairs.Contains((antenna.AntennaType, otherAntenna.AntennaPosition, antenna.AntennaPosition)))
                        {
                            AntennaPairs.Add((antenna.AntennaType, antenna.AntennaPosition, otherAntenna.AntennaPosition));
                        }
                    }
                }
            }
        }

        private void FindAntinodes(bool distanceCheck = true)
        {
            foreach (var pair in AntennaPairs)
            {
                (int X, int Y) antenna1 = pair.Antenna1;
                (int X, int Y) antenna2 = pair.Antenna2;

                if(!distanceCheck)
                {
                    //also add each antenna to the antinode set for part 2 (no distance criteria)
                    Antinodes.Add(antenna1);
                    Antinodes.Add(antenna2);
                }

                for (int x = 0; x < AntennaMap.Length; x++)
                {
                    for (int y = 0; y < AntennaMap[x].Length; y++)
                    {
                        // Skip if the point is one of the antennas
                        if ((x, y) == antenna1 || (x, y) == antenna2)
                            continue;

                        // Check if the point is collinear with the two antennas
                        if (IsCollinear(antenna1, antenna2, (x, y)))
                        {
                            if (distanceCheck)
                            {
                                // Check if the distance criterion is met when enabled
                                double distance1 = GetDistance((x, y), antenna1);
                                double distance2 = GetDistance((x, y), antenna2);

                                if (Math.Abs(distance1 - 2 * distance2)  == 0 || Math.Abs(2 * distance1 - distance2) == 0)
                                {
                                    // Add the point as an antinode
                                    Antinodes.Add((x, y));
                                }
                            }
                            else
                            {
                                // Add the point as an antinode
                                Antinodes.Add((x, y));
                            }
                        }
                    }
                }
            }
        }

        private bool IsCollinear((int X, int Y) p1, (int X, int Y) p2, (int X, int Y) p3)
        {
            return (p2.Y - p1.Y) * (p3.X - p2.X) == (p3.Y - p2.Y) * (p2.X - p1.X);
        }

        private double GetDistance((int X, int Y) p1, (int X, int Y) p2)
        {
            return Math.Sqrt(Math.Pow(p2.X - p1.X, 2) + Math.Pow(p2.Y - p1.Y, 2));
        }

    }
}
