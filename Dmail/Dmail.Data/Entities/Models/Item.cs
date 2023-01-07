using Dmail.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dmail.Data.Entities.Models
{
    public class Item
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string SentOn { get; set; }
        public int SenderId { get; set; }
        public ItemType Type { get; set; }

        public string Content { get; set; }
        public string StartDate { get; set; }

        public ICollection<UserItem> UserItems { get; set; } = new List<UserItem>();

        public Item(string title, string sentOn, int senderId, ItemType type)
        {
            Title = title;
            SentOn = sentOn;
            SenderId = senderId;
            Type = type;
        }
    }
}
