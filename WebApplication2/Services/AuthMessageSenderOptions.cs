namespace WebApplication2.Services
{



    public partial class AuthMessageSender : IEmailSender, ISmsSender
    {
        public class AuthMessageSenderOptions
        {
            public string SendGridUser { get; set; }
            public string SendGridKey { get; set; }
        }
    }
}
