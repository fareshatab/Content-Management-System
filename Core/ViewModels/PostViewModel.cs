using System;
using System.Collections.Generic;
using System.Text;

namespace Core.ViewModels
{
    public class PostViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public int TimeInMinute { get; set; }
        public string CreatedAt { get; set; }
        public CategoryViewModel Category { get; set; }
        public UserViewModel Author { get; set; }
        public string Status { get; set; } //مهممممممممممممم النصص
        public List<PostAttachmentViewModel> Attachments { get; set; }
    }
}
