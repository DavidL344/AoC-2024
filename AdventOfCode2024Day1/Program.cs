// https://adventofcode.com/2024/day/1
// Author: David Langr

var file = File.ReadLines("Day1.txt");
var fileArray = file as string[] ?? file.ToArray();

var arrays = new List<int[]>();
arrays.Add(new int[fileArray.Length]);
arrays.Add(new int[fileArray.Length]);

var sortedDiff = new int[fileArray.Length];

for (var i = 0; i < fileArray.Length; i++)
{
    var splitLine = fileArray[i].Split("   ");
    arrays[0][i] = int.Parse(splitLine[0]);
    arrays[1][i] = int.Parse(splitLine[1]);
}

Array.Sort(arrays[0]);
Array.Sort(arrays[1]);

for (var i = 0; i < fileArray.Length; i++)
{
    sortedDiff[i] = Math.Abs(arrays[0][i] - arrays[1][i]);
}

// var cumulativeDistance = sortedDiff.Sum();
var cumulativeDistance = 0;
foreach (var distance in sortedDiff)
{
    cumulativeDistance += distance;
}

Console.WriteLine($"The total distance between the lists is {cumulativeDistance}");
