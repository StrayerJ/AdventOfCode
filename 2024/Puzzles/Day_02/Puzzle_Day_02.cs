using Helpers;

namespace AdventOfCode.Year2024
{
    public class Puzzle_Day_02
    {
        private List<List<int>> InputData;

        public Puzzle_Day_02(string filename)
        {
            InputData = InputHelper.ParseLists_ByRow_FromFile<int>(filename);
        }

        public Puzzle_Day_02(List<List<int>> data)
        {
            InputData = data;
        }

        public int Solve_Part01()
        {
            int safeListCount = 0;
            foreach (List<int> list in InputData)
            {
                if (CheckList(list))
                    safeListCount++;
            }
            return safeListCount;
        }

        public int Solve_Part02()
        {
            int safeListCount = 0;
            foreach (List<int> list in InputData)
            {
                if (CheckList(list, true))
                    safeListCount++;
            }
            return safeListCount;
        }

        private bool CheckList(List<int> list, bool canRemoveOneItem = false)
        {
            // Edge cases: Empty or single-element lists are always safe
            if (list.Count <= 1) return true;

            // First pass: Check if the list is already safe
            if (IsSafe(list)) return true;

            // If allowed, brute force this thing
            if (canRemoveOneItem)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    List<int> modifiedList = new List<int>(list);
                    modifiedList.RemoveAt(i);
                    if (IsSafe(modifiedList)) return true;
                }
            }

            return false;
        }

        private bool IsSafe(List<int> levels)
        {
            bool increasing = levels[1] > levels[0];
            for (int i = 0; i < levels.Count - 1; i++)
            {
                int diff = levels[i + 1] - levels[i];

                // Check difference rules
                if (Math.Abs(diff) < 1 || Math.Abs(diff) > 3)
                    return false;

                // Check direction consistency
                if ((diff > 0 && !increasing) || (diff < 0 && increasing))
                    return false;
            }
            return true;
        }

    }
}
