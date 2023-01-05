using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dmail.Data.Entities.Models
{
    public class Event
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int SenderId { get; set; }
        public List<int> Receivers { get; set; }

        public ICollection<UserEvent> UserEvents { get; set; } = new List<UserEvent>();
    }
}
