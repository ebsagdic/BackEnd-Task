
using Core.Enums;
using Microsoft.AspNetCore.Identity;
using System;

namespace BackEnd_Task.Models
{
    public class ApplicationUser: IdentityUser
    {
        public UserRole Role { get; set; } 

    }
}
