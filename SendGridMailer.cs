using Microsoft.Extensions.Options;
using Piranha.Mailer.Interfaces;
using Piranha.Mailer.Models;
using SendGrid;
using SendGrid.Helpers.Mail;
using System.Threading.Tasks;

namespace Piranha.Mailer
{
    public class SendGridMailer : IMailer
    {
        private readonly SendGridSettings _sendGridSettings;

        public SendGridMailer(IOptions<SendGridSettings> sendGridSettings)
        {
            _sendGridSettings = sendGridSettings.Value;
        }

        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            return Execute(_sendGridSettings.SendGridKey, subject, htmlMessage, email);
        }

        public Task<Response> Execute(string apiKey, string subject, string message, string email)
        {
            var client = new SendGridClient(apiKey);

            var msg = new SendGridMessage()
            {
                From = new EmailAddress(_sendGridSettings.SendGridEmail, _sendGridSettings.SendGridUser),
                Subject = subject,
                PlainTextContent = message,
                HtmlContent = message
            };

            msg.AddTo(new EmailAddress(email));

            // Disable click tracking.
            // See https://sendgrid.com/docs/User_Guide/Settings/tracking.html
            msg.SetClickTracking(false, false);

            return client.SendEmailAsync(msg);
        }
    }
}
