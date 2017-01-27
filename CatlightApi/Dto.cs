using System.Collections.Generic;

namespace CatlightApi
{
    internal enum SeverityLevel
    {
        Ok,
        Info,
        Warning,
        Critical
    }

    public enum CatlightStatus
    {
        CatlightNotFound,
        NoProjects,
        Ok,
        Info,
        WarningAcknowledged,
        Warning,
        CriticalAcknowledged,
        Critical
    }

    internal class Dashboard
    {
        public SeverityLevel SeverityLevel { get; set; }
        public bool IsAcknowledged { get; set; }
        public List<Server> Servers { get; set; }
    }

    internal class Server
    {
        public string Name { get; set; }
    }
}