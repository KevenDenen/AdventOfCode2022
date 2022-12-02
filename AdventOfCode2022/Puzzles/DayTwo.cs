using Helpers;
using System.Linq.Expressions;

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

    internal static object PartTwo()
    {
        var input = FileReader.GetWholeFileAsArrayOfLines(fileName);
        var scores = input.Select(x => ScorePartTwo(x));
        return scores.Sum();
    }

    private static int ScorePartTwo(string advice)
    {
        int score = 0;
        var opponentPlay = advice.Split(' ')[0];
        var winLoseDraw = advice.Split(" ")[1];

        switch (opponentPlay) 
        {
            case "A": // Rock
                switch (winLoseDraw)
                {
                    case "X": // Lose
                        score += 3; // For playing scissors
                        break;
                    case "Y": // Draw
                        score += 3; // For the draw
                        score += 1; // For playing rock
                        break;
                    case "Z":
                        score += 6; // For the win
                        score += 2; // For playing paper
                        break;
                    default:
                        break;
                }
                break;
            case "B": // Paper
                switch (winLoseDraw)
                {
                    case "X": // Lose
                        score += 1; // For playing rock
                        break;
                    case "Y": // Draw
                        score += 3; // For the draw
                        score += 2; // For playing paper
                        break;
                    case "Z":
                        score += 6; // For the win
                        score += 3; // For playing scissors
                        break;
                    default:
                        break;
                }
                break;
            case "C": // Scissors
                switch (winLoseDraw)
                {
                    case "X": // Lose
                        score += 2; // For playing paper
                        break;
                    case "Y": // Draw
                        score += 3; // For the draw
                        score += 3; // For playing scissors
                        break;
                    case "Z":
                        score += 6; // For the win
                        score += 1; // For playing rock
                        break;
                    default:
                        break;
                }
                break;
        }
        return score;
    }

    private static int ScorePartOne(string advice)
    {
        int score = 0;
        var opponentPlay = advice.Split(' ')[0];
        var myPlay = advice.Split(" ")[1];

        switch (myPlay)
        {
            case "X":
                score += 1;
                break;
            case "Y":
                score += 2;
                break;
            case "Z":
                score += 3;
                break;
            default:
                break;
        }

        switch (opponentPlay) 
        {
            case "A": // Rock
                switch (myPlay)
                {
                    case "X": // Rock
                        score += 3;
                        break;
                    case "Y": // Paper
                        score += 6;
                        break;
                    default: // Scissors
                        break;
                }
                break;
            case "B": // Paper
                switch (myPlay)
                {
                    case "Y":
                        score += 3; // Paper
                        break;
                    case "Z": // Scissors
                        score += 6;
                        break;
                    default: // Rock
                        break;
                }
                break;
            case "C": // Scissors
                switch (myPlay)
                {
                    case "X": // Rock
                        score += 6;
                        break;
                    case "Z": // Scissors
                        score += 3;
                        break;
                    default: // Paper
                        break;
                }
                break;
        }
        return score;
    }
}