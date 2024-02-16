using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Metrics;
using WebAppDiplomTST.Data;
using WebAppDiplomTST.Data.Tests;

namespace WebAppDiplomTST.Pages.Tests
{
    public class AddQuestionModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        public AddQuestionModel(ApplicationDbContext context)
        {
            _context = context;
        }
        private int counter;
        [BindProperty]
        public Question Question { get; set; }
        [BindProperty]
        public bool checkCorrectAnswer { get; set; }
        [BindProperty]
        public List<string> answerText { get; set; }
        public void OnGet()
        {
            if (HttpContext.Session.GetInt32("Counter") != null)
            {
                HttpContext.Session.GetInt32("Counter");
            }
            else
            {
                HttpContext.Session.SetInt32("Counter", 1);
            }
            counter = HttpContext.Session.GetInt32("Counter").Value;
            ViewData["Counter"] = counter;
        }
        [HttpPost]
        public IActionResult OnPostAddQuest()
        {
            //if (!ModelState.IsValid)
            //{
            //    return Page();
            //}
            if (HttpContext.Session.GetInt32("Counter") != null)
            {
                counter = HttpContext.Session.GetInt32("Counter").Value;
            }
            counter++;
            HttpContext.Session.SetInt32("Counter", counter);

            int lastQuestionId = _context.Questions.Max(x => x.Id);

            int count = 0;
            foreach (var answer in answerText)
            {

                var quest = new Answer
                {
                    Text = answerText[count],
                    QuestionId = lastQuestionId,
                    lvlQuestion = counter - 1
                };
                count++;
                _context.Answers.Add(quest);
            }
            _context.SaveChanges();
            var entityQuest = _context.Questions.Find(lastQuestionId);
            if (entityQuest != null)
            {
                entityQuest.Text = Question.Text;
            }
            _context.SaveChanges();

            int newIdQuestion = lastQuestionId + 1;
            var newQest = new Question
            {
                TestId = entityQuest.TestId,
                Text = "Новый вопрос"
            };
            _context.Questions.Add(newQest);
            _context.SaveChanges();
            return RedirectToPage();
        }

        public IActionResult OnPostAddAnswer()
        {
            return RedirectToPage();
        }
        public IActionResult OnPostSaveTest()
        {
            return RedirectToPage("/Tests");
        }

    }
}
