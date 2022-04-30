using System.Diagnostics;
using AsyncAwaitExample.Common;

namespace AsyncAwaitExample
{
    internal static class AsyncAwaitTest
    {
        public static async Task Execute()
        {
            Stopwatch stopwatch = new();

            stopwatch.Start();
            string string1 = SayWithDelay("Hello", 3000, stopwatch);
            string string2 = SayWithDelay("World", 3000, stopwatch);
            Console.WriteLine($"{string1} {string2}");
            stopwatch.Stop();

            Console.WriteLine($"Synchronous RunTime {stopwatch.Elapsed.AsElapsedString()} \n");

            stopwatch.Reset();

            stopwatch.Start();
            string1 = await SayWithDelayAsync("Hello", 3000, stopwatch);
            string2 = await SayWithDelayAsync("World", 3000, stopwatch);
            Console.WriteLine($"{string1} {string2}");
            stopwatch.Stop();

            Console.WriteLine($"Await RunTime {stopwatch.Elapsed.AsElapsedString()} \n");

            stopwatch.Reset();

            stopwatch.Start();
            Task<string> helloTask = SayWithDelayAsync("Hello", 3000, stopwatch);
            Task<string> worldTask = SayWithDelayAsync("World", 3000, stopwatch);

            string1 = await helloTask;
            string2 = await worldTask;
            Console.WriteLine($"{string1} {string2}");
            stopwatch.Stop();

            Console.WriteLine($"Task RunTime {stopwatch.Elapsed.AsElapsedString()} \n");
        }

        private static string SayWithDelay(string word, int delay, Stopwatch stopwatch)
        {
            if (delay < 1) throw new ArgumentException($"Delay must be greater than 0!");

            Console.WriteLine($"Starting to say {word}");

            Task.Delay(delay).Wait();

            Console.WriteLine($"Finished saying {word} @ {stopwatch.Elapsed.AsElapsedString()}");

            return word;
        }

        private static async Task<string> SayWithDelayAsync(string word, int delay, Stopwatch stopwatch)
        {
            if (delay < 1) throw new ArgumentException($"Delay must be greater than 0!");

            Console.WriteLine($"Starting to say {word}");

            await Task.Delay(delay);

            Console.WriteLine($"Finished saying {word} @ {stopwatch.Elapsed.AsElapsedString()}");
            return word;
        }
    }
}
