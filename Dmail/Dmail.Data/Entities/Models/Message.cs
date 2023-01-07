using Dmail.Data.Seeds;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dmail.Data.Entities.Models
{
    public class Message
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string SentOn { get; set; }
        public int SenderId { get; set; }
        public string Content { get; set; }
        public ICollection<UserMessage> UserMessages { get; set; } = new List<UserMessage>();

        public Message(string title, string sentOn, int senderId, string content)
        {
            Id = IdGenerator.NewMessageEventId();
            Title = title;
            SentOn = sentOn;
            SenderId = senderId;
            Content = content;
        }
    }
}
