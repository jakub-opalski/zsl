using CommonDataDictionary;
using System;
using System.Net.Mail;

namespace SingleResponsibilityBad.Services
{
    public class UserService
    {
        public UserService()
        {
            
        }

        public void RegisterUser(string email, string password)
        {
            if (!ValidateEmail(email))
            {
                throw new Exception("Invalid email");
            }
            var user = new User(email, password);
            new DbContext().SaveUser(user);
            SendEmail(new MailMessage("ouremail@email.com", email) { Subject = "Account registred successfully" });
        }

        public bool ValidateEmail(string email)
        {
            return email.Contains("@");
        }

        public bool SendEmail(MailMessage message)
        {
            var smptClient = new SmtpClient();
            smptClient.Send(message);
            return true;
        }
    }
}
