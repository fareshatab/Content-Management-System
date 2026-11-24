using Core.Enums;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
namespace Data.Models
{
    public class User : IdentityUser
    {
        public String FullName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public String? ImgURL { get; set; }
        public TypeUser UserType { get; set; }
        public bool IsDelete { get; set; }
        public string? FCMToken { get; set; }

        public DateTime? CreatedAt { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string? UpdatedBy { get; set; }

        public List<Post> Posts { get; set; }
        public List<Track> Tracks { get; set; }
        public List<Advertisment> Advertisments { get; set; }
        public List<Email> Emails { get; set; }
        public List<Notification> Notifications { get; set; }
    }
}
