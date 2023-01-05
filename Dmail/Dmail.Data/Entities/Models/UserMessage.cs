using Dmail.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dmail.Data.Entities.Models
{
    public class UserMessage
    {
        public int UserId { get; set; }
        public User User { get; set; } = null!;
        public int MessageId { get; set; }
        public Message Message { get; set; }
        public MessageStatus Status { get; set; }
    }
}
