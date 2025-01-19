using AspectInjector.Broker;
using System;
using System.Diagnostics;

namespace TimerSharp.Core
{
    [Aspect(Scope.Global)]
    [Injection(typeof(MethodTimer))]
    public class MethodTimer : Attribute
    {
        private readonly Stopwatch _stopwatch = new Stopwatch();

        // Start timer before method execution
        [Advice(Kind.Before, Targets = Target.Method)]
        public void StartTimer()
        {
            _stopwatch.Start();
        }

        // Stop timer after method execution and log the time
        [Advice(Kind.After, Targets = Target.Method)]
        public void StopTimer([Argument(Source.Name)] string methodName)
        {
            _stopwatch.Stop();

            var elapsedTime = GetElapsedTime();
            LogElapsedTime(methodName, elapsedTime);

            _stopwatch.Reset();
        }

        // Method to calculate elapsed time in milliseconds and nanoseconds
        private (long milliseconds, long nanoseconds) GetElapsedTime()
        {
            long ticks = _stopwatch.ElapsedTicks;
            double nanosPerTick = (1_000_000_000.0 / Stopwatch.Frequency); // Convert ticks to nanoseconds
            long totalNanoseconds = (long)(ticks * nanosPerTick);

            long milliseconds = totalNanoseconds / 1_000_000; // Convert to milliseconds
            long nanoseconds = totalNanoseconds % 1_000_000;  // Remainder for nanoseconds

            return (milliseconds, nanoseconds);
        }

        // Method to log the elapsed time in a human-readable format
        private void LogElapsedTime(string methodName, (long milliseconds, long nanoseconds) elapsedTime)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write($"Method {methodName}");

            Console.ForegroundColor = ConsoleColor.Yellow;  

            Console.Write($" took {elapsedTime.milliseconds}.{elapsedTime.nanoseconds:D6}");

            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine(" ms to execute.");
        }
    }
}
