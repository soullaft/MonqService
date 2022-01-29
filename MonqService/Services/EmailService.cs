using Microsoft.Extensions.Configuration;
using MonqService.Data;
using MonqService.Extensions;
using MonqService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;

namespace MonqService.Services
{
    public class EmailService : IEmailService
    {
        /// <summary>
        /// Configuration settings
        /// </summary>
        private readonly IConfiguration _configuration;

        private readonly DataContext _context;

        #region Constructor
        /// <summary>
        /// Default constructor
        /// </summary>
        public EmailService(IConfiguration config, DataContext context)
        {
            _configuration = config;
            _context = context;
        }
        #endregion

        #region IEmailService

        /// <summary>
        /// Sends messages to mailboxes
        /// </summary>
        /// <param name="to"></param>
        /// <param name="subject"></param>
        /// <param name="body"></param>
        public void Send(MailDto to, string subject, string body)
        {
            var messages = new List<MailMessage>();
            var resultMail = MapDtoToMail(to);
            var isError = false;
            var from = new MailAddress("soullaft@gmail.com");

            foreach (var item in to.Recicpients)
            {
                if (!item.IsValidEmailAddress())
                    continue;

                var too = new MailAddress(item);
                var m = new MailMessage(from, too)
                {
                    Subject = subject,
                    Body = body
                };

                messages.Add(m);
            }

            var smtp = GenereteSmtpClient();

            try
            {
                foreach (var msg in messages)
                {
                    smtp.Send(msg);
                }
            }
            catch(Exception ex)
            {
                resultMail.FailedMessage = ex.Message;
                isError = true;
            }
            finally
            {
                resultMail.Result = isError == true ? Result.Failed : Result.Ok;
            }

            resultMail.CreatedAt = DateTime.Now;
            _context.Mails.Add(resultMail);
            _context.SaveChanges();
        }

        /// <summary>
        /// Get all mails
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Mail> GetAllMails()
        {
            _context.Recicpients.ToList();
            return _context.Mails.ToList();
        }

        #endregion
        
        /// <summary>
        /// Generate smtp service with default settings
        /// </summary>
        /// <returns></returns>
        protected SmtpClient GenereteSmtpClient()
        {
            return new SmtpClient()
            {
                Host = _configuration["EmailSettings:Host"],
                Port = Convert.ToInt32(_configuration["EmailSettings:Port"]),
                Credentials = new NetworkCredential(_configuration["EmailSettings:From"], _configuration["EmailSettings:Password"]),
                EnableSsl = true
            };
        }

        /// <summary>
        /// Converts <see cref="MailDto"/> to <see cref="Mail"/>
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        protected Mail MapDtoToMail(MailDto dto)
        {
            var mail = new Mail()
            {
                Subject = dto.Subject,
                Body = dto.Body
            };

            foreach (var item in dto.Recicpients)
            {
                mail.Recicpients.Add(new Recicpients
                {
                    EmailAdress = item
                });
            }

            return mail;
        }

    }
}
