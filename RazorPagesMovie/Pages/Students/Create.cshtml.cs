using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RazorPagesMovie.Data;
using RazorPagesMovie.Models;

namespace RazorPagesMovie.Pages.Students
{
    public class CreateModel : PageModel
    {
        private readonly RazorPagesMovie.Data.SchoolContext _context;

        public CreateModel(RazorPagesMovie.Data.SchoolContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Student Student { get; set; } = default!;

        public async Task<IActionResult> OnPostAsync()
        {
            var emtyStudent = new Student();

            if (await TryUpdateModelAsync<Student>
                (emtyStudent, 
                "student",
                s => s.FirstMidName, s => s.LastName, s => s.EnrollmentDate)) 
            {
                _context.Students.Add(emtyStudent);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            return Page();
        }
    }
}
