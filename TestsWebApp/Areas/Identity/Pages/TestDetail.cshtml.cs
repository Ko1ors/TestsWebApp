using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Linq;
using System.Threading.Tasks;
using TestsWebApp.Data;
using TestsWebApp.Models;

namespace TestsWebApp.Areas.Identity.Pages
{
    [Authorize]
    public class TestDetailModel : PageModel
    {
        private readonly UserManager<User> _userManager;

        [TempData]
        public string StatusMessage { get; set; }

        public Test SelectedTest { get; set; }

        [BindProperty]
        public bool IsChecked { get; set; }

        public TestDetailModel(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            return await GetSelectedTest(id);
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            if (IsChecked)
                return RedirectToPage("TestStart", new { id });
            else
                return await GetSelectedTest(id);
        }

        private async Task<IActionResult> GetSelectedTest(int id)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            if (!user.UserTests.Any(e => e.Test.ID == id))
                return RedirectToPage("Tests");

            SelectedTest = user.UserTests.Where(e => e.Test.ID == id).Select(e => e.Test).FirstOrDefault();

            return Page();
        }
    }
}
