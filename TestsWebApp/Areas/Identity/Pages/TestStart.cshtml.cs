using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Linq;
using System.Threading.Tasks;
using TestsWebApp.Data;
using TestsWebApp.Models;
using TestsWebApp.Services;

namespace TestsWebApp.Areas.Identity.Pages
{
    [Authorize]
    public class TestStartModel : PageModel
    {
        private readonly UserManager<User> _userManager;
        private readonly ApplicationDbContext _context;
        private readonly ITestService _testService;

        public Question Question { get; set; }

        [BindProperty]
        public int SelectedAnswer { get; set; } = -1;

        public string TestName { get; set; }

        [TempData]
        public string StatusMessage { get; set; }

        public TestStartModel(UserManager<User> userManager, ApplicationDbContext context, ITestService testService)
        {
            _userManager = userManager;
            _context = context;
            _testService = testService;
        }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            return await LoadQuestion(id);
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            if (SelectedAnswer > -1)
                await AddSelectedAnswer(id);

            return await LoadQuestion(id);
        }

        private async Task AddSelectedAnswer(int id)
        {
            var user = await _userManager.GetUserAsync(User);
            var questionId = (await _testService.GetCurrentQuestion(user)).ID;
            var answer = _context.Tests.FirstOrDefault(e => e.ID == id)?.Questions
                .FirstOrDefault(e => e.ID == questionId)?.Answers
                .FirstOrDefault(e => e.ID == SelectedAnswer);
            if (answer != null)
                _testService.AddCurrentQuestionAnswer(user, answer);
        }

        private async Task<IActionResult> LoadQuestion(int id)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            if (!user.UserTests.Any(e => e.Test.ID == id))
                return RedirectToPage("Tests");

            var test = user.UserTests.Where(e => e.Test.ID == id).Select(e => e.Test).FirstOrDefault();

            if (await _testService.HasStartedTest(user))
            {
                var startedTest = await _testService.GetStartedTest(user);
                if (startedTest.ID != id)
                    return RedirectToPage("TestStart", new { id = startedTest.ID });

                var question = await _testService.GetCurrentQuestion(user);

                if (question == null)
                {
                    var (score, maxScore) = await _testService.FinishTest(user);
                    var userTest = user.UserTests.FirstOrDefault(e => e.Test.ID == id);

                    userTest.Score = (int)((double)score / maxScore * 100);
                    userTest.IsCompleted = true;

                    _context.SaveChanges();

                    return RedirectToPage("TestResult", new { id });
                }

                Question = test.Questions.FirstOrDefault(e => e.ID == question.ID);
            }
            else
                Question = await _testService.StartTest(user, test);

            TestName = test.Name;

            return Page();
        }
    }
}
