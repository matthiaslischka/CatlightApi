namespace CatlightApi
{
    public enum Severity
    {
        Ok,
        Info,
        Warning,
        Critical
    }

    public class Dashboard
    {
        public Severity Severity { get; set; }
        public bool IsAcknowledged { get; set; }
    }
}