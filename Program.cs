using System.Diagnostics;

static string ProcessData(string dataName)
{
	Thread.Sleep(3000);
	return $"{dataName} processing finished in 3s";
}

static async Task<string> ProcessDataAsync(string dataName)
{
	await Task.Delay(3000);
	return $"Asynchronous {dataName} processing finished in 3s";
}

static void ProcessMultipleData()
{
	Console.WriteLine("Processing multiple data synchronously...");

	var stopwatch = new Stopwatch();
	stopwatch.Start();

	Console.WriteLine(ProcessData("File1"));
	Console.WriteLine(ProcessData("File2"));
	Console.WriteLine(ProcessData("File3"));

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

	var results = await Task.WhenAll(task1, task2, task3);
	foreach (var result in results) {
		Console.WriteLine(result);
	}

	stopwatch.Stop();

	Console.WriteLine($"Asynchronous processing finished in {stopwatch.ElapsedMilliseconds / 1000}s");
}

ProcessMultipleData();
await ProcessMultipleDataAsync();
