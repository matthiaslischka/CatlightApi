using System.Collections.Generic;

namespace CatlightApi
{
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

    internal enum SeverityLevel
    {
        Ok,
        Info,
        Warning,
        Critical
    }

    internal class Dashboard
    {
        public SeverityLevel Severity { get; set; }
        public bool IsAcknowledged { get; set; }
        public List<Server> Servers { get; set; }
    }

    internal class Server
    {
        public string Name { get; set; }
    }
}