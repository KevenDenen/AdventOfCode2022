using Helpers;
using System.Linq.Expressions;
using System.Xml.Schema;

namespace Puzzles;

internal static class DayTwo
{
    private static string fileName = "DayTwo.txt";
    internal static int PartOne()
    {
        var input = FileReader.GetWholeFileAsArrayOfLines(fileName);
        var scores = input.Select(x => ScorePartOne(x));
        return scores.Sum();
    }

    internal static int PartTwo()
    {
        var input = FileReader.GetWholeFileAsArrayOfLines(fileName);
        var scores = input.Select(x => ScorePartTwo(x));
        return scores.Sum();
    }

    private static int ScorePartTwo(string advice)
    {
        var scores = new Dictionary<string, int>()
        {
            { "A X", 3 }, // Rock Loss, 3 for scissors, 0 for loss
            { "A Y", 4 }, // Rock Draw, 1 for rock, 3 for draw
            { "A Z", 8 }, // Rock Win, 2 for paper, 6 for win
            { "B X", 1 }, // Paper Loss, 1 for rock, 0 for loss
            { "B Y", 5 }, // Paper Draw, 2 for paper, 3 for draw
            { "B Z", 9 }, // Paper Win, 3 for scissors, 6 for win
            { "C X", 2 }, // Scissors Loss, 2 for paper, 0 for loss
            { "C Y", 6 }, // Scissors Draw, 3 for scissors, 3 for draw
            { "C Z", 7 }, // Scissors Win, 1 for rock, 6 for win
        };
        return scores[advice];
    }

    private static int ScorePartOne(string advice)
    {
        var scores = new Dictionary<string, int>()
        {
            { "A X", 4 }, // Rock Rock, 1 for rock, 3 for draw
            { "A Y", 8 }, // Rock Paper, 2 for paper, 6 for win
            { "A Z", 3 }, // Rock Scissors, 3 for scissors, 0 for loss
            { "B X", 1 }, // Paper Rock, 1 for rock, 0 for loss
            { "B Y", 5 }, // Paper Paper, 2 for paper, 3 for draw
            { "B Z", 9 }, // Paper Scissors, 3 for scissors, 6 for win
            { "C X", 7 }, // Scissors Rock, 1 for rock, 6 for win
            { "C Y", 2 }, // Scissors Paper, 2 for paper, 0 for loss
            { "C Z", 6 }, // Scissors Scissors, 3 for scissors, 3 for draw
        };
        return scores[advice];
    }
}
