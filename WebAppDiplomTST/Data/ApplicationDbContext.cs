using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using WebAppDiplomTST.Data.Course;
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

        public DbSet<Course.Course> Courses { get; set; }
        public DbSet<Test> Tests { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<UserTest> UserTests { get; set; }
        public DbSet<UserCourse> UserCourses { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<UserCourse>()
                .HasKey(uc => new {uc.UserId, uc.CourseId});

            builder.Entity<UserCourse>()
                .HasOne(uc => uc.User)
                .WithMany(u => u.UserCourses)
                .HasForeignKey(u => u.UserId);

            builder.Entity<UserCourse>()
                .HasOne(uc => uc.Course)
                .WithMany(c => c.UserCourse)
                .HasForeignKey(c => c.CourseId);

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

            builder.Entity<Answer>().HasKey(a => a.Id);
            builder.Entity<Answer>()
            .HasOne(a => a.Question)
            .WithMany(t => t.Answers)
            .HasForeignKey(a => a.QuestionId);

            builder.Entity<Question>().HasKey(a => a.Id);
            builder.Entity<Question>()
                .HasOne(q => q.Test)
                .WithMany(t => t.Questions)
                .HasForeignKey(q => q.TestId);

            builder.Entity<Test>()
                .HasMany(t => t.Questions)
                .WithOne(q => q.Test)
                .HasForeignKey(q => q.TestId);

            builder.Entity<Test>()
                .HasMany(t => t.UserTest)
                .WithOne(ut => ut.Test)
                .HasForeignKey(ut => ut.TestId);

            builder.Entity<Test>()
                .HasOne(t => t.Course)
                .WithMany(c => c.Tests)
                .HasForeignKey(t => t.CourseId);

            builder.Entity<WebAppDiplomTST.Data.Course.Course>()
                .HasMany(c => c.Tests)
                .WithOne(t => t.Course)
                .HasForeignKey(t => t.CourseId);

        }
    }
}
