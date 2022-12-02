namespace Helpers;

internal static class FileReader
{
    internal static string GetWholeFileAsString(string fileName)
    {
        return File.ReadAllText($"Input/{fileName}");
    }

    internal static string[] GetWholeFileAsArrayOfLines(string fileName)
    {
        return File.ReadAllLines($"Input/{fileName}");
    }
}