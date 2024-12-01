// See https://aka.ms/new-console-template for more information
using System.Diagnostics;
using AdventCalendar;

DayRunner dayRunner = new();
bool rerun = true; // Rerun the program
bool advanced = false; // Run the advanced version
string dayResult;  // Result of the day
string dayInput = "";  // Input for the day
int day; // Day to run
Stopwatch stopwatch = new Stopwatch();
TimeSpan timeElapsed;

Console.WriteLine("Starting Advent of Code 2024");
Console.WriteLine("*****************************");
Console.WriteLine("Enter the day you want to run (1-25) add a '+' for advanced version:");
dayInput = Console.ReadLine() ?? string.Empty;
while(rerun)
{
    advanced = dayInput.Contains('+');
    dayInput = dayInput.Replace("+", "");

    while (dayInput == "" || !int.TryParse(dayInput, out day) || day < 1 || day > 25)
    {
        dayInput = Console.ReadLine() ?? string.Empty;

        advanced = dayInput.Contains('+');
        dayInput = dayInput.Replace("+", "");
        if (dayInput == "" || !int.TryParse(dayInput, out day) || day < 1 || day > 25)
        {
            Console.WriteLine("Invalid input. Please enter a number between 1 and 25.");
        }
    }
    stopwatch.Reset();
    stopwatch.Start();

    var res = await dayRunner.RunDay(day, advanced);
    if (res.Success)
    {
        dayResult = res.Answer;
    }
    else
    {
        dayResult = "Day not found";
    }

    stopwatch.Stop();
    timeElapsed = stopwatch.Elapsed;
    Console.WriteLine($"Day {day} result:");
    Console.WriteLine($"{dayResult}");
    Console.WriteLine($"Day {day} completed in {timeElapsed.Minutes}M {timeElapsed.Seconds}S {timeElapsed.Milliseconds}ms");
    Console.WriteLine("Type 'exit' to stop the program or enter a new day number to run:");


    dayInput = Console.ReadLine() ?? string.Empty;
    if (string.Equals(dayInput, "exit", StringComparison.OrdinalIgnoreCase))
    {
        rerun = false;
    }
    else
    {
        advanced = false;
        Console.WriteLine();
        Console.WriteLine("*****************************");

    }
}
