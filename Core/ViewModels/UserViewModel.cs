using Core.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.ViewModels
{
    public class UserViewModel
    {
        public String Id { get; set; }
        public String FullName { get; set; }
        public String Email { get; set; }
        public String PhoneNumber { get; set; }
        public String DateOfBerth { get; set; }
        public String ImageURL { get; set; }
        public String UserType { get; set; }
        public DateTime CreatedAt { get; set; }


    }
}
