using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;
using WebAppDiplomTST.Data;

namespace WebAppDiplomTST.Pages.Tests
{
    public class ResultsModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        [BindProperty(SupportsGet = true)]
        public int TestId { get; set; }

        public List<int> SelectedAnswers { get; set; }
        [BindProperty]
        public List<int> currentIdAnswers { get; set; }
        [BindProperty]
        public int correctAnswersCount { get; set; }
        [BindProperty]
        public int countAllQuestion { get; set; }

        public ResultsModel(ApplicationDbContext context) { 
            _context = context;
        }
        public void OnGet()
        {
            var test = TestId;
            var idQuestionInTest = _context.Questions.Where(t => t.TestId == test).Select(q => q.Id).ToList();
            currentIdAnswers = new List<int>();
            foreach(var id in idQuestionInTest)
            {
                var cur = _context.Answers.FirstOrDefault(i => i.QuestionId == id && i.IsCorrect == true)?.Id;
                if (cur != null)
                {
                    currentIdAnswers.Add((int)cur);
                }
            }
            var selectedAnswersString = HttpContext.Session.GetString("SelectedAnswers");
            if (!string.IsNullOrEmpty(selectedAnswersString))
            {
                SelectedAnswers = selectedAnswersString.Split(',').Select(int.Parse).ToList();
                countAllQuestion = SelectedAnswers.Count;
                correctAnswersCount = SelectedAnswers.Count(a => currentIdAnswers.Contains(a));

            }
            else
            {
                SelectedAnswers = new List<int>();
            }
        }
    }
}
