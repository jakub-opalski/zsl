using CommonDataDictionary;
using System;

namespace SingleResponsibilityGood.Services
{
    public class UserService
    {
        private MailService _mailService;
        private DbContext _dbContext;

        public UserService(MailService mailService, DbContext dbContext)
        {
            _mailService = mailService;
            _dbContext = dbContext;
        }

        public void RegisterUser(string email, string password)
        {
            if (!_mailService.ValidateEmail(email))
            {
                throw new Exception("Invalid email");
            }
            var user = new User(email, password);
            _dbContext.SaveUser(user);
            _mailService.SendEmail(email, "Account registred successfully");
        }
    }
}
