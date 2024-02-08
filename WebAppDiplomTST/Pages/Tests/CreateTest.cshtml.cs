using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Identity;
using WebAppDiplomTST.Data.Identity;
using WebAppDiplomTST.Data.Tests;
using WebAppDiplomTST.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace WebAppDiplomTST.Pages.Tests
{
    public class CreateTestModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly Test _test;
        private readonly ApplicationDbContext _context;

        public CreateTestModel(UserManager<ApplicationUser> userManager, ApplicationDbContext context)
        {
            _userManager = userManager;
            _context = context;
            _test = _context.Tests.FirstOrDefault();
        }

        [BindProperty]
        public Test Test { get; set; }

        public IActionResult OnGet()
        {
            if (string.IsNullOrEmpty(_userManager.GetUserId(User)))
            {
                return RedirectToPage("/Index");
            }
            
            return Page();
        }
        public IActionResult OnPost()
        {
            if(string.IsNullOrEmpty(_userManager.GetUserId(User)))
            {
                return RedirectToPage("/Account/Login");
            }

            //TODO add logic saved in db

            return RedirectToPage("");
        }

        [HttpPost]
        public async Task<IActionResult> OnPostAddQuestion() 
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            Test newTest = new Test
            {
                Name = Test.Name,
                Title = Test.Title
            };

            _context.Tests.Add(newTest);
            await _context.SaveChangesAsync();

            return RedirectToPage("/Tests/AddQuestion");
        }
    }
}
