using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helpers
{
    public static class ContainerHelper
    {

        public static List<List<T>> ParseLists_ByColumn_FromString<T>(string inputString)
        {

            // Split the string into lines
            string[] lines = inputString.Split(new[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);


            int numCols = lines[0].Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries).Length;

            //init the lists
            List<List<T>> result = new List<List<T>>();
            for (int i = 0; i < numCols; i++)
            {
                result.Add(new List<T>());
            }

            // Iterate over each line
            foreach (string line in lines)
            {
                // Split the line into parts by whitespace
                string[] parts = line.Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);

                //add each part to its respective list
                for (int i = 0; i < numCols; i++)
                {
                    result[i].Add((T)Convert.ChangeType(parts[i], typeof(T)));
                }

            }

            return result;
        }

        public static List<List<T>> ParseLists_ByRow_FromString<T>(string inputString)
        {
            // Split the string into lines
            string[] lines = inputString.Split(new[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);

            //init the lists
            List<List<T>> result = new List<List<T>>();

            // Iterate over each line
            foreach (string line in lines)
            {
                // Split the line into parts by whitespace
                string[] parts = line.Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);

                //init the list for this row
                List<T> row = new List<T>();

                //add each part to the row
                foreach (string part in parts)
                {
                    row.Add((T)Convert.ChangeType(part, typeof(T)));
                }

                //add the row to the result
                result.Add(row);
            }

            return result;
        }

        public static T[][] ParseMatrixFromString<T>(string input, string delimiter = " ")
        {
            // Split the input string into lines
            var lines = input.Split(new[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
            var matrix = new T[lines.Length][];

            for (int i = 0; i < lines.Length; i++)
            {
                string[] values;

                if (delimiter == "")
                {
                    // Split every character into a column
                    values = lines[i].Select(c => c.ToString()).ToArray();
                }
                else
                {
                    // Split by the specified delimiter
                    values = lines[i].Split(new[] { delimiter }, StringSplitOptions.RemoveEmptyEntries);
                }

                matrix[i] = new T[values.Length];
                for (int j = 0; j < values.Length; j++)
                {
                    matrix[i][j] = (T)Convert.ChangeType(values[j], typeof(T));
                }
            }

            return matrix;
        }

        public static T[][] NormalizeToXY<T>(T[][] matrix)
        {
            int numRows = matrix.Length; // Total rows in the input (north to south)
            int numCols = matrix[0].Length; // Total columns in the input (west to east)

            // Create a new matrix where [X][Y] matches the map coordinate system
            var normalizedMap = new T[numCols][]; // Transpose dimensions to [X][Y]

            for (int x = 0; x < numCols; x++)
            {
                normalizedMap[x] = new T[numRows];
                for (int y = 0; y < numRows; y++)
                {
                    // Flip the Y-axis and transpose X and Y
                    normalizedMap[x][y] = matrix[numRows - 1 - y][x];
                }
            }

            return normalizedMap;
        }

    }
}
