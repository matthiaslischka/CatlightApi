using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace CatlightApi
{
    public interface IPortHelper
    {
        int? GetPortNumber();
    }

    public class WindowsLogFileBasedPortHelper : IPortHelper
    {
        public int? GetPortNumber()
        {
            var logsPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                "Catlight\\Logs");

            if (!Directory.Exists(logsPath))
                return null;

            var logFiles = GetLogFiles(logsPath);
            return GetPortNumber(logFiles);
        }

        private int? GetPortNumber(IEnumerable<FileInfo> logFiles)
        {
            foreach (var logFile in logFiles)
            {
                var logText = ReadLogText(logFile);

                var mostRecentPortLogRegEx = new Regex(@".*DEBUG.*Startup.*Listening on port \d*",
                    RegexOptions.RightToLeft);
                var mostRecentPortLog = mostRecentPortLogRegEx.Match(logText).Value;

                if (string.IsNullOrWhiteSpace(mostRecentPortLog))
                    continue;

                var portNumber = Regex.Match(mostRecentPortLog, @"\d+", RegexOptions.RightToLeft).Value;
                return int.Parse(portNumber);
            }
            return null;
        }

        private IEnumerable<FileInfo> GetLogFiles(string logsPath)
        {
            return Directory.GetFiles(logsPath)
                .Where(s => s.Contains("log"))
                .OrderByDescending(s => s)
                .Select(f => new FileInfo(f));
        }

        private static string ReadLogText(FileInfo logFile)
        {
            string logText;

            using (var fs = new FileStream(logFile.FullName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                using (var sr = new StreamReader(fs, Encoding.Default))
                {
                    logText = sr.ReadToEnd();
                }
            }
            return logText;
        }
    }
}