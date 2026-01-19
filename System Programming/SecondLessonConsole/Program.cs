using System.Diagnostics;

var process = Process.GetCurrentProcess();

Console.WriteLine($"Id: {process.Id}");
Console.WriteLine($"Name: {process.ProcessName}");
Console.WriteLine($"VirtualMemory: {process.VirtualMemorySize64}");