using Core.Enums;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Text;
namespace Core.DTOs
{
    public class UpdateUserDto
    {
        public string Id { get; set; }
  
        [Display(Name = "اسم المستخدم")]
        public String FullName { get; set; }
        [Display(Name = "تاريخ الميلاد")]
        public DateTime? DateOfBirth { get; set; }
        [Display(Name = " رقم الهاتف")]
        public int PhoneNumber { get; set; }
        public TypeUser UserType { get; set; }
        public IFormFile? Image { get; set; }
        [Display(Name = "البريد الإلكتروني")]
        public String Email {  get; set; }  
        
    }
}
