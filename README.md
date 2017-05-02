# FakeConsole
FakeConsole - is a simple helper class to help you better test dotnet console apps


# Story of FakeConsole
While playing with online problem solving websites, like [HackRank](https://www.hackerrank.com/). developers need from time to time to test the solution on their PCs to debug any unexpected behaviour.

Most probably developer will do (run the program > manually write inputs to console > check results) many times.

The most time-wasting step is to manually insert inputs to console, **FakeConsole** core purpose is to help in this step. and it also comes with some extra help like validating the final outputs of all Console.WriteLine called during program execution.


# How to use
1. You have to download the [FakeConsole file](https://raw.githubusercontent.com/AhmedMozaly/FakeConsole/master/FakeConsole.cs) and add it to your solution.
2. You need to add `using Console = FakeConsole;` to your program namespaces. 
3. You need to set `FakeConsole.ReadLines` field with all of your lines, separated by line breaks.


# Example
```
using System;
using Console = FakeConsole;

class Solution
{
    
    static void Main(String[] args)
    {
        Console.ReadLines = @"first line
second line
third line";

        //all next lines will be served from FakeConsole, no popups will be needed to ask user for anything
        var line1 = Console.ReadLine();
        var line2 = Console.ReadLine();
        var line3 = Console.ReadLine();
    }
}
```
