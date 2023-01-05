using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dmail.Data.Entities.Models
{
    public class UserEvent
    {
        public string UserId { get; set; }
        public User User { get; set; }
        public string EventId { get; set; }
        public Event Event { get; set; }
    }
}
