using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebAppDiplomTST.Data.Identity;
using WebAppDiplomTST.Data.Tests;

namespace WebAppDiplomTST.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, IdentityRole, string>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Test> Tests { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<UserTest> UserTests { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<UserTest>()
                .HasKey(ut => new { ut.UserId, ut.TestId });
            //Устанавливает составной первичный ключ для таблицы UserTest,
            //используя свойства UserId и TestId.

            builder.Entity<UserTest>()
                .HasOne(ut => ut.User)
                .WithMany(u => u.UserTests)
                .HasForeignKey(ut => ut.UserId);
            //Определяет связь "один ко многим" между таблицами User и UserTest.
            //Каждая запись в таблице UserTest будет иметь внешний ключ UserId,
            //который ссылается на первичный ключ пользователя.
            //Свойство UserTests в классе User представляет коллекцию связанных записей
            //из таблицы UserTest.

            builder.Entity<UserTest>()
                .HasOne(ut => ut.Test)
                .WithMany(t => t.UserTest)
                .HasForeignKey(ut => ut.TestId);
            //Определяет связь "один ко многим" между таблицами Test и UserTest.
            //Каждая запись в таблице UserTest будет иметь внешний ключ TestId,
            //который ссылается на первичный ключ теста.
            //Свойство UserTests в классе Test представляет коллекцию связанных записей
            //из таблицы UserTest.


            builder.Entity<Answer>()
            .HasOne(a => a.Test)
            .WithMany(t => t.Answers)
            .HasForeignKey(a => a.TestId);
        }
    }
}
