using Dmail.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dmail.Data.Entities.Models
{
    public class UserItem
    {
        public int ItemId { get; set; }
        public Item Item { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public EventStatus Attendance { get; set; }
        public MessageStatus Status { get; set; }
        public bool IsSpam { get; set; }

        public UserItem(int userId, int itemId)
        {
            UserId = userId;
            ItemId = itemId;
        }

    }
}
