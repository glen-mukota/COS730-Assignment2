using System;

namespace Assignment2_Baseline
{
    internal class Program
    {
        // Global flag to control console output
        public static bool EnableLogging = true;

        static void Main(string[] args)
        {
            Console.WriteLine("Starting Baseline Benchmark...\n");

            // 🔴 CRITICAL: Disable logging BEFORE benchmark starts
            EnableLogging = false;

            BenchmarkRunner.Run();

            // (Optional) Re-enable logging after benchmark
            EnableLogging = true;

            Console.WriteLine("\nBenchmark complete.");
            Console.WriteLine("Press Enter to exit...");
            Console.ReadLine();
        }
    }
}