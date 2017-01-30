using System;
using System.Linq;
using System.Net;
using Newtonsoft.Json;

namespace CatlightApi
{
    public class CatlightConnector
    {
        private readonly IPortHelper _portHelper;

        public CatlightConnector()
        {
            _portHelper = new WindowsLogFileBasedPortHelper();
        }

        public CatlightStatus GetStatus()
        {
            var dashboard = UpdateDashboard();

            if (dashboard == null)
                return CatlightStatus.CatlightNotFound;

            if (!dashboard.Servers.Any())
                return CatlightStatus.NoProjects;

            switch (dashboard.Severity)
            {
                case SeverityLevel.Ok:
                    return CatlightStatus.Ok;

                case SeverityLevel.Info:
                    return CatlightStatus.Info;

                case SeverityLevel.Warning:
                    return dashboard.IsAcknowledged
                        ? CatlightStatus.WarningAcknowledged
                        : CatlightStatus.Warning;

                case SeverityLevel.Critical:
                    return dashboard.IsAcknowledged
                        ? CatlightStatus.CriticalAcknowledged
                        : CatlightStatus.Critical;

                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private Dashboard UpdateDashboard()
        {
            var portNumber = _portHelper.GetPortNumber();
            if (!portNumber.HasValue)
                return null;

            using (var webClient = new WebClient())
            {
                try
                {
                    var dashboardJsonString =
                        webClient.DownloadString($"http://localhost:{portNumber}/Dashboard/GetDashboard");
                    return JsonConvert.DeserializeObject<Dashboard>(dashboardJsonString);
                }
                catch (WebException)
                {
                    return null;
                }
            }
        }
    }
}