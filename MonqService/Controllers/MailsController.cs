using Microsoft.AspNetCore.Mvc;
using MonqService.Models;
using MonqService.Services;
using System.Collections.Generic;

namespace MonqService.Controllers
{
    public class MailsController : Controller
    {
        private readonly IEmailService _emailService;

        #region Constructor

        public MailsController(IEmailService emailService)
        {
            _emailService = emailService;
        }

        #endregion
        
        [HttpPost("mails")]
        public IActionResult SendMails([FromBody] MailDto mailRec)
        {
            _emailService.Send(mailRec, mailRec.Subject, mailRec.Body);

            return Ok();
        }

        [HttpGet("mails")]
        public IEnumerable<Mail> GetAllMails()
        {
            return _emailService.GetAllMails();
        }
    }
}
