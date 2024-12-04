using Helpers;

namespace AdventOfCode.Year2024
{
    public class Puzzle_Day_01
    {
        private List<int> InputA;
        private List<int> InputB;

        public Puzzle_Day_01(string inputFilePath)
        {
            List<List<int>> lists = InputHelper.ParseListByColumn_FromFile<int>(inputFilePath);

            InputA = lists[0];
            InputB = lists[1];
        }

        public Puzzle_Day_01(List<int> inputA, List<int> inputB)
        {
            InputA = inputA;
            InputB = inputB;
        }

        public int Solve_Part01()
        {
            SortLists();

            int result = 0;

            if (InputA.Count != InputB.Count)
            {
                throw new Exception("Input lists are not the same size");
            }

            for (int i = 0; i < InputA.Count; i++)
            {
                result += Math.Abs(InputA[i] - InputB[i]);
            }

            return result;
        }

        public int Solve_Part02()
        {
            int result = 0;

            foreach (int a in InputA)
            {
                //get count of a in InputB
                int cnt = InputB.Count(x => x == a);
                result += a * cnt;
            }

            return result;
        }

        private void SortLists()
        {
            InputA.Sort();
            InputB.Sort();
        }
    }
}
