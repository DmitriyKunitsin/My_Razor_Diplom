using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Drawing.Drawing2D;
using WebAppDiplomTST.Data;
using WebAppDiplomTST.Data.Tests;

namespace WebAppDiplomTST.Pages.Tests
{
    public class PassingTestModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public PassingTestModel(ApplicationDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
            idDate = new List<idTest>();
        }
        public List<idTest> idDate { get; set; }
        [BindProperty]
        public List<TestModel> TestModels { get; set; }
        public IActionResult OnGet(int testId)
        {
            var test = _context.Tests.Include(t => t.Questions)
                .ThenInclude(q => q.Answers).
                FirstOrDefault(t => t.Id == testId);
            var quest = _context.Questions.Where(x => x.TestId == testId).ToList();
            int[] arr = new int[quest.Count()];
            int count = 0;

            foreach (var i in quest)
            {
                arr[count] = i.Id;
                count++;
            }

            idTest idDate = new idTest(arr);
            this.idDate.Add(idDate);

            if (test != null)
            {
                var testModel = new TestModel
                {
                    Test = test.Name,
                    Questions = test.Questions,
                    Answers = new List<Answer>()
                };

                foreach (var question in test.Questions)
                {
                    var idCheck = _context.Answers.Where(x => x.QuestionId == question.Id).ToList();
                    foreach (var answer in question.Answers)
                    {
                        testModel.Answers.Add(answer);
                    }
                }

                var combinedModel = new CombinedModel
                {
                    Test = testModel,
                    PassingTest = this
                };

                ViewData["CombinedModel"] = combinedModel;
            }
            return Page();
        }
        public IActionResult OnPost(int testId, List<int> selectedAnswers)
        {
            // Здесь вы можете обрабатывать выбранные ответы и выполнять необходимые действия
            var selectedAnswersString = string.Join(",", selectedAnswers);
            _httpContextAccessor.HttpContext.Session.SetString("SelectedAnswers", selectedAnswersString);

            return RedirectToPage("/Tests/Results", new { testId });
        }
    }
    public class idTest
    {
        public int[] idTests { get; set; }

        public idTest(int[] ids)
        {
            idTests = ids;
        }
    }
    public class TestModel
    {
        public string Test { get; set; }
        public ICollection<Question> Questions { get; set; }
        public ICollection<Answer> Answers { get; set; }
    }
    public class CombinedModel
    {
        public TestModel Test { get; set; }
        public PassingTestModel PassingTest { get; set; }
    }
}
