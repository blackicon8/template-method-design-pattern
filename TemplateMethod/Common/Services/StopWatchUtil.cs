using System.Diagnostics;

namespace TemplateMethod.Common.Services
{
    public class StopWatchUtil
    {
        public static async Task<TimeSpan> TimeAsync(Func<Task> action)
        {
            var stopwatch = Stopwatch.StartNew();
            await action();
            stopwatch.Stop();
            return stopwatch.Elapsed;
        }
    }
}