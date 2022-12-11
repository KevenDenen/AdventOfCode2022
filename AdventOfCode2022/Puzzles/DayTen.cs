using Helpers;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System;
using System.Linq.Expressions;
using System.Xml.Schema;

namespace Puzzles;

internal static class DayTen
{
    private static readonly string fileName = "DayTen.txt";
    private static int cycle = 1;
    private static long xRegister = 1L;
    private static long total = 0L;
    private static readonly HashSet<int> cyclesToCheck = new() { 20, 60, 100, 140, 180, 220 };

    internal static long PartOne()
    {
        var input = FileReader.GetWholeFileAsArrayOfLines(fileName);
        
        foreach (var line in input)
        {
            switch (line[..4])
            {
                case "noop":
                    Cycle();
                    break;
                case "addx":
                    Cycle();
                    Cycle();
                    xRegister += int.Parse(line[5..]);
                    break;
                default:
                    break;
            }
        }
        return total;
    }

    internal static void PartTwo()
    {
        var input = FileReader.GetWholeFileAsArrayOfLines(fileName);
        cycle = 0;
        xRegister = 1;
        foreach (var line in input)
        {
            switch (line[..4])
            {
                case "noop":
                    CycleAndDraw();
                    break;
                case "addx":
                    CycleAndDraw();
                    CycleAndDraw();
                    xRegister += int.Parse(line[5..]);
                    break;
                default:
                    break;
            }
        }
    }

    internal static void Cycle()
    {
        if (cyclesToCheck.Contains(cycle))
            total += cycle * xRegister;
        cycle++;
    }
    
    internal static void CycleAndDraw()
    {
        var pixel = cycle % 40;
        if (pixel == 0)
        {
            Console.WriteLine();
        }
        if (pixel == xRegister - 1 || pixel == xRegister || pixel == xRegister + 1)
        {
            Console.Write('#');
        }
        else
        {
            Console.Write('.');
        }
        cycle++;
    }
}
