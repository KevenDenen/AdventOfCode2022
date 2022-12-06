using Helpers;

namespace Puzzles;

internal static class DayFive
{
    private static string fileName = "DayFive.txt";
    internal static string PartOne()
    {
        var input = FileReader.GetWholeFileAsArrayOfLines(fileName);

        var indexOfStackNumbers = Array.FindIndex(input, r => r.StartsWith(" 1"));
        var instructions = GetInstructions(input, indexOfStackNumbers);
        var stackList = CreateStacks(input, indexOfStackNumbers);

        foreach (var instruction in instructions)
        {
            for (int i = 0; i < instruction.number; i++)
            {
                var crate = stackList[instruction.from - 1].Pop();
                stackList[instruction.to - 1].Push(crate);
            }
        }

        return GetTopCrates(stackList);
    }

    internal static string PartTwo()
    {
        var input = FileReader.GetWholeFileAsArrayOfLines(fileName);

        var indexOfStackNumbers = Array.FindIndex(input, x => x.StartsWith(" 1"));
        var instructions = GetInstructions(input, indexOfStackNumbers);
        var stackList = CreateStacks(input, indexOfStackNumbers);

        foreach (var instruction in instructions)
        {
            var holding = new Stack<char>();
            for (int i = 0; i < instruction.number; i++)
            {
                var crate = stackList[instruction.from - 1].Pop();
                holding.Push(crate);
            }
            foreach (var crate in holding)
            {
                stackList[instruction.to - 1].Push(crate);
            }
        }

        return GetTopCrates(stackList);
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

    private static string GetTopCrates(List<Stack<char>> stackList)
    {
        var topCrates = string.Empty;
        foreach (var stack in stackList)
        {
            topCrates += stack.Pop();
        }
        return topCrates;
    }

    private static IEnumerable<(int number, int from, int to)> GetInstructions(string[] input, int indexOfStackNumbers)
    {
        return input.Skip(indexOfStackNumbers + 2).ToArray()
                                .Select(r => r.Split(' '))
                                .Select(r => (number: int.Parse(r[1]),
                                              from: int.Parse(r[3]),
                                              to: int.Parse(r[5])));
    }

}
