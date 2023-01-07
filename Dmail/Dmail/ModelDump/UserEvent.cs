using Dmail.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dmail.Data.Entities.Models
{
    public class UserEvent
    {
        public int UserId { get; set; }
        public User User { get; set; }
        public int EventId { get; set; }
        public Event Event { get; set; }
        public EventStatus Attendance { get; set; }
        public MessageStatus Status { get; set; }

        public UserEvent(int userId, int eventId)
        {
            UserId = userId;
            EventId = eventId;
            Attendance = EventStatus.Unknown;
            Status = MessageStatus.Sent;
        }
    }
}
