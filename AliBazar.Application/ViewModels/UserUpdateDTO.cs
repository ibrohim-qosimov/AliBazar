using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AliBazar.Application.ViewModels
{
    public class UserUpdateDTO
    {
        public required string Name { get; set; }
        public required string PhoneNumber { get; set; }
        public required string Password { get; set; }
        public IFormFile? ImageUrl { get; set; }
    }
}
