using System;
using System.IO;
using System.Text.RegularExpressions;

namespace CatlightApi
{
    public interface IPortHelper
    {
        int? GetPortNumber();
    }

    public class PortHelper : IPortHelper
    {
        public int? GetPortNumber()
        {
            var logsPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                "Catlight\\Logs");
            if (!Directory.Exists(logsPath))
                return null;

            var logFile = new FileInfo(Path.Combine(logsPath, "log.txt"));
            if (!logFile.Exists)
                return null;

            var logText = File.ReadAllText(logFile.FullName);
            var mostRecentPortLogRegEx = new Regex(@".*DEBUG.*Startup.*Listening on port \d*", RegexOptions.RightToLeft);
            var mostRecentPortLog = mostRecentPortLogRegEx.Match(logText).Value;
            var portNumber = Regex.Match(mostRecentPortLog, @"\d+", RegexOptions.RightToLeft).Value;
            return int.Parse(portNumber);
        }
    }
}