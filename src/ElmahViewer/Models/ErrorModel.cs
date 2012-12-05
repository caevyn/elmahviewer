namespace ElmahViewer.Models
{
    public class ErrorModel
    {
        public string Id { get; set; }

        public string HostName { get; set; }

        public int StatusCode { get; set; }

        public string StatusDescription { get; set; }

        public string Type { get; set; }

        public string HumaneType { get; set; }

        public string Message { get; set; }

        public string User { get; set; }

        public string When { get; set; }

        public string Iso8601Time { get; set; }
    }
}