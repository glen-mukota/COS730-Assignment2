using System;

namespace Assignment2_Optimised
{
    internal class Program
    {
        // Keep this for consistency (even if you don't fully use it)
        public static bool EnableLogging = true;

        static void Main(string[] args)
        {
            Console.WriteLine("Starting Optimised Benchmark...\n");

            BenchmarkRunner.Run();

            Console.WriteLine("\nBenchmark complete.");
            Console.WriteLine("Press Enter to exit...");
            Console.ReadLine();
        }
    }
}