using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebAppTests.Data.Identity;

namespace WebAppTests.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationIdentityUser, IdentityRole, string>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        //public DbSet<Student> Students { get; set; }
        //public DbSet<ApplicationIdentityUser> Users { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            //builder.Entity<Student>().ToTable("Students");
            //builder.Entity<Student>().Property(z => z.Id).ValueGeneratedOnAdd();
            //builder.Entity<Student>().Property(z => z.Name).HasMaxLength(25);

            //builder.Entity<ApplicationIdentityUser>().HasData(
            //    new ApplicationIdentityUser
            //    {
            //        Name = "Goga",
            //        LastName = "Mamedov",
            //    });


            base.OnModelCreating(builder);
        }
    }
}
