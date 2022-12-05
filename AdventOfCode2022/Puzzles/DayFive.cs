using Helpers;

namespace Puzzles;

internal static class DayFive
{
    private static string fileName = "DayFive.txt";
    internal static string PartOne()
    {
        var input = FileReader.GetWholeFileAsArrayOfLines(fileName);

        var index = Array.FindIndex(input, x => x.StartsWith(" 1"));
        var instructions = input.Skip(index + 2).ToArray().Select(x => x.Split(' ')).Select(x => (number: int.Parse(x[1]), from: int.Parse(x[3]), to: int.Parse(x[5])));
        List<Stack<char>> stackList = CreateStacks(input, index);

        foreach (var instruction in instructions)
        {
            for (int i = 0; i < instruction.number; i++)
            {
                var crate = stackList[instruction.from - 1].Pop();
                stackList[instruction.to -1].Push(crate);
            }
        }

        var topCrates = string.Empty;
        foreach (var stack in stackList)
        {
            topCrates += stack.Pop();
        }
        return topCrates;
    }

    internal static string PartTwo()
    {
        return string.Empty;
    }

    private static List<Stack<char>> CreateStacks(string[] input, int index)
    {
        var stacks = input.Take(index).ToArray();
        var columns = input[index].Split(" ", StringSplitOptions.RemoveEmptyEntries);

        // Create the stacks
        var stackList = new List<Stack<char>>();
        foreach (var _ in columns)
        {
            stackList.Add(new Stack<char>());
        }

        // Fill the stacks
        foreach (var row in stacks.Reverse()) // For each row, starting from the bottom
        {
            for (int i = 0; i < stackList.Count; i++)
            {
                var crateLetter = row[1 + (i * 4)]; // Get the 1, 5, 9, etc. characters
                if (crateLetter != ' ')
                    stackList[i].Push(crateLetter);
            }
        }

        return stackList;
    }

}
