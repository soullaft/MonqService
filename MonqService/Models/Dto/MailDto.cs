using AutoMapper;
using System.Collections.Generic;

namespace MonqService.Models
{
    [AutoMap(typeof(Mail))]
    public class MailDto
    {
        /// <summary>
        /// Subject of mail
        /// </summary>
        public string Subject { get; set; }

        /// <summary>
        /// Body of mail
        /// </summary>
        public string Body { get; set; }

        /// <summary>
        /// Recicpients of mail
        /// </summary>
        public IList<string> Recicpients { get; set; }
    }
}
