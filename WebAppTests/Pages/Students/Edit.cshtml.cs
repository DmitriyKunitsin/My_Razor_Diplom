using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebAppTests.Data.Identity;
using WebAppTests.Models;

namespace WebAppTests.Pages.Students
{
    public class EditModel : PageModel
    {
        private readonly WebAppTests.Data.ApplicationDbContext _context;
        private IMapper _mapper;
        private readonly RoleManager<IdentityRole> _roleManager;
        private UserManager<ApplicationIdentityUser> _userManager;

        public EditModel(WebAppTests.Data.ApplicationDbContext context,
            IMapper mapper,
            RoleManager<IdentityRole> roleManager,
            UserManager<ApplicationIdentityUser> userManager)
        {
            _context = context;
            _mapper = mapper;
            _roleManager = roleManager;
            _userManager = userManager;
        }

        [BindProperty]
        public StudentModels Student { get; set; } = default!;
        [BindProperty]
        public List<string> Roles { get; set; }
        [BindProperty]
        public string SelectedRole { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _context.Users.FirstOrDefaultAsync(m => m.Id == id.ToString());

            Roles = await _roleManager.Roles.Select(r => r.Name).ToListAsync();

            if (student == null)
            {
                return NotFound();
            }
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var student = _mapper.Map<Student>(Student);

            _context.Attach(student).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentExists(student.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool StudentExists(int id)
        {
            return _context.Users.Any(e => e.Id == id.ToString());
        }
    }
}
