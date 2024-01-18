using Microsoft.AspNetCore.Identity;

namespace WebAppTests.Models
{
    public class StudentModels
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Role { get; set; }
        public string FullName { get; internal set; }
    }
}
