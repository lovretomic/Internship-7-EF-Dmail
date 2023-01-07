using Dmail.Data.Seeds;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;

namespace Dmail.Data.Entities.Models
{
    public class Event
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public int SenderId { get; set; }
        public ICollection<UserEvent> UserEvents { get; set; } = new List<UserEvent>();

        public Event(string title, string startDate, string endDate, int senderId)
        {
            Title = title;
            StartDate = startDate;
            EndDate = endDate;
            SenderId = senderId;
        }
    }
}
