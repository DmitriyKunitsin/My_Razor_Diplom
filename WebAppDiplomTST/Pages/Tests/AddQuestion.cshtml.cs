using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebAppDiplomTST.Data.Tests;

namespace WebAppDiplomTST.Pages.Tests
{
    public class AddQuestionModel : PageModel
    {
        [BindProperty]
        public Question Question { get; set; }
        [BindProperty]
        public int TestProp { get; set; }
        public void OnGet()
        {
            
        }
        [HttpPost]
        public IActionResult OnPostAddQuest()
        {
            //TestProp = Question.Text;
            string test = Question.Text;
            TestProp++;
            return Page();
        }

    }
}
