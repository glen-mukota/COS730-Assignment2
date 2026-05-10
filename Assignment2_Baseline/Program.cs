using System;

namespace Assignment2_Baseline
{
    internal class Program
    {
        /// <summary>
        /// Global flag used to disable console output during benchmarking.
        /// </summary>
        public static bool EnableLogging = true;

        static void Main(string[] args)
        {
            Console.WriteLine("Starting Baseline Benchmark...\n");

            // Disable logging to eliminate I/O overhead during measurement.
            EnableLogging = false;

            BenchmarkRunner.Run();

            // Re‑enable logging after the benchmark.
            EnableLogging = true;

            Console.WriteLine("\nBenchmark complete.");
            Console.WriteLine("Press Enter to exit...");
            Console.ReadLine();
        }
    }
}