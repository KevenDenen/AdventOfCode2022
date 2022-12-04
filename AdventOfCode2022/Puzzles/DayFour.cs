using Helpers;

namespace Puzzles;

internal static class DayFour
{
    private static string fileName = "DayFour.txt";
    internal static int PartOne()
    {
        var input = FileReader.GetWholeFileAsArrayOfLines(fileName);
        var pairs = SplitInput(input);
        var count = 0;
        foreach (var pair in pairs)
        {
            if ((pair.First().First() <= pair.Last().First() && pair.First().Last() >= pair.Last().Last()) ||
                 pair.First().First() >= pair.Last().First() && pair.First().Last() <= pair.Last().Last())
            {
                count++;
            }
        }
        return count;
    }

    private static IEnumerable<IEnumerable<IEnumerable<int>>> SplitInput(string[] input)
    {
        return input.Select(x => x.Split(',').Select(x => x.Split('-').Select(int.Parse)));
    }

    internal static int PartTwo()
    {
        return 0;
    }
}
