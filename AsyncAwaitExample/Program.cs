using System.Diagnostics;

namespace AsyncAwaitExample;

internal static class Program
{
    private static async Task Main(string[] args)
    {
        await AsyncAwaitTest.Execute();

        await WaitAllWhenAllTest.Execute();
    }
}