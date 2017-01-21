using System;
using System.Net;
using Newtonsoft.Json;

namespace CatlightApi
{
    public class Catlight
    {
        private readonly IPortHelper _portHelper;
        protected Dashboard Dashboard;

        public Catlight()
        {
            _portHelper = new WindowsLogFileBasedPortHelper();
        }

        /// <summary>
        ///     Returns null if Catlight status can not be determined.
        /// </summary>
        public bool? IsAcknowledged()
        {
            UpdateDashboard();
            return Dashboard?.IsAcknowledged;
        }

        /// <summary>
        ///     Returns null if Catlight status can not be determined.
        /// </summary>
        public Severity? GetSeverityLevel()
        {
            UpdateDashboard();
            return Dashboard?.Severity;
        }

        /// <summary>
        ///     Returns null if Catlight status can not be determined.
        /// </summary>
        public bool? DoesNeedAttention()
        {
            UpdateDashboard();

            if (Dashboard == null)
                return null;

            switch (Dashboard.Severity)
            {
                case Severity.Ok:
                case Severity.Info:
                    return false;
                case Severity.Warning:
                case Severity.Critical:
                    return !Dashboard.IsAcknowledged;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void UpdateDashboard()
        {
            Dashboard = null;
            var portNumber = _portHelper.GetPortNumber();
            if (!portNumber.HasValue)
                return;

            using (var webClient = new WebClient())
            {
                try
                {
                    var dashboardJsonString =
                        webClient.DownloadString($"http://localhost:{portNumber}/Dashboard/GetDashboard");
                    Dashboard = JsonConvert.DeserializeObject<Dashboard>(dashboardJsonString);
                }
                catch (WebException)
                {
                }
            }
        }
    }
}