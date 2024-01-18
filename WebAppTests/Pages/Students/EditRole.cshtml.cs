using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebAppTests.Data;
using WebAppTests.Data.Identity;
using WebAppTests.Models;


namespace WebAppTests.Pages.Students
{
    public class EditRoleModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IMapper _mapper;
        private readonly UserManager<Student> _userManager;

        public EditRoleModel(ApplicationDbContext context,
            RoleManager<IdentityRole> roleManager,
            IMapper mapper,
            UserManager<Student> userManager)
        {
            _context = context;
            _roleManager = roleManager;
            _mapper = mapper;
            _userManager = userManager;
        }
        [BindProperty]
        public List<string> Roles { get; set; }
        public StudentModels Student { get; set; }
        public string SelectedStudent { get; set; }
        public string SelectedRole { get; set; }
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _context.Users.FirstOrDefaultAsync(m => m.Id == id.ToString());
            Student = _mapper.Map<ApplicationIdentityUser,StudentModels>(student);
            SelectedStudent = student.Name;

            Roles = await _roleManager.Roles.Select(u => u.Name).ToListAsync();

            if (student == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            string userID = id.ToString();
            var student = await _userManager.FindByIdAsync(userID);

            if (student == null)
            {
                return NotFound();
            }
            else
            {
                await _userManager.RemoveFromRoleAsync(student, Student.Role);
                await _userManager.AddToRoleAsync(student, SelectedRole);
            }
           



            //Student = _mapper.Map<Student, StudentModels>(student);

            //_context.Attach(student).State = EntityState.Modified;

            //try
            //{

                await _context.SaveChangesAsync();
            //}
            //catch (DbUpdateConcurrencyException)
            //{
            //    if (!StudentExists(student.Id))
            //    {
            //        return NotFound();
            //    }
            //    else
            //    {
            //        throw;
            //    }
            //}
            return RedirectToPage("./Index");
        }
        private bool StudentExists(int id)
        {
            return _context.Users.Any(e => e.Id == id.ToString());
        }
    }
}
