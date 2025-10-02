using System.Diagnostics;

static void ProcessData(string dataName)
{
	Thread.Sleep(3000);
	Console.WriteLine($"{dataName} processing finished in 3s");
}

static async Task ProcessDataAsync(string dataName)
{
	await Task.Delay(3000);
	Console.WriteLine($"Asynchronous {dataName} processing finished in 3s");
}

static void ProcessMultipleData()
{
	Console.WriteLine("Processing multiple data synchronously...");

	var stopwatch = new Stopwatch();
	stopwatch.Start();

	ProcessData("File1");
	ProcessData("File2");
	ProcessData("File3");

	stopwatch.Stop();

	Console.WriteLine($"Synchronous processing finished in {stopwatch.ElapsedMilliseconds / 1000}s");
}

static async Task ProcessMultipleDataAsync()
{
	Console.WriteLine("Processing multiple data asynchronously...");

	var stopwatch = new Stopwatch();
	stopwatch.Start();

	var task1 = ProcessDataAsync("File1");
	var task2 = ProcessDataAsync("File2");
	var task3 = ProcessDataAsync("File3");

	await task1;
	await task2;
	await task3;

	stopwatch.Stop();

	Console.WriteLine($"Asynchronous processing finished in {stopwatch.ElapsedMilliseconds / 1000}s");
}

ProcessMultipleData();
await ProcessMultipleDataAsync();
