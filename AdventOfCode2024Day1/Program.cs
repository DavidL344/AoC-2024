// https://adventofcode.com/2024/day/1
// Author: David Langr

var file = File.ReadLines("Day1.txt");
var fileArray = file as string[] ?? file.ToArray();

var array = new int[fileArray.Length, 2];
var sortedDiff = new int[fileArray.Length];

for (var i = 0; i < fileArray.Length; i++)
{
    var splitLine = fileArray[i].Split("   ");
    array[i, 0] = int.Parse(splitLine[0]);
    array[i, 1] = int.Parse(splitLine[1]);
}

Array.Sort(array);

for (var i = 0; i < fileArray.Length; i++)
{
    sortedDiff[i] = Math.Abs(array[i, 0] - array[i, 1]);
}

// var cumulativeDistance = sortedDiff.Sum();
var cumulativeDistance = 0;
foreach (var distance in sortedDiff)
{
    cumulativeDistance += distance;
}

Console.WriteLine($"The total distance between the lists is {cumulativeDistance}");
