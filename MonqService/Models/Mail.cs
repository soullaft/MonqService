using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

/// <summary>
/// Represents default models
/// </summary>
namespace MonqService.Models
{
    public class Mail
    {
        /// <summary>
        /// Identifier
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Subject of mail
        /// </summary>
        [Required]
        [StringLength(30)]
        public string Subject { get; set; }

        /// <summary>
        /// Body of mail
        /// </summary>
        [Required]
        [StringLength(150)]
        public string Body { get; set; }

        /// <summary>
        /// Recicpients of mail
        /// </summary>
        [Required]
        public IList<Recicpients> Recicpients { get; set; } = new List<Recicpients>();

        /// <summary>
        /// Date created
        /// </summary>
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Result of sending message
        /// </summary>
        public Result Result { get; set; }

        /// <summary>
        /// Contains error text
        /// </summary>
        public string FailedMessage { get; set; }
    }
}
