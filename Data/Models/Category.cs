using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Models
{
    public class Category : BaseEntity
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public List<Post> Posts { get; set; }

    }
}
