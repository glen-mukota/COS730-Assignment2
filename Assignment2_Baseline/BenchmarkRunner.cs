using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Assignment2_Baseline
{
    public class BenchmarkRunner
    {
        // Constants controlling the benchmark setup.
        private const int WarmUpIterations = 50;
        private const int MeasurementIterations = 1000;

        public static void Run()
        {
            // Disable logging to remove I/O overhead (already set by caller, but safe redundancy).
            Program.EnableLogging = false;

            var ui = new UI();
            const string testData = "AI Research Paper Submission";

            // Warm‑up phase: let the JIT compiler stabilise.
            for (int i = 0; i < WarmUpIterations; i++)
            {
                ui.SubmitResearchOutput(testData);
            }

            var executionTimes = new List<long>(MeasurementIterations);
            var stopwatch = new Stopwatch();

            // Measurement phase.
            for (int i = 0; i < MeasurementIterations; i++)
            {
                stopwatch.Restart();
                ui.SubmitResearchOutput(testData);
                stopwatch.Stop();
                executionTimes.Add(stopwatch.ElapsedTicks);
            }

            // Convert ticks to milliseconds.
            double tickFrequency = Stopwatch.Frequency;
            var timesMs = executionTimes
                .Select(t => (t / tickFrequency) * 1000.0)
                .ToList();

            double average = timesMs.Average();
            double min = timesMs.Min();
            double max = timesMs.Max();
            double stdDev = Math.Sqrt(timesMs.Average(t => Math.Pow(t - average, 2)));
            double totalTime = timesMs.Sum();

            // Output results (always printed, irrespective of EnableLogging).
            Console.WriteLine("BASELINE BENCHMARK RESULTS");
            Console.WriteLine($"Total Time: {totalTime:F3} ms");
            Console.WriteLine($"Average Time per Run: {average:F3} ms");
            Console.WriteLine($"Min Time: {min:F3} ms");
            Console.WriteLine($"Max Time: {max:F3} ms");
            Console.WriteLine($"Standard Deviation: {stdDev:F3} ms");

            // (Logging is re‑enabled by the caller after Run returns.)
        }
    }
}