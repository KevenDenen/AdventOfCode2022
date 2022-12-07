using Helpers;
using System.Runtime.CompilerServices;

namespace Puzzles;

internal static class DaySeven
{
    private static string fileName = "DaySeven.txt";
    internal static long PartOne()
    {
        var input = FileReader.GetWholeFileAsArrayOfLines(fileName);
        Directory? workingDirectory = ParseInput(input);

        long total = 0;
        var dfsStack = new Stack<Directory>();
        dfsStack.Push(workingDirectory);

        while (dfsStack.Count > 0)
        {
            var current = dfsStack.Pop();
            foreach (var child in current.Children)
            {
                dfsStack.Push(child.Value);
            }
            if (current.Size <= 100_000)
            {
                total += current.Size;
            }
        }

        return total;
    }

    internal static long PartTwo()
    {
        var input = FileReader.GetWholeFileAsArrayOfLines(fileName);
        return 0;
    }

    private static Directory ParseInput(string[] input)
    {
        var workingDirectory = new Directory("/", null);

        foreach (var line in input)
        {
            if (line.Equals("$ cd .."))
            {
                workingDirectory = workingDirectory.Parent;
            }
            else if (line == "$ cd /")
            {
                continue;
            }
            else if (line.StartsWith("$ cd "))
            {
                workingDirectory = workingDirectory.GetChild(line[5..]);
            }
            else if (line.StartsWith("dir "))
            {
                workingDirectory.AddChild(line[4..]);
            }
            else if (line.StartsWith("$ ls"))
            {
                continue;
            }
            else
            {
                workingDirectory.AddSize(long.Parse(line.Split(' ')[0]));
            }
        }

        while (workingDirectory.Parent != null)
        {
            workingDirectory = workingDirectory.Parent;
        }

        return workingDirectory;
    }
}

internal class Directory
{
    public Directory(string name, Directory? parent)
    {
        Name = name;
        Parent = parent;
        Children = new();
    }

    public string Name { get; private set; }
    public long Size { get; private set; }
    public Directory? Parent { get; private set; }
    public Dictionary<string, Directory> Children { get; private set; }

    public void AddChild(string name)
    {
        Children.Add(name, new Directory(name, this));
    }
    public void AddSize(long size)
    {
        Size += size;
        if (Parent != null)
        {
            Parent.AddSize(size);
        }
    }
    public Directory GetChild(string name)
    {
        return Children[name];
    }
}
