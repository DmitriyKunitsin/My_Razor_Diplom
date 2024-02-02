using Microsoft.AspNetCore.Identity;
using WebAppDiplomTST.Data.Tests;

namespace WebAppDiplomTST.Data.Identity
{
    public class ApplicationUser : IdentityUser
    {
        public string AppId { get; set; }
        public string FirstName { get; set; } //Имя
        public string MidName { get; set; } // Отчество
        public string LastName { get; set; } // Фамилия
        public int? TestId { get; set; } // ID теста к которому относится пользователь
        public ICollection<IdentityUserRole<string>>  UserRoles { get; set; } // cвязь между таблицами пользователей и их ролями

        public ICollection<Test> Tests { get; set; }
    }
}
