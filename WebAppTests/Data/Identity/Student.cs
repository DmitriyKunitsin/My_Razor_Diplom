using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAppTests.Data.Identity
{
    [Table("Students", Schema = "data")]
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; internal set; }
        public DateTime BirthDate { get; set; }

        public string? Role {  get; set; }
    }
}
