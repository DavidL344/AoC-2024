// https://adventofcode.com/2024/day/4
// Author: David Langr

using System.Text.RegularExpressions;

var file = File.ReadAllLines("input.txt");

const string searchedString = "XMAS";
var searchedStringReversed = new string(searchedString.Reverse().ToArray());

var regex = new Regex($"{searchedString[0]}");
//var searchedSubstring = searchedString.Substring(1);

var occurrences = 0;
for (var lineIndex = 0; lineIndex < file.Length; lineIndex++)
{
    // If there's an X
    foreach (Match match in regex.Matches(file[lineIndex]))
    {
        // Search to the right --> MXMXA *XMAS* X
        var conditionLeftToRight = match.Index < (file[lineIndex].Length - 1) - (searchedString.Length - 1);
        if (conditionLeftToRight)
        {
            if (file[lineIndex].Substring(match.Index, searchedString.Length) == searchedString)
            {
                Console.WriteLine($"Found {searchedString} (left to right) at line {lineIndex + 1}, character {match.Index + 1}.");
                occurrences++;
            }
        }
        
        // Search to the left --> M *SAMX* MSMSA
        var conditionRightToLeft = match.Index + 1 > searchedString.Length - 1;
        if (conditionRightToLeft)
        {
            var substring = file[lineIndex].Substring(match.Index - (searchedString.Length - 1), searchedString.Length);
            
            if (substring == searchedStringReversed)
            {
                Console.WriteLine($"Found {searchedString} (right to left) at line {lineIndex + 1}, character {match.Index /*- (searchedStringReversed.Length - 1)*/ + 1}.");
                occurrences++;
            }
        }
        
        // Search top-to-bottom
        var conditionTopToBottom = lineIndex + searchedString.Length < file.Length - 1;
        if (conditionTopToBottom)
        {
            var isValid = true;
            for (var character = 1; character < searchedString.Length; character++)
            {
                var row = lineIndex + character;
                if (file[row][match.Index] != searchedString[character]) isValid = false;
            }

            if (isValid)
            {
                Console.WriteLine($"Found {searchedString} (top to bottom) at line {lineIndex + 1}, character {match.Index + 1}.");
                occurrences++;
            }
        }
        
        // Search bottom-to-top
        var conditionBottomToTop = lineIndex > searchedString.Length - 1;
        if (conditionBottomToTop)
        {
            var isValid = true;
            for (var character = 1; character < searchedString.Length; character++)
            {
                var rowIndex = lineIndex - character;
                var rowIndexCharacter = file[rowIndex][match.Index];
                if (rowIndexCharacter != searchedString[character]) isValid = false;
            }

            if (isValid)
            {
                Console.WriteLine($"Found {searchedString} (bottom to top) at line {lineIndex + 1}, character {match.Index + 1}.");
                occurrences++;
            }
        }
        
        // Search left-to-bottom diagonally
        var conditionLeftToBottom = conditionLeftToRight && conditionTopToBottom;
        if (conditionLeftToBottom)
        {
            var isValid = true;
            for (var character = 1; character < searchedString.Length; character++)
            {
                var row = lineIndex + character;
                if (file[row][match.Index + character] != searchedString[character]) isValid = false;
            }
            
            if (isValid)
            {
                Console.WriteLine($"Found {searchedString} (left to bottom) at line {lineIndex + 1}, character {match.Index + 1}.");
                occurrences++;
            }
        }
        
        // Search bottom-to-left diagonally
        var conditionBottomToLeft = conditionRightToLeft && conditionBottomToTop;
        if (conditionBottomToLeft)
        {
            var isValid = true;
            for (var character = 1; character < searchedString.Length; character++)
            {
                var row = lineIndex - character;
                if (file[row][match.Index - character] != searchedString[character]) isValid = false;
            }
            
            if (isValid)
            {
                Console.WriteLine($"Found {searchedString} (bottom to left) at line {lineIndex + 1}, character {match.Index + 1}.");
                occurrences++;
            }
        }
        
        // Search right-to-bottom diagonally
        var conditionRightToBottom = conditionRightToLeft && conditionTopToBottom;
        if (conditionRightToBottom)
        {
            var isValid = true;
            for (var character = 1; character < searchedString.Length; character++)
            {
                var row = lineIndex + character;
                if (file[row][match.Index - character] != searchedString[character]) isValid = false;
            }
            
            if (isValid)
            {
                Console.WriteLine($"Found {searchedString} (right to bottom) at line {lineIndex + 1}, character {match.Index + 1}.");
                occurrences++;
            }
        }
        
        // Search bottom-to-right diagonally
        var conditionBottomToRight = conditionLeftToRight && conditionBottomToTop;
        if (conditionBottomToRight)
        {
            var isValid = true;
            for (var character = 1; character < searchedString.Length; character++)
            {
                var row = lineIndex - character;
                if (file[row][match.Index + character] != searchedString[character]) isValid = false;
            }
            
            if (isValid)
            {
                Console.WriteLine($"Found {searchedString} (bottom to right) at line {lineIndex + 1}, character {match.Index + 1}.");
                occurrences++;
            }
        }

        /*
        // If there's an M
        if (searchedString[1] == file[i][match.Index + 1])
        {
            Console.WriteLine($"XM found at line {i + 1}, index {match.Index}.");
        }
        */
    }
}

Console.WriteLine($"\nFound a total of {occurrences} occurrences.");
