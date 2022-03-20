using NUnit.Framework;

namespace DateTimeStopWatch.Tests
{
    public class DateTimeStopWatchTests
    {
        [Test]
        public void StopWatch_should_be_stopped_when_created()
        {
            StopWatch stopWatch = new StopWatch();

            Assert.That(stopWatch.IsRunning, Is.False);
        }

        [Test]
        public void StopWatch_should_be_running_when_started()
        {
            StopWatch stopWatch = new StopWatch();
            
            stopWatch.Start();
            Assert.That(stopWatch.IsRunning, Is.True);
        }

        [Test]
        public void StopWatch_should_be_stopped_when_stopped()
        {
            StopWatch stopWatch = new StopWatch();
            
            stopWatch.Start();
            Assert.That(stopWatch.IsRunning, Is.True);

            stopWatch.Stop();
            Assert.That(stopWatch.IsRunning, Is.False);
        }

        [Test]
        public void StopWatch_start_stop_repeat_test()
        {
            StopWatch stopWatch = new StopWatch();

            stopWatch.Start();
            Assert.That(stopWatch.IsRunning, Is.True);

            stopWatch.Stop();
            Assert.That(stopWatch.IsRunning, Is.False);

            stopWatch.Start();
            Assert.That(stopWatch.IsRunning, Is.True);

            stopWatch.Stop();
            Assert.That(stopWatch.IsRunning, Is.False);
        }

        [Test]
        public void StopWatch_should_be_running_when_restarted()
        {
            StopWatch stopWatch = new StopWatch();

            stopWatch.Restart();
            Assert.That(stopWatch.IsRunning, Is.True);
        }

        [Test]
        public void StopWatch_should_be_stopped_when_stopped_from_restart()
        {
            StopWatch stopWatch = new StopWatch();

            stopWatch.Restart();
            Assert.That(stopWatch.IsRunning, Is.True);

            stopWatch.Stop();
            Assert.That(stopWatch.IsRunning, Is.False);
        }

        [Test]
        public void StopWatch_should_be_stopped_when_reset()
        {
            StopWatch stopWatch = new StopWatch();

            stopWatch.Start();
            Assert.That(stopWatch.IsRunning, Is.True);

            stopWatch.Reset();
            Assert.That(stopWatch.IsRunning, Is.False);
        }

        [Test]
        public void StopWatch_elasedMillisecond_test()
        {
            StopWatch stopWatch = new StopWatch();
            stopWatch.Start();

            Assert.That(() => stopWatch.ElapsedMilliseconds, Is.EqualTo(10000).Within(50).After(10).Seconds.PollEvery(10).MilliSeconds);
        }

        [Test]
        public void StopWatch_elasedMillisecond_restart_test()
        {
            StopWatch stopWatch = new StopWatch();
            stopWatch.Start();
            Assert.That(() => stopWatch.ElapsedMilliseconds, Is.EqualTo(10000).Within(50).After(10).Seconds.PollEvery(10).MilliSeconds);

            stopWatch.Restart();
            Assert.That(() => stopWatch.ElapsedMilliseconds, Is.EqualTo(10000).Within(50).After(10).Seconds.PollEvery(10).MilliSeconds);
        }

        [Test]
        public void StopWatch_elasedMillisecond_stop_test()
        {
            StopWatch stopWatch = new StopWatch();
            stopWatch.Start();
            Assert.That(stopWatch.IsRunning, Is.True.After(10).Seconds.PollEvery(100).Seconds);
            
            stopWatch.Stop();
            Assert.That(stopWatch.ElapsedMilliseconds, Is.EqualTo(10000).Within(50));

            stopWatch.Start();
            Assert.That(() => stopWatch.ElapsedMilliseconds, Is.EqualTo(20000).Within(50).After(10).Seconds.PollEvery(10).MilliSeconds);
        }
    }
}