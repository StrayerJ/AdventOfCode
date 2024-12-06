using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helpers
{
    public static class ContainerHelper
    {

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

        public static T[][] NormalizeToXYMap<T>(T[][] matrix)
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
