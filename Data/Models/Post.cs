using Core.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Models
{
    public class Post : BaseEntity
    {
        public int Id { get; set; }
        public String Title { get; set; }
        public String Body { get; set; }
        public int TimeInMinute { get; set; }
        public String AuthorId {  get; set; }
        public User Author { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public List<Attachment> Attachments { get; set; }
        public ContentStatus Status { get; set; }

        public Post()
        {
            Status = ContentStatus.pending;
        }

    }
}
