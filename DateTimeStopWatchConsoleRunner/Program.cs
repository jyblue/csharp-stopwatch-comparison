using System;
using System.Threading;

namespace DateTimeStopWatchConsoleRunner
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Diagnostics.Stopwatch watch1 = new System.Diagnostics.Stopwatch();
            DateTimeStopWatch.StopWatch watch2 = new DateTimeStopWatch.StopWatch();

            Console.WriteLine($"StopWatchHighResolution={System.Diagnostics.Stopwatch.IsHighResolution}");
            Console.WriteLine($"StopWatchFrequency={System.Diagnostics.Stopwatch.Frequency}");

            watch1.Start();
            watch2.Start();
            int poll = 10;

            for (int i = 0; i < 10000; i++)
            {
                long e1 = watch1.ElapsedMilliseconds;
                long e2 = watch2.ElapsedMilliseconds;

                Console.WriteLine($"Poll={poll:00000000},StopWatch={e1:000000000000},Tick={System.Diagnostics.Stopwatch.GetTimestamp()}," +
                    $"DateTimeStopWatch={e2:000000000000},Tick={DateTime.UtcNow.Ticks},DiffAbs={Math.Abs(e1 - e2):000000000000}");
                Thread.Sleep(poll);
            }

            watch1.Restart();
            watch2.Restart();
            poll = 100;

            for (int i = 0; i < 1000; i++)
            {
                long e1 = watch1.ElapsedMilliseconds;
                long e2 = watch2.ElapsedMilliseconds;

                Console.WriteLine($"Poll={poll:00000000},StopWatch={e1:000000000000},Tick={System.Diagnostics.Stopwatch.GetTimestamp()}," +
                      $"DateTimeStopWatch={e2:000000000000},Tick={DateTime.UtcNow.Ticks},DiffAbs={Math.Abs(e1 - e2):000000000000}");
                Thread.Sleep(poll);
            }

            watch1.Restart();
            watch2.Restart();
            poll = 1000;
            for (int i = 0; i < 100; i++)
            {
                long e1 = watch1.ElapsedMilliseconds;
                long e2 = watch2.ElapsedMilliseconds;

                Console.WriteLine($"Poll={poll:00000000},StopWatch={e1:000000000000},Tick={System.Diagnostics.Stopwatch.GetTimestamp()}," +
                      $"DateTimeStopWatch={e2:000000000000},Tick={DateTime.UtcNow.Ticks},DiffAbs={Math.Abs(e1 - e2):000000000000}");
                Thread.Sleep(poll);
            }
        }
    }
}
