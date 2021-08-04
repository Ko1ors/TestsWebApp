using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestsWebApp.Models
{
    public class User : IdentityUser
    {
        public string Name { get; set; }

        public virtual List<UserTest> UserTests { get; set; } = new List<UserTest>();
    }
}
