using Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdventOfCode.Year2024
{
    public class Puzzle_Day_03
    {
        private string DataString;


        public Puzzle_Day_03(string data, bool isFilePath = false)
        {
            if (isFilePath)
                DataString = InputHelper.ParseFile(data);
            else
                DataString = data;
        }

        public int Solve_Part01()
        {
            return AddMatches(DataString);
        }

        public int Solve_Part02()
        {
            return AddMatchesEnabler(DataString);
        }

        public int AddMatches(string input)
        {
            int total = 0;
            string regexPattern = @"mul\((\d{1,3}),(\d{1,3})\)";
            MatchCollection matches = Regex.Matches(input, regexPattern, RegexOptions.IgnoreCase);
            foreach(Match match in matches)
            {
                // Extract the two captured groups as integers
                int firstVal = int.Parse(match.Groups[1].Value);
                int secondVal = int.Parse(match.Groups[2].Value);

                total += firstVal * secondVal;
            }
            return total;
        }

        public int AddMatchesEnabler(string input)
        {
            int total = 0;
            string regexPattern = @"mul\((\d{1,3}),(\d{1,3})\)";
            string enablerPattern = @"do\(\)";
            string disablerPattern = @"don\'t\(\)";

            // Track whether mul(...) statements are currently enabled
            bool isEnabled = true;

            // Use a combined regex to capture all statements (do, don't, mul)
            string combinedPattern = $@"{enablerPattern}|{disablerPattern}|{regexPattern}";
            MatchCollection matches = Regex.Matches(input, combinedPattern, RegexOptions.IgnoreCase);

            foreach (Match match in matches)
            {
                if (match.Value.StartsWith("do("))
                {
                    // Enable further mul(...) processing
                    isEnabled = true;
                }
                else if (match.Value.StartsWith("don't("))
                {
                    // Disable further mul(...) processing
                    isEnabled = false;
                }
                else if (match.Groups[1].Success && match.Groups[2].Success) // Check for mul(...) match
                {
                    if (isEnabled)
                    {
                        // Extract the two captured groups as integers
                        int firstVal = int.Parse(match.Groups[1].Value);
                        int secondVal = int.Parse(match.Groups[2].Value);

                        total += firstVal * secondVal;
                    }
                }
            }

            return total;
        }
    }
}
