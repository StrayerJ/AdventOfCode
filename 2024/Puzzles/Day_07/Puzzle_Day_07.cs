using Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Year2024
{
    public class Puzzle_Day_07
    {
        private List<(long Test, List<long> Values)> Equations = new List<(long, List<long>)>();

        public Puzzle_Day_07(string filename)
        {
            string fpath = InputHelper.GetInputFilePath("2024", filename);
            string text = InputHelper.ParseFile(fpath);
            ParseInput(text);
        }

        public long Solve_Part01()
        {
            long totalResult = 0;
            List<char> availableOperators = new List<char> { '+', '*' };
            foreach ((long key, List<long> values) in Equations)
            {
                if(ValidEquation(key, values, availableOperators))
                    totalResult += key;
            }

            return totalResult;
        }

        public long Solve_Part02()
        {
            long totalResult = 0;
            List<char> availableOperators = new List<char> { '+', '*', '|' };
            foreach ((long key, List<long> values) in Equations)
            {
                if (ValidEquation(key, values, availableOperators))
                    totalResult += key;
            }

            return totalResult;
        }

        private void ParseInput(string text)
        {
            //ex =  3267: 81 40 27
            var lines = text.Split(new[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string line in lines)
            {
                //get the first part before the ':' and the second part after the ':'
                string[] parts = line.Split(new[] { ':' }, StringSplitOptions.RemoveEmptyEntries);
                long key = long.Parse(parts[0]);
                List<long> values = parts[1].Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(long.Parse).ToList();
                Equations.Add((key, values));
            }

        }

        private bool ValidEquation(long key, List<long> values, List<char> availableOperators)
        {
            long numOperators = values.Count - 1;
            var operatorCombinations = GenerateOperatorCombinations(availableOperators, numOperators);

            foreach (var operators in operatorCombinations)
            {
                long result = EvaluateEquation(values, operators);
                if (result == key)
                    return true; // Valid combination found
            }

            return false;
        }

        private IEnumerable<List<char>> GenerateOperatorCombinations(List<char> operators, long length)
        {
            if (length == 0) yield return new List<char>();
            else
            {
                foreach (char op in operators)
                {
                    foreach (var combination in GenerateOperatorCombinations(operators, length - 1))
                    {
                        var newCombination = new List<char> { op };
                        newCombination.AddRange(combination);
                        yield return newCombination;
                    }
                }
            }
        }

        private long EvaluateEquation(List<long> values, List<char> operators)
        {
            long result = values[0];
            for (int i = 0; i < operators.Count; i++)
            {
                switch (operators[i])
                {
                    case '+':
                        result += values[i + 1];
                        break;
                    case '*':
                        result *= values[i + 1];
                        break;
                    case '|':
                        // Concatenate numbers as digits
                        result = long.Parse($"{result}{values[i + 1]}");
                        break;
                    default:
                        throw new InvalidOperationException($"Unsupported operator: {operators[i]}");
                }
            }
            return result;
        }

    }
}
