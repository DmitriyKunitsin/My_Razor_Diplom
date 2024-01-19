using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebAppTests.Data.Identity;

namespace WebAppTests.Pages
{
    [Authorize(Policy = "Managers")]
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly RoleManager<IdentityRole> _roleManager;
        private UserManager<ApplicationIdentityUser> _userManager;

        public IndexModel(ILogger<IndexModel> logger,
            RoleManager<IdentityRole> roleManager,
            UserManager<ApplicationIdentityUser> userManager)
        {
            _logger = logger;
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public void OnGet()
        {

        }

        public async Task OnPostNewRole(RoleModel model)
        {
            string roleName = model.RoleName.Trim();
            if (!string.IsNullOrEmpty(roleName))
            {
                if(!await _roleManager.RoleExistsAsync(roleName))
                {
                    await _roleManager.CreateAsync(new IdentityRole
                    {
                        Name = roleName,
                        NormalizedName = roleName
                    });
                }
            }
        }

        public async Task OnPostAddRole(RoleModel model)
        {
            string roleName = model.RoleName.Trim();
            if (!string.IsNullOrEmpty(roleName))
            {
                var user = await _userManager.GetUserAsync(this.User);
                await _userManager.AddToRoleAsync(user, roleName);
            }
        }

        public async Task OnPostRemoveRole(RoleModel model)
        {
            string roleName = model.RoleName.Trim();
            if(!string.IsNullOrEmpty(roleName))
            {
                var user = await _userManager.GetUserAsync(this.User);
                await _userManager.RemoveFromRoleAsync(user, roleName);
            }
        }
    }
}
