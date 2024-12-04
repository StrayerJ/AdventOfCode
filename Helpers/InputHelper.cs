namespace Helpers
{
    public static class InputHelper
    {
        public static string GetInputFilePath(string year, string inputFileName)
        {
            // Start with the current directory
            string currentDirectory = Directory.GetCurrentDirectory();

            // Traverse up the directory tree until the solution root is found
            while (!File.Exists(Path.Combine(currentDirectory, "AdventOfCode.sln")))
            {
                string parentDirectory = Directory.GetParent(currentDirectory)?.FullName;
                if (parentDirectory == null)
                {
                    throw new Exception("Solution root not found. Ensure 'AdventOfCode.sln' is in the project root.");
                }
                currentDirectory = parentDirectory;
            }

            // Construct the full path to the input file
            string inputFilePath = Path.Combine(currentDirectory, "Input", year, inputFileName);

            // Normalize the path
            inputFilePath = Path.GetFullPath(inputFilePath);

            return inputFilePath;
        }

        public static List<List<T>> ParseListByColumn_FromFile<T>(string file)
        {
            // Read the entire file content
            string fileContent = File.ReadAllText(file);

            // Pass the content to the FromString function
            return ParseListByColumn_FromString<T>(fileContent);
        }

        public static List<List<T>> ParseListByColumn_FromString<T>(string inputString)
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

    }
}
