using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Security;
using System.Threading;

namespace DateTimeStopWatchConsoleRunner
{
    class Program
    {
        [DllImport("Kernel32.dll"), SuppressUnmanagedCodeSecurity]
        public static extern int GetCurrentProcessorNumber();

        static void Main(string[] args)
        {
            Console.WriteLine($"ThreadID={Thread.CurrentThread.ManagedThreadId}");
            Console.WriteLine($"ProcessorID={GetCurrentProcessorNumber()}");
            Console.WriteLine($"StopWatchHighResolution={System.Diagnostics.Stopwatch.IsHighResolution}");
            Console.WriteLine($"StopWatchFrequency={System.Diagnostics.Stopwatch.Frequency}");

            testRun();

            Console.WriteLine($"ThreadID={Thread.CurrentThread.ManagedThreadId}");
            Console.WriteLine($"ProcessorID={GetCurrentProcessorNumber()}");
            Console.WriteLine($"StopWatchHighResolution={System.Diagnostics.Stopwatch.IsHighResolution}");
            Console.WriteLine($"StopWatchFrequency={System.Diagnostics.Stopwatch.Frequency}");

            Process.GetCurrentProcess().ProcessorAffinity = (IntPtr)((long)0x1);

            testRun();
        }

        private static void testRun()
        {
            System.Diagnostics.Stopwatch watch1 = new System.Diagnostics.Stopwatch();
            DateTimeStopWatch.StopWatch watch2 = new DateTimeStopWatch.StopWatch();

            int poll = 10;
            int repeat = 10;

            watch1.Start();
            watch2.Start();

            for (int i = 0; i < 100 * repeat; i++)
            {
                long e1 = watch1.ElapsedMilliseconds;
                long e2 = watch2.ElapsedMilliseconds;

                Console.WriteLine($"Poll={poll:00000000},ProcessorID={GetCurrentProcessorNumber()},StopWatch={e1:000000000000},Tick={System.Diagnostics.Stopwatch.GetTimestamp()}," +
                    $"DateTimeStopWatch={e2:000000000000},Tick={DateTime.UtcNow.Ticks},DiffAbs={Math.Abs(e1 - e2):000000000000}");
                Thread.Sleep(poll);
            }

            poll = 100;

            watch1.Restart();
            watch2.Restart();

            for (int i = 0; i < 10 * repeat; i++)
            {
                long e1 = watch1.ElapsedMilliseconds;
                long e2 = watch2.ElapsedMilliseconds;

                Console.WriteLine($"Poll={poll:00000000},ProcessorID={GetCurrentProcessorNumber()},StopWatch={e1:000000000000},Tick={System.Diagnostics.Stopwatch.GetTimestamp()}," +
                    $"DateTimeStopWatch={e2:000000000000},Tick={DateTime.UtcNow.Ticks},DiffAbs={Math.Abs(e1 - e2):000000000000}");
                Thread.Sleep(poll);
            }

            poll = 1000;

            watch1.Restart();
            watch2.Restart();

            for (int i = 0; i < 1 * repeat; i++)
            {
                long e1 = watch1.ElapsedMilliseconds;
                long e2 = watch2.ElapsedMilliseconds;

                Console.WriteLine($"Poll={poll:00000000},ProcessorID={GetCurrentProcessorNumber()},StopWatch={e1:000000000000},Tick={System.Diagnostics.Stopwatch.GetTimestamp()}," +
                    $"DateTimeStopWatch={e2:000000000000},Tick={DateTime.UtcNow.Ticks},DiffAbs={Math.Abs(e1 - e2):000000000000}");
                Thread.Sleep(poll);
            }
        }
    }
}
