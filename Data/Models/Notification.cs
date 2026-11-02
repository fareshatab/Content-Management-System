using Core.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Models
{
    public class Notification
    {
        public int Id { get; set; }
        public String Title { get; set; }
        public String Message { get; set; }
        public NotificationAction Action { get; set; }
        public String ActionId { get; set; }
        public String UserId { get; set; }
        public User User { get; set; }
        public DateTime SendAt { get; set; }

    }
}
