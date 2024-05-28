namespace LionDev.Services
{
    public class EmailSettings
    {
        public string SmtpServer { get; set; }
        public int SmtpPort { get; set; }
        public string SmtpUsername { get; set; }
        public string SmtpPassword { get; set; }
        public string SenderName { get; set; }
        public string SenderEmail { get; set; }

        public EmailSettings()
        {
            SmtpServer = string.Empty;
            SmtpUsername = string.Empty;
            SmtpPassword = string.Empty;
            SenderName = string.Empty;
            SenderEmail = string.Empty;
        }
    }
}