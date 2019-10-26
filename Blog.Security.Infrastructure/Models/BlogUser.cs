using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Security.Infrastructure.Models
{
    public class BlogUser : IdentityUser
    {
        public string Name { get; set; }
    }
}
