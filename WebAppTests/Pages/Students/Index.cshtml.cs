using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebAppTests.Data;
using WebAppTests.Data.Identity;
using WebAppTests.Models;

namespace WebAppTests.Pages.Students
{
    [Authorize(Roles = "Professor, Student")]
    public class IndexModel : PageModel
    {
        private readonly WebAppTests.Data.ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly UserManager<ApplicationIdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public IndexModel(WebAppTests.Data.ApplicationDbContext context,
            IMapper mapper,
            UserManager<ApplicationIdentityUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            _mapper = mapper;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public IList<StudentModels> Student {  get; set; }
      //  public IList<Student> Student { get;set; } = default!;

        public async Task OnGetAsync()
        {
            var students = await _context.Users.ToListAsync();
            if (students != null)
            {

                for (int i = 0; i < students.Count; i++)
                {
                    var user = await _userManager.FindByIdAsync(students[i].Id.ToString());
                    if (user != null)
                    {
                        var roles = await _userManager.GetRolesAsync(user);
                        Student[i].Role = roles[i];
                    }
                }
            }
            Student = _mapper.Map<List<ApplicationIdentityUser>, List<StudentModels>>(students);
        }
    }
}
