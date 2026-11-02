using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Data.Models
{
    public class Email
    {
        public int Id { get; set; }
        public String Subject { get; set; }
        public String Body { get; set; }
        public String UserId { get; set; }
        public User user { get; set; }
        public DateTime SendAt { get; set; }

    }
}
