using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestsWebApp.Data;
using TestsWebApp.Models;

namespace TestsWebApp.Areas.Identity.Pages
{
    [Authorize]
    public class TestsModel : PageModel
    {
        private readonly UserManager<User> _userManager;
        private readonly ApplicationDbContext _context;

        public List<(Test test, bool isCompleted)> Tests { get; set; }

        [TempData]
        public string StatusMessage { get; set; }

        public TestsModel(UserManager<User> userManager, ApplicationDbContext context)
        {
            _userManager = userManager;
            _context = context;
        }

        
        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            if(user.UserTests.Count == 0)
            {
                var tests = _context.Tests.OrderBy(r => Guid.NewGuid()).Take(2);
                foreach(var t in tests)
                {
                    user.UserTests.Add(new UserTest { Score = -1, Test = t, User = user });
                }
                _context.SaveChanges();
            }

            Tests = user.UserTests.Select(e => ( e.Test, e.IsCompleted)).ToList();

            return Page();
        }
    }
}
