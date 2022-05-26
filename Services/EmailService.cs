using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web;
using Contracts.Services;
namespace Services
{
    public class EmailService : IEmailService
    {
        // TODO: Refactor the configuration (Maybe a config class ?)
        private const int Port = 587;
        private const string Server = "smtp.gmail.com";

        private const string From = "alifaudittest@gmail.com";
        private const string FromPassword = "arstgmneio";

        private const string PasswordResetSubject = "Password Reset !";

        /// <summary>
        ///     Send an email with a token to receiver, in order to reset password
        /// </summary>
        public async Task SendPasswordResetMailAsync(
            string receiverEmail,
            string tokenUrl,
            string backUrl
        )
        {
            // Need to encode (escape) special characters in URL
            var emailEncoded = HttpUtility.UrlEncode(receiverEmail);
            tokenUrl = HttpUtility.UrlEncode(tokenUrl);

            var message = $"{backUrl}?email={emailEncoded}&token={tokenUrl}#";
            await SendMailAsync(receiverEmail, PasswordResetSubject, message);
        }

        /// <summary>
        ///     Sends an email to a given *send_to* with subject and body of
        ///     the message from given arguments.
        /// </summary>
        private static async Task SendMailAsync(string sendTo, string subject, string body)
        {
            // Create new mail
            using var mail = new MailMessage
            {
                From = new MailAddress(From),
                Subject = subject,
                Body = body,
                IsBodyHtml = true
            };
            mail.To.Add(sendTo);

            // Initialize the smtp connection
            using var smtp = new SmtpClient(Server, Port);
            smtp.Credentials = new NetworkCredential(From, FromPassword);
            smtp.EnableSsl = true;

            // Send the email
            await smtp.SendMailAsync(mail);
        }
    }
}
