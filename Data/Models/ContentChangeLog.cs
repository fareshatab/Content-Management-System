using Core.Enums;
using System;
using System.Collections.Generic;
using System.Net.Mime;
using System.Text;

namespace Data.Models
{
    public class ContentChangeLog
    {
        public int Id { get; set; }
        public int ContentId { get; set; }
        public DateTime ChangeAt { get; set; }
        public ContentTypee Type { get; set; }
        public ContentStatus Old { get; set; }
        public ContentStatus New { get; set; }

    }
}
