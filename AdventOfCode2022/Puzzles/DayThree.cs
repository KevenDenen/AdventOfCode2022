using Helpers;

internal class DayThree
{
    private static string fileName = "DayThree.txt";
    internal static int PartOne()
    {
        var file = FileReader.GetWholeFileAsArrayOfLines(fileName);
        var rucksacks = file.Select(x => x.Chunk(x.Length / 2)).ToList();
        var matches = rucksacks.Select(x => x.First().Intersect(x.Last()).Single());
        var priorities = matches.Select(x => CharacterToPriority(x));
        return priorities.Sum();
    }

    internal static int PartTwo()
    {
        var file = FileReader.GetWholeFileAsArrayOfLines(fileName);
        var groups = file.Chunk(3);
        var matches = groups.Select(x => x[0].Intersect(x[1]).Intersect(x[2]).Single());
        var priorities = matches.Select(x => CharacterToPriority(x)).OrderByDescending(x => x);
        return priorities.Sum();
    }

    private static int CharacterToPriority(char character) 
    {
        return char.IsLower(character) ? character - 96 : character - 38;
    }
}