// https://adventofcode.com/2024/day/3
// Author: David Langr

using System.Text;
using System.Text.RegularExpressions;

var file = File.ReadAllText("input.txt");
var regex = new Regex(@"mul\([\d]*,[\d]*\)");
const int prependedLength = 4; // "mul("

var sum = 0;
var sumString = new StringBuilder("(");
var firstMatch = true;

foreach (Match match in regex.Matches(file))
{
    // mul( --> 4,6 <-- )
    var rawValues = match.Value.Substring(prependedLength, match.Value.Length - prependedLength - 1);
    var parsedValues = rawValues.Split(',');
    
    var result = int.Parse(parsedValues[0]) * int.Parse(parsedValues[1]);
    sumString.Append($"{(!firstMatch ? " + " : string.Empty)}{parsedValues[0]}*{parsedValues[1]}");
    firstMatch = false;
    
    sum += result;
}
sumString.Append($") = {sum}");

Console.WriteLine($"Adding up all the results of the multiplications results in {sum} --> {sumString}");
