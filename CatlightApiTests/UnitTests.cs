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
            var connector = new CatlightConnector();
            var doesNeedAttention = connector.GetStatus();
        }

        [Ignore]
        [TestMethod]
        public void CallStatus_StopwatchTime()
        {
            var stopwatch = new Stopwatch();

            stopwatch.Start();
            var connector = new CatlightConnector();
            var catlightStatus = connector.GetStatus();
            stopwatch.Stop();
            var catlightStatusElapsedTime = stopwatch.Elapsed;

            Debug.WriteLine($"catlightStatus = {catlightStatus} in {catlightStatusElapsedTime}");
        }
    }
}