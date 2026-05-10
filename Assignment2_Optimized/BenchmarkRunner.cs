using Assignment2_Optimized;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Assignment2_Optimised  // Note: namespace matches your original
{
    public class BenchmarkRunner
    {
        public static void Run()
        {
            // CRITICAL: Disable all console logging inside the timed loop
            Program.EnableLogging = false;

            UI ui = new UI();
            string testData = "Sample Research Data";

            int runs = 1000;
            List<long> ticks = new List<long>();

            // Warm-up (JIT stabilisation)
            for (int i = 0; i < 50; i++)
            {
                ui.SubmitResearchOutput(testData);
            }

            Stopwatch stopwatch = new Stopwatch();

            // Benchmark loop
            for (int i = 0; i < runs; i++)
            {
                stopwatch.Restart();
                ui.SubmitResearchOutput(testData);
                stopwatch.Stop();
                ticks.Add(stopwatch.ElapsedTicks);
            }

            // Convert ticks to milliseconds (using Stopwatch.Frequency)
            double tickToMs = 1000.0 / Stopwatch.Frequency;
            List<double> timesMs = ticks.Select(t => t * tickToMs).ToList();

            double total = timesMs.Sum();
            double average = timesMs.Average();
            double min = timesMs.Min();
            double max = timesMs.Max();

            // Standard deviation
            double variance = timesMs.Average(t => Math.Pow(t - average, 2));
            double stdDev = Math.Sqrt(variance);

            Console.WriteLine("OPTIMISED BENCHMARK RESULTS");
            Console.WriteLine($"Total Time: {total:F3} ms");
            Console.WriteLine($"Average Time per Run: {average:F3} ms");
            Console.WriteLine($"Min Time: {min:F3} ms");
            Console.WriteLine($"Max Time: {max:F3} ms");
            Console.WriteLine($"Standard Deviation: {stdDev:F3} ms");

            // Optional: re-enable logging if needed after benchmark
            Program.EnableLogging = true;
        }
    }
}