using Helpers;

namespace Puzzles;
internal class DayOne
{
    public static int PartOne()
    {
        var file = FileReader.GetWholeFileAsString("DayOne.txt");
        var elfCalories = GetElfCalories(file);
        return elfCalories.Max();
    }
    public static int PartTwo()
    {
        var file = FileReader.GetWholeFileAsString("DayOne.txt");
        var elfCalories = GetElfCalories(file);
        return elfCalories.OrderByDescending(x => x).Take(3).Sum();
    }

    private static IEnumerable<int> GetElfCalories(string input)
    {
        var elves = input.Split("\r\n\r\n");
        return elves.Select(x => x.Split("\r\n").Select(int.Parse).Sum());
    }
}