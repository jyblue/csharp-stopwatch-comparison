using System;

namespace DateTimeStopWatch
{
    public class StopWatch
    {
        private long elapsedMilliseconds = 0;
        private double residue = 0.0;
        private DateTime beginTime;
        private bool isRunning = false;

        public bool IsRunning
        {
            get
            {
                lock (this)
                {
                    return isRunning;
                }
            }
        }
        
        public long ElapsedMilliseconds
        {
            get
            {
                lock (this)
                {
                    if (isRunning)
                    {
                        updateElapsedTime();  
                    }

                    return elapsedMilliseconds;
                }
            }
        }

        private void updateElapsedTime()
        {
            DateTime now = DateTime.Now;

            double elapsed = now.Subtract(beginTime).TotalMilliseconds + residue;
            residue = elapsed - Math.Truncate(elapsed);
            elapsedMilliseconds += (long)(Math.Max(0, Math.Min(long.MaxValue, Math.Truncate(elapsed))));

            beginTime = now;
        }

        public void Start()
        {
            if (IsRunning) return;

            lock (this)
            {
                beginTime = DateTime.Now;
                isRunning = true;
            }
        }

        public void Restart()
        {
            lock (this)
            {
                beginTime = DateTime.Now;
                elapsedMilliseconds = 0;
                isRunning = true;
            }
        }

        public void Stop()
        {
            if (!isRunning) return;

            lock (this)
            {
                updateElapsedTime();
                isRunning = false;
            }
        }

        public void Reset()
        {
            lock (this)
            {
                elapsedMilliseconds = 0;
                isRunning = false;
            }
        }
    }
}
