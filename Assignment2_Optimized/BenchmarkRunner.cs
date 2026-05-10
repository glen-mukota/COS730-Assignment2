using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Assignment2_Optimized
{
    public class BenchmarkRunner
    {
        private const int WarmUpIterations = 50;
        private const int MeasurementIterations = 1000;

        public static void Run()
        {
            // Suppress I/O during measurement.
            Program.EnableLogging = false;

            var ui = new UI();
            const string testData = "Sample Research Data";

            var ticks = new List<long>(MeasurementIterations);

            // Warm‑up phase: stabilise JIT and caches.
            for (int i = 0; i < WarmUpIterations; i++)
            {
                ui.SubmitResearchOutput(testData);
            }

            var stopwatch = new Stopwatch();

            // Measurement phase.
            for (int i = 0; i < MeasurementIterations; i++)
            {
                stopwatch.Restart();
                ui.SubmitResearchOutput(testData);
                stopwatch.Stop();
                ticks.Add(stopwatch.ElapsedTicks);
            }

            // Convert ticks to milliseconds.
            double tickToMs = 1000.0 / Stopwatch.Frequency;
            var timesMs = ticks.Select(t => t * tickToMs).ToList();

            double total = timesMs.Sum();
            double average = timesMs.Average();
            double min = timesMs.Min();
            double max = timesMs.Max();
            double variance = timesMs.Average(t => Math.Pow(t - average, 2));
            double stdDev = Math.Sqrt(variance);

            Console.WriteLine("OPTIMISED BENCHMARK RESULTS");
            Console.WriteLine($"Total Time: {total:F3} ms");
            Console.WriteLine($"Average Time per Run: {average:F3} ms");
            Console.WriteLine($"Min Time: {min:F3} ms");
            Console.WriteLine($"Max Time: {max:F3} ms");
            Console.WriteLine($"Standard Deviation: {stdDev:F3} ms");

            // Logging can be left disabled or re‑enabled depending on needs.
            // Program.EnableLogging = true;
        }
    }
}