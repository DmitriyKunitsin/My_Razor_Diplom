using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesMovie.Data;
using RazorPagesMovie.Models;

namespace RazorPagesMovie.Pages.Students
{
    public class DetailsModel : PageModel
    {
        private readonly RazorPagesMovie.Data.SchoolContext _context;

        public DetailsModel(RazorPagesMovie.Data.SchoolContext context)
        {
            _context = context;
        }

        public Student Student { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Student = await _context.Students
                .Include(s => s.Enrollments)//Методы Include и ThenInclude инструктируют контекст для загрузки свойства
                .ThenInclude(e => e.Course)//навигации Student.Enrollments, а также свойства навигации Enrollment.Course
                .AsNoTracking()//в пределах каждой регистрации
                .FirstOrDefaultAsync(m => m.Id == id);
            if (Student == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
