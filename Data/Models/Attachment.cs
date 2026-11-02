using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Models
{
    public class Attachment
    {
        public int Id { get; set; }
        public int PostId { get; set; }
        public Post post { get; set; }
        public String AttachmentURL { get; set; }


    }
}
