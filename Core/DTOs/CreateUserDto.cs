using Core.Enums;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Microsoft.AspNetCore.Http;
namespace Core.DTOs
{
    public class CreateUserDto
    {
        public String FullName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public int PhoneNumber { get; set; }
        public TypeUser UserType { get; set; }
        public IFormFile? Image { get; set; }
        public String Email {  get; set; }  
        
    }
}
