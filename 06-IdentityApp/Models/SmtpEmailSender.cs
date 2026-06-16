using MailKit.Net.Smtp; // MailKit'e ait SmtpClient'ı kullanmak için bu kalmalı
using MailKit.Security;
using MimeKit;
// using System.Net.Mail; <-- Çakışmaya neden olan bu satırı TAMAMEN sildik!
using System.Threading.Tasks;

namespace IdentityApp.Models
{
    public class SmtpEmailSender : IEmailSender
    {
        private readonly string? _host;
        private readonly int _port;
        private readonly bool _enableSSL;
        private readonly string? _username;
        private readonly string? _password;

        public SmtpEmailSender(string? host, int port, bool enableSSL, string? username, string? password)
        {
            _host = host;
            _port = port;
            _enableSSL = enableSSL;
            _username = username;
            _password = password;
        }

        public async Task SendEmailAsync(string email, string subject, string message)
        {
            var emailMessage = new MimeMessage();

            
            emailMessage.From.Add(new MailboxAddress("Identity App", _username));

            
            emailMessage.To.Add(new MailboxAddress("", email));

            emailMessage.Subject = subject;

            
            var bodyBuilder = new BodyBuilder
            {
                HtmlBody = message
            };
            emailMessage.Body = bodyBuilder.ToMessageBody();

            
            using var client = new SmtpClient();
            try
            {
                var socketOption = _enableSSL ? SecureSocketOptions.StartTls : SecureSocketOptions.None;

               
                await client.ConnectAsync(_host, _port, socketOption);

                
                await client.AuthenticateAsync(_username, _password);

                
                await client.SendAsync(emailMessage);
            }
            finally
            {
                // İşlem bitince bağlantıyı güvenli bir şekilde kapat
                await client.DisconnectAsync(true);
            }
        }
    }
}