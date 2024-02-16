using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Identity;
using WebAppDiplomTST.Data.Identity;
using WebAppDiplomTST.Data.Tests;
using WebAppDiplomTST.Data;
using Microsoft.EntityFrameworkCore;

namespace WebAppDiplomTST.Pages.Tests
{
    public class AllTestsModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly Test _test;
        private readonly ApplicationDbContext _context;

        public AllTestsModel(UserManager<ApplicationUser> userManager, ApplicationDbContext context)
        {
            _userManager = userManager;
            _context = context;
            _test = _context.Tests.FirstOrDefault();
        }

        [BindProperty]
        public List<Test> Tests { get; set; }
        [BindProperty]
        public int testId { get; set; }
        [BindProperty]
        public string ErrorMessage { get; set; }
        [BindProperty]
        public string Check { get; set; }

        public IActionResult OnGet()
        {
            if (string.IsNullOrEmpty(_userManager.GetUserId(User)))
            {
                return RedirectToPage("/Index");
            }
            ErrorMessage = null;
            Tests = _context.Tests.ToList();
            if (_test == null)
            {
                ErrorMessage = "База данных пуста";
            }
            return Page();
        }
        public IActionResult OnPost()
        {
            if (string.IsNullOrEmpty(_userManager.GetUserId(User)))
            {
                return RedirectToPage("/Account/Login");
            }

            //TODO add logic saved in db

            return RedirectToPage("");
        }

        [HttpPost]
        public IActionResult OnPostCreatedTest()
        {
            return RedirectToPage("/Tests/CreateTest");
        }
        public IActionResult OnPostDetails()
        {
            // Обработка нажатия на блок div с определенным testId
            int checkIdTest = testId;

            return RedirectToPage("/Tests/PassingTest", new { testId = testId });
        }
    }
}
