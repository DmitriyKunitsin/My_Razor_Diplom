using Microsoft.AspNetCore.Identity;

namespace WebAppTests.Data.Identity
{
    public class ApplicationIdentityUser : IdentityUser
    {
        public string RoleId { get; set; }
        public long ApplicationID { get; set; }
        public string Name { get; set; }
        public string MidName { get; set; }
        public string LastName { get; internal set; }
    }
}
