using Blog.Security.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Security.ViewModels
{
    public class RegisterResponseVM
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public RegisterResponseVM(BlogUser user)
        {
            Id = user.Id;
            Name = user.Name;
            Email = user.Email;
        }
    }
}