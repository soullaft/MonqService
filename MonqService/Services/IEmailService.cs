using MonqService.Models;
using System.Collections.Generic;

namespace MonqService.Services
{
    public interface IEmailService
    {
        void Send(MailDto to, string subject, string body);

        IEnumerable<Mail> GetAllMails();
    }
}
