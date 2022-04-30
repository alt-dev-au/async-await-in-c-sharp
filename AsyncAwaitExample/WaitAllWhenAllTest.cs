using System.Diagnostics;
using AsyncAwaitExample.Common;

namespace AsyncAwaitExample
{
    internal static class WaitAllWhenAllTest
    {
        public static async Task Execute()
        {
            Stopwatch stopwatch = new();
            string string1;
            string string2;

            stopwatch.Reset();

            stopwatch.Start();
            Task<string> helloTask2 = SayWithDelayV2Async("Hello", 3000, stopwatch, true);
            Task<string> worldTask2 = SayWithDelayV2Async("World", 3000, stopwatch, false);

            try
            {
                Task.WaitAll(helloTask2, worldTask2);
                string1 = helloTask2.Result;
                string2 = worldTask2.Result;
                Console.WriteLine($"{string1} {string2}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }

            stopwatch.Stop();

            Console.WriteLine($"WaitAll with exception RunTime {stopwatch.Elapsed.AsElapsedString()} \n");

            stopwatch.Reset();

            stopwatch.Start();
            Task<string> helloTask3 = SayWithDelayV2Async("Hello", 3000, stopwatch, true);
            Task<string> worldTask3 = SayWithDelayV2Async("World", 3000, stopwatch, false);

            try
            {
                var whenAllTask = Task.WhenAll(helloTask3, worldTask3);
                await whenAllTask;
                string1 = helloTask3.Result;
                string2 = worldTask3.Result;
                Console.WriteLine($"{string1} {string2}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }

            stopwatch.Stop();

            Console.WriteLine($"WhenAll with exception RunTime {stopwatch.Elapsed.AsElapsedString()} \n");

            stopwatch.Reset();

            stopwatch.Start();
            Task<string> helloTask4 = SayWithDelayV2Async("Hello", 3000, stopwatch, true);
            Task<string> worldTask4 = SayWithDelayV2Async("World", 3000, stopwatch, true);

            try
            {
                string2 = await worldTask4;
                string1 = await helloTask4;
                
                Console.WriteLine($"{string1} {string2}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }

            stopwatch.Stop();

            Console.WriteLine($"Await with exception RunTime {stopwatch.Elapsed.AsElapsedString()} \n");
        }

        private static async Task<string> SayWithDelayV2Async(string word, int delay, Stopwatch stopwatch, bool throwException)
        {
            if (delay < 1) throw new ArgumentException($"Delay must be greater than 0!");

            Console.WriteLine($"Starting to say {word}");

            await Task.Delay(delay / 2);
            if (throwException) throw new Exception($"An exception occurred saying '{word}' and it exited @ {stopwatch.Elapsed.AsElapsedString()}!");
            await Task.Delay(delay / 2);

            Console.WriteLine($"Finished saying {word} @ {stopwatch.Elapsed.AsElapsedString()}");
            return word;
        }
    }
}
