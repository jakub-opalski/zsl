using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;

namespace SingleResponsibilityGood.Services
{
    public class MailService
    {
        private SmtpClient _smtpClient;

        public MailService() 
        {
            _smtpClient = new SmtpClient();
        }

        public bool SendEmail(string to, string subject)
        {
            var message = new MailMessage("ouremail@email.com", to) { Subject = subject };
            _smtpClient.Send(message);
            return true;
        }

        public bool ValidateEmail(string email)
        {
            return email.Contains("@");
        }
    }
}
