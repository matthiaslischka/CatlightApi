using System.Diagnostics;
using CatlightApi;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CatlightApiTests
{
    [TestClass]
    public class UnitTests
    {
        [TestMethod]
        public void CallStatus_ThrowsNoException()
        {
            var catlight = new Catlight();
            var doesNeedAttention = catlight.DoesNeedAttention();
        }

        [Ignore]
        [TestMethod]
        public void CallStatus_StopwatchTime()
        {
            var stopwatch = new Stopwatch();

            stopwatch.Start();
            var catlight1 = new Catlight();
            var isAcknowledged = catlight1.IsAcknowledged();
            stopwatch.Stop();
            var isAcknowledgedElapsedTime = stopwatch.Elapsed;

            stopwatch.Reset();

            stopwatch.Start();
            var catlight2 = new Catlight();
            var severityLevel = catlight2.GetSeverityLevel();
            stopwatch.Stop();
            var severityLevelElapsedTime = stopwatch.Elapsed;

            stopwatch.Reset();

            stopwatch.Start();
            var catlight3 = new Catlight();
            var doesNeedAttention = catlight3.DoesNeedAttention();
            stopwatch.Stop();
            var doesNeedAttentionElapsedTime = stopwatch.Elapsed;

            Debug.WriteLine(
                $"isAcknowledged = {isAcknowledged} in {isAcknowledgedElapsedTime}\n" +
                $"severityLevel = {severityLevel} in {severityLevelElapsedTime}\n" +
                $"doesNeedAttention = {doesNeedAttention} in {doesNeedAttentionElapsedTime}");
        }
    }
}