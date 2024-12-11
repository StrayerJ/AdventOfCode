using Helpers;
using System.Linq;


public class Puzzle_Day_11
{
    Dictionary<string, List<string>> RuleCache = new Dictionary<string, List<string>>();
    List<string> RawStones;

    public Puzzle_Day_11(string filename)
    {
        RawStones = InputHelper.ParseLineFile<string>(InputHelper.GetInputFilePath("2024", filename));
    }

    public long Solve_Part01()
    {
        Dictionary<string, long> finalStoneFrequencies = RunRulesAmountOfTimesOptimized(RawStones, 25);
        return finalStoneFrequencies.Values.Sum();
    }

    public long Solve_Part02()
    {
        Dictionary<string, long> finalStoneFrequencies = RunRulesAmountOfTimesOptimized(RawStones, 75);
        return finalStoneFrequencies.Values.Sum();
    }

    private Dictionary<string, long> RunRulesAmountOfTimesOptimized(List<string> stones, int times)
    {
        // Initialize frequency dictionary
        Dictionary<string, long> stoneFrequencies = stones
            .GroupBy(stone => stone)
            .ToDictionary(group => group.Key, group => (long)group.Count());

        for (int i = 0; i < times; i++)
        {
            stoneFrequencies = RunRulesOnAllStonesOptimized(stoneFrequencies);
        }

        return stoneFrequencies;
    }

    private Dictionary<string, long> RunRulesOnAllStonesOptimized(Dictionary<string, long> stoneFrequencies)
    {
        var newFrequencies = new Dictionary<string, long>();

        foreach (var stoneEntry in stoneFrequencies)
        {
            string stone = stoneEntry.Key;
            long count = stoneEntry.Value;

            // Get results for the current stone
            List<string> results = RunRuleOnOneStoneCached(stone);

            // Update frequencies for the resulting stones
            foreach (string result in results)
            {
                if (!newFrequencies.ContainsKey(result))
                    newFrequencies[result] = 0;

                newFrequencies[result] += count; // Multiply by the current frequency
            }
        }

        return newFrequencies;
    }

    private List<string> RunRuleOnOneStoneCached(string stone)
    {
        if (RuleCache.TryGetValue(stone, out var cachedResult))
        {
            return cachedResult;
        }

        // Compute the result if not cached
        List<string> result = RunRuleOnOneStone(stone);
        RuleCache[stone] = result;
        return result;
    }

    private List<string> RunRuleOnOneStone(string stone)
    {
        List<string> returnStones = new List<string>();

        long val = long.Parse(stone);
        bool isEvenDigits = stone.Length % 2 == 0;

        if (val == 0)
        {
            returnStones.Add("1");
        }
        else if (isEvenDigits)
        {
            // Split string in half
            string firstHalf = stone.Substring(0, stone.Length / 2);
            string secondHalf = stone.Substring(stone.Length / 2);

            // Remove leading zeros if length > 1 && string is m
            firstHalf = long.Parse(firstHalf).ToString();
            secondHalf = long.Parse(secondHalf).ToString();

            returnStones.Add(firstHalf);
            returnStones.Add(secondHalf);
        }
        else
        {
            long newVal = val * 2024;
            returnStones.Add(newVal.ToString());
        }

        return returnStones;
    }
}
