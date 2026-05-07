using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Assignment2_Baseline
{
    public class BenchmarkRunner
    {
        public static void Run()
        {
            // Disable logging to remove I/O overhead
            Program.EnableLogging = false;

            UI ui = new UI();
            string testData = "AI Research Paper Submission";

            // Warm-up (JIT stabilisation)
            for (int i = 0; i < 50; i++)
            {
                ui.SubmitResearchOutput(testData);
            }

            List<long> executionTimes = new List<long>();
            Stopwatch stopwatch = new Stopwatch();

            // Benchmark runs
            for (int i = 0; i < 1000; i++)
            {
                stopwatch.Restart();

                ui.SubmitResearchOutput(testData);

                stopwatch.Stop();
                executionTimes.Add(stopwatch.ElapsedTicks);
            }

            // Convert ticks to milliseconds
            double tickFrequency = (double)Stopwatch.Frequency;
            List<double> timesMs = executionTimes
                .Select(t => (t / tickFrequency) * 1000.0)
                .ToList();

            double average = timesMs.Average();
            double min = timesMs.Min();
            double max = timesMs.Max();

            double stdDev = Math.Sqrt(timesMs
                .Average(t => Math.Pow(t - average, 2)));

            double totalTime = timesMs.Sum();

            // Output results
            Console.WriteLine("BASELINE BENCHMARK RESULTS");
            Console.WriteLine($"Total Time: {totalTime:F3} ms");
            Console.WriteLine($"Average Time per Run: {average:F3} ms");
            Console.WriteLine($"Min Time: {min:F3} ms");
            Console.WriteLine($"Max Time: {max:F3} ms");
            Console.WriteLine($"Standard Deviation: {stdDev:F3} ms");

            // Re-enable logging if needed later
            Program.EnableLogging = true;
        }
    }
}