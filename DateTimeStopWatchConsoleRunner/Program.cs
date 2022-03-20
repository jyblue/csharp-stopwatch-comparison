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

            watch1.Start();
            watch2.Start();

            int poll = 10;
            for (int i = 0; i < 10000; i++)
            {
                long e1 = watch1.ElapsedMilliseconds;
                long e2 = watch2.ElapsedMilliseconds;

                Console.WriteLine($"Poll={poll:00000000}ms StopWatch={e1:00000000}ms StopWatch2={e2:00000000}ms DiffAbs={Math.Abs(e1 - e2):00000000}ms");
                Thread.Sleep(poll);
            }

            poll = 100;
            for (int i = 0; i < 1000; i++)
            {
                long e1 = watch1.ElapsedMilliseconds;
                long e2 = watch2.ElapsedMilliseconds;

                Console.WriteLine($"Poll={poll:00000000}ms StopWatch={e1:00000000}ms StopWatch2={e2:00000000}ms DiffAbs={Math.Abs(e1 - e2):00000000}ms");
                Thread.Sleep(poll);
            }

            poll = 1000;
            for (int i = 0; i < 100; i++)
            {
                long e1 = watch1.ElapsedMilliseconds;
                long e2 = watch2.ElapsedMilliseconds;

                Console.WriteLine($"Poll={poll:00000000}ms StopWatch={e1:00000000}ms StopWatch2={e2:00000000}ms DiffAbs={Math.Abs(e1 - e2):00000000}ms");
                Thread.Sleep(poll);
            }
        }
    }
}
