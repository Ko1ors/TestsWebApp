using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TestsWebApp.Data;
using TestsWebApp.Models;

namespace TestsWebApp.Areas.Identity.Pages
{
    [Authorize]
    public class TestResultModel : PageModel
    {
        private readonly UserManager<User> _userManager;

        [TempData]
        public string StatusMessage { get; set; }

        public Test SelectedTest { get; set; }

        public int Score { get; set; }


        public TestResultModel(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            if (!user.UserTests.Any(e => e.Test.ID == id))
                return RedirectToPage("Tests");

            var userTest = user.UserTests.Where(e => e.Test.ID == id).FirstOrDefault();

            if(!userTest.IsCompleted)
                return RedirectToPage("Tests");

            SelectedTest = userTest.Test;
            Score = userTest.Score;

            return Page();
        }
    }
}
