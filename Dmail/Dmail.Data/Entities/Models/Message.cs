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
        public DateTime SentOn { get; set; }
        public DateTime ReceivedOn { get; set;}
        public int SenderId { get; set; }
        public List<int> Receivers { get; set; }
        public string Content { get; set; }
        public ICollection<UserMessage> UserMessages { get; set; } = new List<UserMessage>();
    }
}
