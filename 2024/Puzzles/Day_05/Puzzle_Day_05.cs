using Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Year2024
{
    public class Puzzle_Day_05
    {
        private string RawData;
        private Dictionary<int, List<int>> Rules;
        private List<List<int>> Sequences;
        private List<List<int>> ValidSequences;
        private List<List<int>> InvalidSequences;

        public Puzzle_Day_05(string filename)
        {
            RawData = InputHelper.ParseFile(filename);
            ValidSequences = new List<List<int>>();
            InvalidSequences = new List<List<int>>();
            LoadData();
            LoadValidSequences();
        }

        public int Solve_Part01()
        {
            int total = 0;
            foreach(List<int> seq in ValidSequences)
            {
                total += FindMiddleNumber(seq);
            }
            return total;
        }

        public int Solve_Part02()
        {
            List<List<int>> CorrectedSequences = new List<List<int>>();
            foreach (List<int> seq in InvalidSequences)
            {
                CorrectedSequences.Add(FixInvalidSequence(seq));
            }

            int total = 0;
            foreach (List<int> seq in CorrectedSequences)
            {
                total += FindMiddleNumber(seq);
            }
            return total;

        }

        private void LoadData()
        {
            // Split the string into lines
            string[] lines = RawData.Split(new[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);

            // Parse the first section into Rules (key -> list of values) until a blank line
            Rules = new Dictionary<int, List<int>>();
            int i = 0;

            // Process the first section (Rules)
            while (i < lines.Length && !string.IsNullOrWhiteSpace(lines[i]) && !lines[i].Contains(','))
            {
                // Split each rule line into key and values
                string[] parts = lines[i].Split(new[] { '|' }, StringSplitOptions.RemoveEmptyEntries);

                // The key is the first part, the values are parsed into a list
                int key = int.Parse(parts[0].Trim());
                int value = int.Parse(parts[1].Trim());

                // Add to the Rules dictionary
                if (!Rules.ContainsKey(key))
                {
                    Rules[key] = new List<int>();
                }
                Rules[key].Add(value);

                i++;
            }

            // Parse the second section into Sequences
            Sequences = new List<List<int>>();
            //i++; // Move past the blank line (or separator)

            while (i < lines.Length)
            {
                // Split the line into integers and add them to a sequence
                List<int> sequence = lines[i]
                    .Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToList();

                // Add the sequence to the list of Sequences
                Sequences.Add(sequence);

                i++;
            }
        }

        private void LoadValidSequences()
        {
            foreach (List<int> seq in Sequences)
            {
                bool validRow = ValidateSequence(seq);
                if (validRow)
                    ValidSequences.Add(seq);
                else
                    InvalidSequences.Add(seq);
            }
        }

        private bool ValidateSequence(List<int> sequence)
        {
            foreach (int key in sequence)
            {
                if (!ValidateRule(key, sequence))
                {
                    return false;
                }
            }
            return true;
        }

        private bool ValidateRule(int key, List<int> sequence)
        {
            if (!Rules.ContainsKey(key))
            {
                return true;//no rules for key
            }

            int indexOfKey = sequence.IndexOf(key);
            List<int> Values = Rules[key];
            foreach (int value in Values)
            {
                int indexOfValue = sequence.IndexOf(value);
                if (indexOfValue != -1 && indexOfValue < indexOfKey)
                    return false;
            }

            return true;
        }

        private int FindMiddleNumber(List<int> sequence)
        {
            //if odd
            if (sequence.Count % 2 != 0)
            {
                int middleIndex = sequence.Count / 2;
                return sequence[middleIndex];
            }
            return 0;
        }

        private List<int> FixInvalidSequence(List<int> sequence)
        {
            // Create a copy of the original sequence to work on
            List<int> fixedSequence = new List<int>(sequence);

            // Keep fixing until the sequence is valid
            while (!ValidateSequence(fixedSequence))
            {
                for (int i = 0; i < fixedSequence.Count; i++)
                {
                    int key = fixedSequence[i];

                    // Skip if the key has no rules
                    if (!Rules.ContainsKey(key))
                        continue;

                    List<int> values = Rules[key];
                    foreach (int value in values)
                    {
                        int indexOfValue = fixedSequence.IndexOf(value);

                        // If the value exists and appears before the key, fix it
                        if (indexOfValue != -1 && indexOfValue < i)
                        {
                            // Remove the value and adjust the index to avoid OOR errors
                            fixedSequence.RemoveAt(indexOfValue);

                            // Adjust i
                            if (indexOfValue < i) i--;

                            // Insert the value after the key
                            fixedSequence.Insert(i + 1, value);
                        }
                    }
                }
            }

            return fixedSequence;
        }
    }
}
