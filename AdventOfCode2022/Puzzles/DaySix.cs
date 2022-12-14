using Helpers;

namespace Puzzles;

internal static class DaySix
{
    private static string fileName = "DaySix.txt";
    internal static int PartOne()
    {
        var input = FileReader.GetWholeFileAsString(fileName);
        var startOfPacket = 0;
        for (int i = 4; i < input.Length && startOfPacket == 0; i++)
        {
            var slider = new HashSet<char>(input.Skip(i-4).Take(4));
            if (slider.Count <= 3)
                continue;
            startOfPacket = i;
        }
        return startOfPacket;
    }

    internal static int PartTwo()
    {
        var input = FileReader.GetWholeFileAsString(fileName);
        var startOfMessage = 0;
        for (int i = 4; i < input.Length && startOfMessage == 0; i++)
        {
            var slider = new HashSet<char>(input.Skip(i - 14).Take(14));
            if (slider.Count <= 13)
                continue;
            startOfMessage = i;
        }
        return startOfMessage;
    }
}