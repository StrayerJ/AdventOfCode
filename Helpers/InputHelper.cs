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

        public static string ParseFile(string file)
        {
            return File.ReadAllText(file);
        }

        public static List<List<T>> ParseLists_ByColumn_FromFile<T>(string file)
        {
            // Read the entire file content
            string fileContent = File.ReadAllText(file);

            // Pass the content to the FromString function
            return ContainerHelper.ParseLists_ByColumn_FromString<T>(fileContent);
        }

        public static List<List<T>> ParseLists_ByRow_FromFile<T>(string file)
        {
            // Read the entire file content
            string fileContent = File.ReadAllText(file);

            // Pass the content to the FromString function
            return ContainerHelper.ParseLists_ByColumn_FromString<T>(fileContent);
        }

        public static T[][] ParseMatrixFromFile<T>(string file, string delimiter = " ")
        {
            // Read the entire file content
            string fileContent = File.ReadAllText(file);

            return ContainerHelper.ParseMatrixFromString<T>(fileContent, delimiter);

        }

        public static T[][] ParseMatrixFromFile_Normalized<T>(string file, string delimiter = " ")
        {
            // Read the entire file content
            string fileContent = File.ReadAllText(file);

            return ContainerHelper.NormalizeToXY( ContainerHelper.ParseMatrixFromString<T>(fileContent, delimiter) );

        }

    }
}
