// https://adventofcode.com/2024/day/2
// Author: David Langr

var reports = File.ReadAllLines("input.txt");
var safeReports = 0;

foreach (var report in reports)
{
    var levels = report.Split(' ', StringSplitOptions.RemoveEmptyEntries);
    var isSafe = true;
    var isIncreasing = true;
    
    for (var i = 0; i < levels.Length - 1; i++)
    {
        var formerValue = int.Parse(levels[i]);
        var latterValue = int.Parse(levels[i + 1]);
        var diff = latterValue - formerValue;
        
        // if the values aren't safe, add the unsafe flag
        if (Math.Abs(diff) is < 1 or > 3) isSafe = false;
        
        // if the values aren't decreasing, check if it's the second entry
        // the second entry decides the trend
        if (isIncreasing && diff < 0)
        {
            if (i == 0 && formerValue > latterValue)
            {
                isIncreasing = false;
                continue;
            }
            isSafe = false;
        }
    }
    
    // Console.WriteLine($"Report {(isSafe ? "is" : "isn't")} safe");
    if (isSafe) safeReports++;
}

Console.WriteLine($"{safeReports} report{(safeReports == 1 ? " is" : "s are")} safe");