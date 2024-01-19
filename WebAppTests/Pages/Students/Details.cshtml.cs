using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebAppTests.Data;
using WebAppTests.Data.Identity;

namespace WebAppTests.Pages.Students
{
    public class DetailsModel : PageModel
    {
        private readonly WebAppTests.Data.ApplicationDbContext _context;

        public DetailsModel(WebAppTests.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public ApplicationIdentityUser Student { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _context.Users.FirstOrDefaultAsync(m => m.Id == id.ToString());
            if (student == null)
            {
                return NotFound();
            }
            else
            {
                Student = student;
            }
            return Page();
        }
    }
}
