using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Models
{
    public class Advertisment : BaseEntity
    {
        public int Id { get; set; }
        public String Title { get; set; }
        public String ImageURL { get; set; }
        public String WebURL { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public String? OwnerID { get; set; }
        public User Owner { get; set; }

    }
}
