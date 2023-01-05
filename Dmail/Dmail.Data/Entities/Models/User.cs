using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dmail.Data.Entities.Models
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public ICollection<UserEvent> UserEvents { get; set; } = new List<UserEvent>();
        public ICollection<UserMessage> UserMessages { get; set; } = new List<UserMessage>();

        public User(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        } 
    }
}
