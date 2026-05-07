using Assignment2_Optimized;
using System;
using System.Diagnostics;

namespace Assignment2_Optimised
{
    public class BenchmarkRunner
    {
        public static void Run()
        {
            UI ui = new UI();
            string testData = "Sample Research Data";

            int runs = 1000;
            long[] times = new long[runs];

            var stopwatch = new Stopwatch();

            // Warm-up (important)
            for (int i = 0; i < 50; i++)
            {
                ui.SubmitResearchOutput(testData);
            }

            // Benchmark loop
            for (int i = 0; i < runs; i++)
            {
                stopwatch.Restart();

                ui.SubmitResearchOutput(testData);

                stopwatch.Stop();
                times[i] = stopwatch.ElapsedTicks;
            }

            // Convert ticks to milliseconds
            double tickToMs = 1000.0 / Stopwatch.Frequency;

            double total = 0;
            double min = double.MaxValue;
            double max = double.MinValue;

            foreach (var t in times)
            {
                double ms = t * tickToMs;
                total += ms;

                if (ms < min) min = ms;
                if (ms > max) max = ms;
            }

            double average = total / runs;

            // Standard deviation
            double variance = 0;
            foreach (var t in times)
            {
                double ms = t * tickToMs;
                variance += Math.Pow(ms - average, 2);
            }

            variance /= runs;
            double stdDev = Math.Sqrt(variance);

            Console.WriteLine("OPTIMISED BENCHMARK RESULTS");
            Console.WriteLine($"Total Time: {total:F3} ms");
            Console.WriteLine($"Average Time per Run: {average:F3} ms");
            Console.WriteLine($"Min Time: {min:F3} ms");
            Console.WriteLine($"Max Time: {max:F3} ms");
            Console.WriteLine($"Standard Deviation: {stdDev:F3} ms");
        }
    }
}