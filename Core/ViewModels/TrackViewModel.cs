using System;
using System.Collections.Generic;
using System.Text;

namespace Core.ViewModels
{
    public class TrackViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int TimeInMinute { get; set; }
        public string TrackUrl { get; set; }
        public string OwnerName { get; set; }
        public CategoryViewModel Category { get; set; }
        public UserViewModel PublishedBy { get; set; }
        public string Status { get; set; }
        public string CreatedAt { get; set; }
    }
}
