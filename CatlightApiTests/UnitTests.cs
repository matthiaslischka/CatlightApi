using System.Diagnostics;
using CatlightApi;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

namespace CatlightApiTests
{
    [TestClass]
    public class UnitTests
    {
        [TestMethod]
        public void CallStatus_ThrowsNoException()
        {
            var connector = new CatlightConnector();
            var status = connector.GetStatus();
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

        [TestMethod]
        public void DeserializeDashboard_SeverityOk_SeverityIsOk()
        {
            var severityOkJson = "{\"severity\": \"Ok\"}";
            var deserializeDashboard = JsonConvert.DeserializeObject<Dashboard>(severityOkJson);
            deserializeDashboard.Severity.Should().Be(SeverityLevel.Ok);
        }

        [TestMethod]
        public void DeserializeDashboard_SeverityInfo_SeverityIsInfo()
        {
            var severityInfoJson = "{\"severity\": \"Info\"}";
            var deserializeDashboard = JsonConvert.DeserializeObject<Dashboard>(severityInfoJson);
            deserializeDashboard.Severity.Should().Be(SeverityLevel.Info);
        }

        [TestMethod]
        public void DeserializeDashboard_SeverityWarning_SeverityIsWarning()
        {
            var severityWarningJson = "{\"severity\": \"Warning\"}";
            var deserializeDashboard = JsonConvert.DeserializeObject<Dashboard>(severityWarningJson);
            deserializeDashboard.Severity.Should().Be(SeverityLevel.Warning);
        }

        [TestMethod]
        public void DeserializeDashboard_SeverityCritical_SeverityIsCritical()
        {
            var severityCriticalJson = "{\"severity\": \"Critical\"}";
            var deserializeDashboard = JsonConvert.DeserializeObject<Dashboard>(severityCriticalJson);
            deserializeDashboard.Severity.Should().Be(SeverityLevel.Critical);
        }
    }
}