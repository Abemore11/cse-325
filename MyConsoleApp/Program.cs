Console.WriteLine("Hello, World!");

// 1. Define "Now" and "Christmas"
DateTime today = DateTime.Today;
DateTime christmas = new DateTime(today.Year, 12, 25);

// Uses string interpolation
Console.WriteLine($"The current time is {today}");

// 2. Subtract the dates to get a TimeSpan
TimeSpan difference = christmas - today;

// 3. Output the result using string interpolation
Console.WriteLine($"There are {difference.Days} days until the next Christmas!");