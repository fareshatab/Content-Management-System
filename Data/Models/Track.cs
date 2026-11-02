using Core.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Models
{
    public class Track : BaseEntity
    {
        public int Id { get; set; }
        public String Title { get; set; }

        public int TimeInMintes { get; set; }
        public String TrackURl { get; set; }
        public String OwnerName { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public String PublishedByID { get; set; }
        public User PublishedBy { get; set; }
        public ContentStatus Status { get; set; }

    }
}
